# Markdown Monster Addin Registry

![](./MarkdownMonsterAddins_Icon.png)

### Publish your Markdown Monster Addins here

> ### Under Construction
> The addin registry is not ready for accepting addins yet. We're still working out the logistics, but stay tuned for more info. In the meantime this document, has an outline of current thinking. If you have comments or ideas please file an [Issue](https://github.com/RickStrahl/MarkdownMonsterAddinsRegistry/issues)

This repository holds a list of available addins for the Markdown Monster Markdown editor.

* [Markdown Monster Site](http://markdownmonster.west-wind.com)
* [Markdown Monster on GitHub](https://github.com/RickStrahl/MarkdownMonster)

This repository merely provides a list to available addins that are hosted via Git/Github and can be installed via the registry.

All addins registered have to either provide source code in a GitHub repository, or if a commercial addin, need to be officially approved by contacting 

### Requirements for Listing
To get a Markdown Monster Addin listed you need to provide the following:

* GitHub Repository that follows the Addin Guidelines
* Add an entry to MarkdownMonsterAddins.json


### Markdown Monster Addin Repository Guidelines
In order to submit a Markdown Monster addin to the repository here you need to use a GitHub repo and publish your addin with source code. 

The structure of the repo **has to include the following folder and structure:

```
\build
    addin.zip   // use your name that should match the Id
    icon.png  
    version.json

readme.md 
```

### The Zip File
The zip file of your addin should contain all binaries needed to run the addin. This will be your compiled DLL plus any dependencies **that are not part of Markdown Monster**.

Version.json should contain:

```json
{
    "id":SaveImageToAzureBlob",
	"name": "Save Image to Azure Blob",
	// in the build folder
	"download": "SaveImageToAzureBlob-MarkdownMonster-Addin.zip",
	// single paragraph, keep short and precise
	"description": "Allows uploading of images from disk or the clipboard to Azure Blob Storage, and embedding the resulting URL as an image link into the current document."
	"longDescription": "...",
	"icon": "AddIn.png",
	"version": "0.05",
	"author": "Rick Strahl - West Wind Technologies",	
	"updated": "2016-12-5T01:00:00Z"
}  
```

### Submitting to the Registry
* Create your addin and make sure you follow the Guidelines
* Fork this repository
* Update `MarkdownMonsterAddinRegistry.json` and add your Addin at the bottom
* Create a Pull Request and submit to the this repo

We'll review the entry and if accepted merge the pull request to get your add-in listed.

### Policy
We reserve the right to refuse admission of any submission.