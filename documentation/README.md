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

1. Use the Sitecore Installation wizard to install the [package](#link-to-package)
2. ???
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

Provide documentation  about your module, how do the users use your module, where are things located, what do icons mean, are there any secret shortcuts etc.

Please include screenshots where necessary. You can add images to the `./images` folder and then link to them from your documentation:

![Hackathon Logo](images/hackathon.png?raw=true "Hackathon Logo")

You can embed images of different formats too:

![Deal With It](images/deal-with-it.gif?raw=true "Deal With It")

And you can embed external images too:

![Random](https://placeimg.com/480/240/any "Random")

## Video

Please provide a video highlighing your Hackathon module submission and provide a link to the video. Either a [direct link](https://www.youtube.com/watch?v=EpNhxW4pNKk) to the video, upload it to this documentation folder or maybe upload it to Youtube...

[![Sitecore Hackathon Video Embedding Alt Text](https://img.youtube.com/vi/EpNhxW4pNKk/0.jpg)](https://www.youtube.com/watch?v=EpNhxW4pNKk)
