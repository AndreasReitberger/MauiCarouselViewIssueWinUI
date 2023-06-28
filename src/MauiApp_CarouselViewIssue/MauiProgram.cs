﻿using AndreasReitberger.Shared.Hosting;
using MauiApp_CollectionViewIssue.Hosting;
using Microsoft.Extensions.Logging;

namespace MauiApp_CollectionViewIssue;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .InitializeSharedMauiStyles()
            .ConfigureApp()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
