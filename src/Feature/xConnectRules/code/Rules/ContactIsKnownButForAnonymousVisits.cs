using System;
using System.Web;
using Sitecore.Diagnostics;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;
using Sitecore.XConnect;
using Sitecore.XConnect.Client;

namespace Sitecore.Feature.xConnectRules.Rules
{
    /// Defines the item readable condition class.
    /// <typeparam name="T"></typeparam>
    public class ContactIsKnownButForAnonymousVisits<T> : OperatorCondition<T> where T : RuleContext
    {///
     /// Gets or sets the value.
     /// <value>The value.</value>
        public string Value
        {
            get;
            set;
        }

        /// Executes the specified rule context.
        /// <param name="ruleContext">The rule context.</param>
        /// <returns>
        ///   <c>True</c>, if the condition succeeds, otherwise <c>false</c>.
        /// </returns>
        protected override bool Execute(T ruleContext)
        {
            // Get the Global Cookie

            HttpCookie globalCookie = HttpContext.Current.Request.Cookies["sc_analytics_global_cookie"];


            // Number of days which user has not logged in

            int value;
            if (!int.TryParse(this.Value, out value))
            {
                Log.Debug(string.Format("Specified number [{0}] was not a valid Number", this.Value));
                return false;
            }
            if (globalCookie != null)
            {

                // Find the Cookie Value

                string cookieValue = globalCookie.Value.Substring(0, 32);

                // Convert the Cookie value to Guid

                 Guid contactid = Guid.Parse(cookieValue);
                

                // Get the Contact using Golable Cookie

                using (Sitecore.XConnect.Client.XConnectClient client = Sitecore.XConnect.Client.Configuration.SitecoreXConnectClientConfiguration.GetClient())
                {
                    var reference = new Sitecore.XConnect.ContactReference(contactid);

                    Contact contact = client.Get<Contact>(reference, new Sitecore.XConnect.ContactExpandOptions() { });

                    if (contact != null)
                    {
                        // Identify the the Known contact

                        if (contact.IsKnown)
                        {
                            DateTime currentDateTime = DateTime.Now;
                            DateTime pastDateTime = currentDateTime.AddDays(-value);

                            //Find out if there are any interaction from past date

                            var results = client.Get<Sitecore.XConnect.Contact>(reference, new Sitecore.XConnect.ContactExpandOptions()
                            {
                                Interactions = new Sitecore.XConnect.RelatedInteractionsExpandOptions()
                                {
                                    StartDateTime = pastDateTime,
                                    EndDateTime = currentDateTime ,

                                }
                            });

                            if (results == null)
                            {
                                return true;
                            }

                        }
                    }

                }
            }

            return false;
        }

    }

}