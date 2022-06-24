# zodiac-headless
## A Sitecore 10.2 + starter kit using the .NET 6 Rendering Host

#What's in the Box
This is a "complete" Visual Studio solution that you can fork/clone and use as the basis of your net-new Sitecore implementation project.

Solution Includes
- an ASP.NET 5.24/.NET 4.8 Web Application project that targets your "headless" CM server
- a .NET 6 Web Application project that targets your Rendering Host environment

CM Specific Features
- Helix-compatible Information Architecture for Foundation, Feature, Project, Tenant, and Site management.
- Base "page" Data Templates with setups for SEO, OpenGraph, Twitter, and Robots meta tags.
- Base "page fragment" Data Templates and an information architecture that is enforced via "Item Saved" rules.
- An information architecture framework for "site wide" navigation, breadcrumbs and dynamic "site section" navigation.
- An information architecture for "static labels" - domain specific words that need to be translated.
- Url-friendly Item names enforced by "Item Saved" rules.
- Sort Items alphabetically in a configurable folder structure using "Item Saved" rules.
- Sort Items by date in a configurable folder structure using "Item Saved" rules.
- Drop-in 301/302 redirect management, including import/export from .csv files.


Rendering Host Specific Features
- Helix-compatible solution structure
- Implemenation of common SEO, OpenGraph, Twitter, and Robots meta tags.
- Repositories and example implementation of static navigation, breadcrumbs, and section navigation components.
- 301/302 redirects
- Dynamic Robots.txt
- Dynamic Sitemap.xml
- Multi-language implementation
- Multi-Site implementation
- Experience Editor/Sitecore Pages support
- GraphQL query and results cache
- IIS Output Cache compatibility via cache headers
- CDN compatibility via cache headers
- Application version-based cache busting for static assets


# Getting Started

## Install Sitecore
You need a Sitecore XM installation that will be the publishing target for the CM/Website project. 

1. Install Sitecore 10.2 in XM only mode. We recommmend using SIA. Note that the default SIA XM package will install a CM and a CD instance. You can delete the CD instance.
2. Log into your new Sitecore install.
3. Populate the Solr Managed Schema.
4. Rebuild all Solr indexes (master, core, web)
5. Install the Sitecore Headless Services package for Sitecore 10.2 (v19 at time of writing)

## Configure your Sitecore Environment to support this solution

1. Copy the CM/Website/App_Config/AppSettings.config file to your Sitecore CM installation.
2. Adjust the settings in your AppSettings.config to match your environment (role, env variables)
3. Create Publish Settings to target your Sitecore CM installation. This solution comes with a LocalIISFolder Publish Profile you can modify, or create your own.