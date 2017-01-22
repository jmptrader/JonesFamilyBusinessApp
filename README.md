# JonesFamilyBusinessApp
MVC Sample.
To run the project you MUST edit Web.config file, appSettings section with full path to dbfile (.mdf) and full path to logpath (.txt)
There is a mdf file to test in "JonesFamilyBusinessApp/Db/jonesdb.mdf".
Log file can be located anywhere
```xml
<appSettings>
  ...
  ...
  <add key="dbpath" value="Path_to_dbfile"/>
  <add key="logpath" value="Path_to_logfile"/>
</appSettings>
```
