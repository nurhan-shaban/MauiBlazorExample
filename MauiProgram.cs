using Microsoft.Extensions.Logging;
using Blazored.SessionStorage;
using MauiBlazorExample.Service;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace MauiBlazorExample;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

        var a = Assembly.GetExecutingAssembly();
        using var stream = a.GetManifestResourceStream("MauiBlazorExample.appsettings.json");

        var config = new ConfigurationBuilder()
            .AddJsonStream(stream)
            .Build();

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		builder.Services.AddBlazoredSessionStorage();
		builder.Configuration.AddConfiguration(config);

		var ipAddress = config.GetValue<string>("IpAddress");

		builder.Services.AddHttpClient<IReceiptService, ReceiptService>(x =>
		{
			//x.BaseAddress = new Uri("http://10.120.20.101:5006");
            x.BaseAddress = new Uri(ipAddress);
        });

        //return builder.Build();

        var app = builder.Build();

		Services = app.Services;

		return app;
    }

    public static IServiceProvider Services { get; private set; }
}
