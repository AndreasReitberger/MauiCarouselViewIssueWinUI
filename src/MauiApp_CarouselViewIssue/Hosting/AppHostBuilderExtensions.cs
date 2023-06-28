using MauiApp_CollectionViewIssue.ViewModels;

namespace MauiApp_CollectionViewIssue.Hosting
{
    public static class AppHostBuilderExtensions
    {
        /*
        * The view models do not inherit from an interface, so they only need their concrete type provided to the AddSingleton<T> and AddTransient<T> methods.
        */
        public static MauiAppBuilder ConfigureApp(this MauiAppBuilder builder)
        {
            builder
                .RegisterDispatcher()
                .RegisterMainViewModels()
                .RegisterMainViews()
            ;
            return builder;
        }

    /// <summary>
    /// Registers the main view models as Singleton.
    /// https://learn.microsoft.com/en-us/dotnet/architecture/maui/dependency-injection
    /// </summary>
    /// <param name="builder"></param>
    /// <returns>MauiAppBuilder</returns>
    public static MauiAppBuilder RegisterMainViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<PageViewModel>();
        return builder;
    }
    public static MauiAppBuilder RegisterMainViews(this MauiAppBuilder builder)
    {
        // Example: https://github.com/microsoft/dotnet-podcasts/blob/main/src/Mobile/Pages/PagesExtensions.cs
        // Loading
        // Main view
        builder.Services.AddSingleton<MainPage>();
        return builder;
    }
    public static MauiAppBuilder RegisterDispatcher(this MauiAppBuilder builder)
    {
        // Example: https://github.com/jamesmontemagno/ToolkitMessenger/blob/master/MauiApp2/MauiProgram.cs
        //builder.Services.AddSingleton<IDispatcherProvider>(DispatcherProvider.Current);
        builder.Services.AddSingleton<IDispatcher>(Dispatcher.GetForCurrentThread());
        return builder;
    }
}
}
