var target = Argument("target", "Default");
var path = Argument("path", "");
var version = Argument("version", "");
var title = Argument("title", "");
var description = Argument("description", "");
var output = Argument("output", ".");

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
			Verbosity = NuGetVerbosity.Detailed,
			Copyright = $"Copyright © Vestas {DateTime.UtcNow.Year}"
		});
	});

Task("Default")
  	.IsDependentOn("Create-Nuget");

RunTarget(target);