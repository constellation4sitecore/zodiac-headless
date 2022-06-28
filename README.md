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
6. Install the Sitecore Management Services package for Sitecore 10.2 (v4.2.1 at time of writing)
	https://doc.sitecore.com/xp/en/developers/102/developer-tools/sitecore-management-services.html
7. Install the Sitecore Command Line Interface for Sitecore 10.2
	https://doc.sitecore.com/xp/en/developers/102/developer-tools/install-sitecore-command-line-interface.html
8. Modify the secret stored in your Solution's [solution root]\Sitecore.IdentityServer.DevEx.xml file.
9. Copy your Solution's Sitecore.IdentityServer.DevEx.xml file to your target CM's Identity Server's /config folder.


At this point you should be able to log into Sitecore 

## Configure your Sitecore Environment to support this solution

1. Copy the [solution root]\_CM\Website\App_Config\AppSettings.config file to the /App_Config folder on your target CM.
2. In your Visual Studio solution, Adjust the settings in this authentication config file:
	_CM\Website\App_Config\Include\Sitecore.Owin.Authentication.ClientCredentialsMapping.config 
	Match the Client ID	and Secret values you posted to the Identity server in the Sitecore.IdentitiServer.DevEx.xml file above.
3. Adjust the settings in your AppSettings.config to match your environment (role, env variables)
4. Copy the CM/Website/App_Config/Inclue/Project/ExampleSiteSettings folder and name the copy after your first site in this installation.
5. In the folder you just copied, Find "Example.Site.config.disabled". Rename the file "[YourSiteName].Site.config".
6. In your newly created site config file, ensure all instances of the string "ExampleSite" are replaced with [YourSiteName].
7. In your new site config file, ensure the TargetHost and HostName attribute values are correct for your local installation 
	and any other environments required by your development operations.
3. For the CM/Website project, Create Publish Settings to target your Sitecore CM installation. This solution comes with a LocalIISFolder 
	Publish Profile you can modify, or create your own.