# SearchFight
Programming challenge for Cignium Technologies. The application will query search engines for each entered term. The application will show the number of results by term and engine, the winners by engine and the total winner.

## Instructions
In order to use the application, just enter the terms you want to search with the different configured search engines. Term with spaces have to be between double quotes ("term").

```
C:\> searchfight.exe .net java
.net: Google: 4450000000 MSN Search: 12354420
java: Google: 966000000 MSN Search: 94381485
Google winner: .net
MSN Search winner: java
Total winner: .net
```

## Configuration
If you want to add or change any configured search engine, you have to edit the App.config file following these instructions:

```
<add engineName="MyEngine"
     engineURL="https://www.myengine.com/search?q={0}"
     engineRegexPattern="&lt;span class=&quot;important_tag&quot;&gt;(.*?) results&lt;/span&gt;"/>
```
- Web scraping is used on the general search engine URL and a Regex pattern of the element that holds the number of results.
- You can change the configuration of search engines without needing to compile the application again (and adding more code or classes).
- No API keys needed!

## Prerequisites
- Visual Studio
- .NET Framework 4.6.1

## Deployment
Just compile it and use it directly with the *.exe file generated.


