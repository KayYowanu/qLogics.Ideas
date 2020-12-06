"..\..\Kingdom\oqtane.package\nuget.exe" pack qLogics.Ideas.nuspec 
XCOPY "*.nupkg" "..\..\Kingdom\Oqtane.Server\wwwroot\Modules\" /Y
