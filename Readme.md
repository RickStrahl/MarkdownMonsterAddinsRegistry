# Markdown Monster Addin Registry
### Publish your Markdown Monster Addins here


> ### @icon-warning Under Construction
> The addin registry is not ready for accepting addins yet. We're still working out the logistics, but stay tuned for more info.

This repository holds a list of available addins for the Markdown Monster Markdown editor.

* [Markdown Monster Site](http://markdownmonster.west-wind.com)
* [Markdown Monster on GitHub](https://github.com/RickStrahl/MarkdownMonster)


This repository merely provides a list to available addins that are hosted via Git/Github and can be installed via the registry.

All addins registered have to either provide source code, or if a commercial addin need to be 

### Requirements for Listing
To get a Markdown Monster Addin listed you need to provide the following:

* GitHub Repository that follows the Addin Guidelines
* Add an entry to MarkdownMonsterAddins.json


### Markdown Monster Addin Repository Guidelines
In order to submit a Markdown Monster addin to the repository here you need to use a GitHub repo and publish your addin with source code. 

The structure of the repo has to include the following:

```
\lib
    YourAddin.dll
    Dependency1.dll
    Dependency2.dll
\src
   <whatever sourcefiles>
version.json
Readme.md (description and usage)
```

Version.json should contain:

```json
{
   "id"="<guid>",
   "name"="Greatest Addin",
   "version"="0.11"
   "released"=""
}   
```

### Policy
We reserve the right to refuse admission of an admin into the registry.