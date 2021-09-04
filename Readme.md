# Markdown Monster Addin Registry

![](./MarkdownMonsterAddins_Icon.png)

### Publish your Markdown Monster Addins here
This repository is an Addin Registry for addins for the [Markdown Monster Markdown Editor for Windows](https://markdownmonster.west-wind.com) which is contained in `MarkdownMonsterAddinRegistry.json`.  Markdown Monster's addin manager accesses this file to display addin listings and then dynamically loads the individual addin information from their respective Github repositories.

This repository provides a list of available add-ins that are hosted via Git/Github and can be installed via the registry from within Markdown Monster via the [MarkdownMonsterAddinRegistry.json file](https://github.com/RickStrahl/MarkdownMonsterAddinsRegistry/blob/master/MarkdownMonsterAddinRegistry.json). You can publish your own add-ins that follow the addin guidelines in this document and publish it in this registry via pull request.

Right now the registry is pretty sparse as we are still working out the exact structure for addins, but a few add-ins have been added to get the ball rolling.

### The Addin Manager in Markdown Monster
Addins can be viewed and installed from Markdown Monster's Addin Manager accessible view **Tools -> Addin Manager**:

![](AddinRegistry.png)

The `MarkdownMonsterAddinRegistry.json` file in this repository drives the list in the Addin Manager, with additional lookups in the individual repos `version.json` to retrieve current version info.

### Initial Addins available

* **[Save Image to Azure Blob Storage](https://github.com/RickStrahl/SaveToAzureBlob-MarkdownMonster-Addin)**  
This addin allows you to open images from the file system or from the clipboard and post them to an Azure Blob Storage account. The result image URL is then embedded into the currently open editor document.

* **[Paste Code as Gist](https://github.com/RickStrahl/PasteCodeAsGist-MarkdownMonster-Addin)**  
Allows you to paste a block of code as a Github Gist into your Markdown document. Gists are created on Github via API and the resulting embedding link is embedded into the Markdown document.

### Creating your own Addin and Adding to the Registry
Markdown Monster is extensible and you can [create your own Addins](http://markdownmonster.west-wind.com/docs/_4ne0rl1zf.htm) and if you think it might have more general appeal you can publish your Addin in this registry.

To publish your Addin:

* Create your Addin as a Github Repository
* Create a unique Id for your Addin (camel cased name)
* Make sure you provide a `\Build` and `\Build\Distribution` folder
* Make sure required files are provided (addin.zip, icon.png, version.json)

Once your repo has been set up:

* Clone this repository
* Add your Addin to the `MarkdownMonsterAddinRegistry.json`
* Open a Pull Request on this repo

If your pull request is approved and merged the addin will show in the addin manager inside of Markdown Monster and will be downloaded and installed from the Git repo.

### Markdown Monster Addin Git Repository Guidelines
In order to submit a Markdown Monster addin to the repository here you need to use a Git repo and publish your addin with source code and a **very specific structure** for your `\Build` folder.

The structure of the repo **has to include** the following folder and structure:

```
\              
    \Build
        addin.zip         // zip of Distribution folder   
        icon.png          // Square 256x256 PNG logo for addin
        screenshot.png    // screenshot - try to keep the width under 1000px
        version.json      // version info
        \Distribution     // compiled Addin DLLs and version
            yourAddin.dll         // name *must* end in <addinName>Addin.dll
            <dependency dlls>
            version.json          // same  file as Build folder
    \src
        <source files>    // source files for your addin      
Readme.md 
```
The filenames in the the `\Build` folder are fixed (addin.zip, icon.png, screenshot.png, version.json).

The `Readme.md` file in the root should have information about your addin, what it does, any special steps needed to configure and any additional info required. When listed in the Addin Manager in Markdown Monster this is the page users are directed to to find out more about your addin.

The Distribution folder should look like this:

```
\Distribution
    yourAddin.dll         // name *must* end in <addinName>Addin.dll
    <dependency dlls)
    version.json          // same  file as Build folder
```

The `build\distribution` folder holds all files that to into the Zip file. When you build your final output for the addin you'll build to the `Build\Distribution` folder and then zip all those files up into `Build\addin.zip`. The `Distribution` folder including all DLLs should be checked in to Git so it's easy to see what this addin uses in the open.

### version.json
`version.json` holds version and descriptive information about your addin. This file is queried in the addin list and if more information is requested about the addin. This file should live both in the `Build` folder so the Addin Manager can read it on a public URL, and embedded in the .ZIP file for determining the current installed version of your addin.

Here's an example what `version.json` should contain:

```json
{
	"id": "SaveImageToAzureBlob",
	"name": "Save Image to Azure Blob",
	"summary": "Upload images from disk or the clipboard to Azure Blob Storage, and embed the resulting URL as an image link into the current document.",
	"description": null,
	"version": "0.12",
	"minVersion": "1.1.18",
	"author": "© Rick Strahl - West Wind Technologies",	
	"updated": "2016-12-19T12:12:40Z"
}
```
Here's what each of those keys means:

#### id
The unique ID for the addin. This will also be the `Addins\Foldername` that gets created in the Addins folder.

#### name
This is the display name for the addin which is shown in the registry.

#### summary
A short paragraph description of what the addin does. It should fit into 2-3 lines at most roughly under 200 character. Be concise and use the full **description** field for more detailed information about your addin.

#### description
Detailed information in your addin. You can be verbose here to outline features, operation and if necessary and configuration or settings that need to be made for this addin to run.

#### version
The version of your addin. This is the version that shows in the in the registry and is what's used to determine whether your addin requires updating. Please use sem ver style versioning (ie. major.minor.build where build is optional).

### minVersion
This is the Markdown Monster minimum version required to run your addin. As Markdown Monster changes over time the addin interface and what you can access through the addin may change and you don't want to allow your addin to run on versions that don't support it. If trying to install an add to MM with a lower version you'll get an error message to encourage updating to the latest version.

#### author
This should hold the name of the author and/or company and a copyright notice.

#### updated
Should reflect a valid JSON date. The format is ISO 8601 with UTC time. `2016-12-19T12:00:00Z`. We recommend you use 12:00:00Z for the  time portion of the date string.

### The Zip File
The zip file of your add-in should contain all binaries needed to run the add-in but most definitely **should not include** any assemblies that are already loaded by Markdown Monster. Make sure you turn **Copy Local** on any files that Markdown Monster ships.

### The Zip file
The Zip file basically should be all the files in the **Distribution** folder.

Markdown Monster's Addin Manager downloads this ZIP file from your repository and installs it in a folder below the `Addins` folder in Markdown Monster. The folder should be self-contained to run on its own except for potential dependencies already provided by Markdown Monster.

The following `build.ps1` (I put it in the `Build` folder) can automate creating the Zip file using 7zip (7z.exe/7z.exe also in [Build folder](https://github.com/RickStrahl/SaveToAzureBlob-MarkdownMonster-Addin/tree/master/Build)):

```powershell
cd "$PSScriptRoot" 

$src = "$env:appdata\Markdown Monster\Addins\SaveImageToAzureBlobStorage"

"Cleaning up build files..."
del addin.zip

remove-item -recurse -force .\Distribution
md Distribution

"Copying files..."
copy $src\*.dll .\Distribution
copy $src\version.json .\Distribution
copy $src\version.json .\

"Zipping up setup file..."
7z a -tzip  addin.zip .\Distribution\*.*
```

### Submitting to the Addin Registry 
Once you've created your repository you can submit your Addin to this registry:

* Fork this repository
* Update `MarkdownMonsterAddinRegistry.json` and add your Addin at the bottom
* Open a Pull Request and submit to the this repo

We'll review the entry and if accepted merge the pull request to get your add-in listed.

### Policy
Note that we reserve the right to refuse admission of any submission for any reason whatsoever, although we hope that that won't be necessary. The main concerns are copyright and security concerns so be aware of that.


### Feedback
If you have any problems or questions please [open an issue](https://github.com/RickStrahl/MarkdownMonsterAddinsRegistry/issues) on this repo so we can further discuss any addins related issues you might have.