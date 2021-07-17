var target = Argument("target", "Default");
var srcPath = Argument("srcPath", "");
var nuspecPath = Argument("nuspecPath", "");
var version = Argument("libraryVersion", "");
var output = Argument("nugetOutput", ".");

Task("Create-Nuget")
  	.Does(() =>
  	{
		NuGetPack(nuspecPath, new NuGetPackSettings
		{
			ArgumentCustomization = args => args
				.Append($"-p fileSrc={srcPath}"),
			Version = version,
			BasePath = ".",
			OutputDirectory = output,
			Verbosity = NuGetVerbosity.Detailed,
			Copyright = $"Copyright © Vestas {DateTime.UtcNow.Year}"
		});
	});

Task("Default")
  	.IsDependentOn("Create-Nuget");

RunTarget(target);