using System;
using System.Web;
using Sitecore.Diagnostics;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;
using Sitecore.XConnect;
using Sitecore.XConnect.Client;
using Sitecore.XConnect.Collection.Model;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sitecore.Analytics.Core;
using Sitecore.Analytics.Model;
using Sitecore.Analytics;

namespace Sitecore.Feature.xConnectRules.Rules
{
    public class ContactTriggeredGoalForItemRule<T> : WhenCondition<T> where T : RuleContext
    {

        public string GoalId { get; set; }
        public string PageId { get; set; }

        private Guid GoalGuid { get; set; }
        private Guid PageGuid { get; set; }




        /// Executes the specified rule context.
        /// <param name="ruleContext">The rule context.</param>
        /// <returns>
        ///   <c>True</c>, if the condition succeeds, otherwise <c>false</c>.
        /// </returns>
        protected override bool Execute(T ruleContext)
        {
            Assert.ArgumentNotNull((object)ruleContext, nameof(ruleContext));
            Assert.IsNotNull((object)Tracker.Current, "Tracker.Current is not initialized");
            Assert.IsNotNull((object)Tracker.Current.Session, "Tracker.Current.Session is not initialized");
            Assert.IsNotNull((object)Tracker.Current.Session.Interaction, "Tracker.Current.Session.Interaction is not initialized");
            try
            {
                this.GoalGuid = new Guid(this.GoalId);
            }
            catch
            {
                Log.Warn(string.Format("Could not convert value to guid: {0}", (object)this.GoalId), (object)this.GetType());
                return false;
            }

            try
            {
                this.PageGuid = new Guid(this.PageId);
            }
            catch
            {
                Log.Warn(string.Format("Could not convert value to guid: {0}", (object)this.PageId), (object)this.GetType());
                return false;
            }

            HttpCookie globalCookie = HttpContext.Current.Request.Cookies["sc_analytics_global_cookie"];


            
            if (globalCookie != null)
            {

                // Find the Cookie Value

                string cookieValue = globalCookie.Value.Substring(0, 32);

                // Convert the Cookie value to Guid

                 Guid contactid = Guid.Parse(cookieValue);
                
    

              

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
                            DateTime pastDateTime = currentDateTime.AddYears(-10);

                            //Find out if there are any interaction from past date

                            var results = client.Get<Sitecore.XConnect.Contact>(reference, new Sitecore.XConnect.ContactExpandOptions()
                            {
                                Interactions = new Sitecore.XConnect.RelatedInteractionsExpandOptions()
                                {
                                    StartDateTime = pastDateTime,
                                    EndDateTime = currentDateTime,

                                }
                            });

                            if (results == null)
                            {
                                return false;
                            }
                            else
                            {
                                List<Goal> goals = new List<Goal>();
                                foreach (var intercation in results.Interactions)
                                {
                                    goals.AddRange(intercation.Events.OfType<Goal>().Where(c => c.ItemId == this.PageGuid && c.DefinitionId == this.GoalGuid));                                 
                                }
                                return goals.Any();  
                            }

                        }
                    }

                }
            }

            return false;
        }

    }
}
