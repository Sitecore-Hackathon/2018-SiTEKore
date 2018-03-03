# Documentation

## Summary

**Category:** XConnect

The purpose of this module is to add extended personalisation rules based on Experience Database data:
- Do a personalization based on Goals Triggered on a specific page
- Do a personalization on anonymous visit when users can be identified by his cookie

## Pre-requisites

Does your module rely on other Sitecore modules or frameworks?

- Sitecore Helix running on Sitecore 9.0 Update 1 (Optional. Required for a demo)

## Installation

Two ways of installation:

**I. Using Visual Studio** 
1. Open solution Hackathon.Boilerplate.sln
2. Edit gulp-config.js file
3. Edit publishsettings.targets file
4. Run Default taskin Task Runner Explorer

**Using Sitecore Package**

1. Use the Sitecore Installation wizard to install the [package](#https://drive.google.com/open?id=12Nvm1Y0GR59S3ku1X-lTqdvPnKnszDak)
2. ![Add TEKconnect Rule to Conditional Renderings](images/doc2.png?raw=true "Add TEKconnect Rule to Conditional Renderings")
    1. Open /sitecore/system/Settings/Rules in Content Editor
    2. Navigate to Conditional Renderings
    3. Navigate to Tags/Default
    4. In Tags Field Select XConnect -TEKConditions
    4.Save
3. Profit

## Configuration

How do you configure your module once it is installed? Are there items that need to be updated with settings, or maybe config files need to have keys updated?

Remember you are using Markdown, you can provide code samples too:

```xml
<?xml version="1.0"?>
<!--
  Purpose: Configuration settings for my hackathon module
-->
<configuration xmlns:patch="http://www.sitecore.net/xmlconfig/">
  <sitecore>
    <settings>
      <setting name="MyModule.Setting" value="Hackathon" />
    </settings>
  </sitecore>
</configuration>
```

## Usage
1. Create new Goal
2. Deploy new Goal
3. Open a page in Experience Editor
4. Personalize component 
5. Add a rule
![Add TEKconnect Rule](images/doc1.png?raw=true "Add TEKconnect Rule")
    1. Scroll down to TEKonnect Rules Group
    2. Click on Rule - where the sepcific goal was triggered and where the specific  page has been visited
    3. Select goal
    4. Select page
    5. Click OK 

## Video

[![Sitecore Hackathon Video Embedding Alt Text](https://img.youtube.com/vi/q9eGsaBv58U/0.jpg)](https://youtu.be/q9eGsaBv58U)
