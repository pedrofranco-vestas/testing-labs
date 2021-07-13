var target = Argument("target", "Default");
var path = Argument("publishPath", "");
var version = Argument("libraryVersion", "");
var title = Argument("libraryTitle", "");
var description = Argument("libraryDescription", "");
var output = Argument("nugetOutput", ".");

Task("Create-Nuget")
  	.Does(() =>
  	{
		var targetPath = @"lib\net5.0";
		NuGetPack(new NuGetPackSettings
		{
			Id = "Vestas.Hello.World.Api",
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
					TargetFramework = "net5.0"
				}
			},
			Verbosity = NuGetVerbosity.Detailed,
			Copyright = $"Copyright © Vestas {DateTime.UtcNow.Year}"
		});
	});

Task("Default")
  	.IsDependentOn("Create-Nuget");

RunTarget(target);