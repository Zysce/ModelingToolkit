using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using ModelingToolkit.Components;

namespace ModelingToolkit;

public static class Program
{
	public static void Main(string[] args)
	{
		BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
	}

	public static AppBuilder BuildAvaloniaApp()
		=> AppBuilder.Configure<App>()
			.UsePlatformDetect()
			.LogToTrace()
			.UseSkia();
}
