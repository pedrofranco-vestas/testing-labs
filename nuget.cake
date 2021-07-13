var target = Argument("target", "Default");
var path = Argument("publishPath", "");
var version = Argument("libraryVersion", "");
var title = Argument("libraryTitle", "");
var description = Argument("libraryDescription", "");
var output = Argument("nugetOutput", ".");

Task("Create-Nuget")
  	.Does(() =>
  	{
		var targetPath = @"lib\netcoreapp3.1";
		NuGetPack(new NuGetPackSettings
		{
			Id = $"Vestas.LoggingService.Presentation.Api",
			Version = version,
			Authors = new [] { "Vestas", "Internal Tools Team" }, 
			Owners = new [] { "Vestas", "Internal Tools Team" }, 
			Title = title,
			Description = description, 
			BasePath = path,
			OutputDirectory = output,
			Files = new [] 
			{
				new NuSpecContent
				{
					Source = "**",
					Target = targetPath
				}
			},
			Dependencies = new []
			{
				new NuSpecDependency
				{
					TargetFramework = ".NETCoreApp3.1"
				}
			},
			Verbosity = NuGetVerbosity.Detailed,
			Copyright = $"Copyright © Vestas {DateTime.UtcNow.Year}"
		});
	});

Task("Default")
  	.IsDependentOn("Create-Nuget");

RunTarget(target);