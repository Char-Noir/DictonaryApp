using DictonaryApp.Helpers;
using DictonaryApp.Repositories;
using Microsoft.Extensions.Logging;


namespace DictonaryApp;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        string dbPath = FileAccessHelper.GetLocalFilePath("dictionaries.db3");
        builder.Services.AddSingleton<DictionaryRepository>(s => ActivatorUtilities.CreateInstance<DictionaryRepository>(s, dbPath));

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
