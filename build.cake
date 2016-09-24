var target = Argument("target", "Default");
var configuration = Argument("configuration", "Debug");


Task("Restore-NuGet-Packages")
    .Does(() =>
{
    NuGetRestore("./LoginItemTest.sln");
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
	  .Does (() =>
{
	DotNetBuild("./LoginItemTest.sln", c => c.Configuration = configuration);
});

Task("Artefacts")
    .IsDependentOn("Build")
	  .Does (() =>
{
	CleanDirectories("./Artefacts");
    CopyDirectory("./LoginItemTestMain/bin/" + configuration + "/LoginItemTestMain.app", "./Artefacts/LoginItemTestMain.app");
    CopyDirectory("./LoginItemTestHelper/bin/" + configuration + "/LoginItemTestHelper.app", "./Artefacts/LoginItemTestMain.app/Contents/Library/LoginItems/LoginItemTestHelper.app");
});

Task("Default")
    .IsDependentOn("Artefacts");

RunTarget (target);