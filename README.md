# zodiac-headless
## A Sitecore 10.2 + starter kit using the .NET 6 Rendering Host

# What's in the Box
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

## Install the Sitecore Module Explorer
The Sitecore Module Explorer is a Visual Studio plugin that allows you to serialize and deploy Items between Sitecore installs and as part of your DevOps process.

- Download the installer from https://www.teamdevelopmentforsitecore.com/Download/SVS
- Install into your VisualStudio 2022 setup.
- You can access the Sitecore Module Explorer in Visual Studio by clicking on View > Other Windows... > Sitecore Module Explorer.

The plugin will not do anything unless you have a few key files in your Solution folder... We'll get to that in the next phase.

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
8. Modify the secret stored in your Solution's `[solution root]\Sitecore.IdentityServer.DevEx.xml` file.
9. Copy your Solution's `Sitecore.IdentityServer.DevEx.xml` file to your target CM's Identity Server's `/config` folder.


At this point you should be able to log into Sitecore 

## Configure your Sitecore Environment to support this solution

1. Copy the `[solution root]\_CM\Website\App_Config\AppSettings.config` file to the `/App_Config` folder on your target CM.
2. In your Visual Studio solution, Adjust the settings in this authentication config file:
	`_CM\Website\App_Config\Include\Sitecore.Owin.Authentication.ClientCredentialsMapping.config`
	Match the Client ID	and Secret values you posted to the Identity server in the `Sitecore.IdentitiServer.DevEx.xml` file above.
3. Adjust the settings in your `AppSettings.config` to match your environment (role, env variables)
4. Copy the `CM/Website/App_Config/Inclue/Project/ExampleSiteSettings` folder and name the copy after your first site in this installation.
5. In the folder you just copied, Find `Example.Site.config.disabled`. Rename the file `[YourSiteName].Site.config`.
6. In your newly created site config file, ensure all instances of the string `ExampleSite` are replaced with `[YourSiteName]`.
7. In your new site config file, ensure the `TargetHost` and `HostName` attribute values are correct for your local installation 
	and any other environments required by your development operations.
8. For the _CM/Website project, Create Publish Settings to target your Sitecore CM installation. This solution comes with a LocalIISFolder 
	Publish Profile you can modify, or create your own.
9. Publish the _CM\Website project to your local Sitecore CM environment.
10. Open a browser and log into your CM Sitecore instance to silently install the Constellation modules and verify your installation works.
11. Open up an Administrator Powershell window, navigate to your project folder, and type: 
	`dotnet sitecore login --authority https://<Sitecore identity server> --cm http://<sitecore instance> --allow-write true --client-credentials true --client-id <client id> --client-secret <client secret>''
	This will log you into Sitecore from the command line as well as create a user.json file in the .sitecore folder that will hold your credentials.
	As long as that file is present in your working copy folder, you will not have to re-authenticate.
`dotnet sitecore publish`. You should get several
	responses, the last one being "Publish to [Internet(web)] Complete"

At this point, you have a valid development environment.

# Creating your First Feature Project

There are quite a few steps to go through to create a Feature project that has Items and Renderings within it.

1. In the Feature folder in your solution, select *Add New Project*.
2. For Project Type, select *Razor Class Library*.
3. Name your project, preferably starting with "Feature.". Select the folder to store the project within, normally the Solution Root. 
4. Select *.NET 6* as the target framework.
5. Don't forget to check the box that says "Support Pages and Views".

## Your project is now created, but requires some references.

1. Right-click on your new Feature project in Solution Explorer and choose Manage NuGet packages.
2. TODO: see if we actually need this. From the Nuget.org repository, add "System.Reactive (5.0.0)"
3. From the Sitecore repository, add "Sitecore.AspNet.RenderingEngine (20.0.0)"
4. From the Sitecore repository, add "Sitecore.AspNet.ExperienceEditor (20.0.0)"
5. From the Sitecore repository, add "Sitecore.LayoutService.Client (20.0.0)"
6. (Optional) Add the GraphQL library of your choice
7. (Optional) TODO: add some sort of logging/error management tool reference
8. Delete the example Area and all child objects from the project.
9. Create a new Area folder named after your Feature's namespace (ex: "Feature.Content" becomes "Feature_Content")
10. Create a Views folder in your Area.
11. Create a Layouts folder in your Area if your Feature requires a Layout.
12. Create a Renderings folder to house your Rendering Views.


## Add a Sitecore Module to your project to serialize Items that are needed by your Feature.

1. Open the Sitecore Module Explorer in Visual Studio by clicking on View > Other Windows... > Sitecore Module Explorer.
2. You should see "Sitecore COnfiguration Root" and a few child nodes, including Modules, Environments, and Plugins.
3. Right click on Modules and choose "New Module".
4. Name the Module after your Feature (ex: "Feature.Content")
5. Specify the location on disk where you want your Items to be stored. We recommend using the same folder as the Feature Project.
6. Click OK and you'll get a new node under Modules in the Sitecore Module Explorer.

### A note about Glob locations:

The sitecore.json file in your solution includes a field named "Module Globs". This is a list of paths that the Module Explorer will crawl looking
for *.module.js files. By default in a Zodiac solution, we have specified a path of `./*/*.module.json`, which works if you follow our practice of having
a shallow Solution folder structure, with most projects being hosted a same-named folder immediately off the root of the Solution. If you choose
to have further folders in your file system for classification (hint: If you like clicking, be my guest.) you'll have to add another "glob" variable to help the
Module Explorer find your globs.

## Create your Templates, Layouts, Placeholders, etc.

Now is a good time to use your local Sitecore instance to design the Feature's Items:

- Templates & Fields
- Standard Values
- Placeholder Settings
- Layouts
- Renderings
- "Static" or "mandatory" folders or Items

## Populate your Module with serialized Items.

1. Right click your module name in the Sitecore Module Explorer and choose "Add Include". This feature works similarly to the Package Designer inside Sitecore.
We recommend creating one Include per mechanical aspect of Sitecore: Templates, Branches, Renderings, Layouts, Placeholder Settings and Content.
2. Specify the "name" of this include as it will appear in the Module Explorer. We recommend naming it after the semantically relevant part of Sitecore
(ex: Templates, Layouts, Renderings, Content, etc.) Note that the name must not contain spaces or the system will not create your Include, and will
not explain why it did not get created.
3. Specify the path to the top Item in a given branch of the Content Tree (we recommend copy+paste from the QuickInfo section in Content Editor).
4. Specify the maximum relative path length - WARNING if you set this to a value shorter than the name of the Item you're trying to import, 
you will get cryptic errors. It is strongly recommended that you set this to a forgiving length of 100 characters, which matches Sitecore's
default Item Name length restriction.
5. Specify the database. (ex: Settings, Templates, Layouts, etc come from the "master" database).
6. Specify the "scope" of serialization, whether the children/descendants are included in the serialization call, etc. 
7. Specify the deployment strategy.
8. Click OK.
9. Select your Module in the Module Explorer. 
10. Right-click and choose "Pull Items for this Module".
11. A "sync" window will appear with the Items you have in Sitecore.
12. Click the checkbox next to each Item you want to serialize for each of the Includes you've defined for your module.
13. When you have completed your selection, click the sync button in the lower right. The sync window should now display no Items. the Solution Explorer
should include your serialized Items.
