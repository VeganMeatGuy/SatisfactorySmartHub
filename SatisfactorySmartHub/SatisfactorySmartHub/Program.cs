using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SatisfactorySmartHub.Extensions;
using SatisfactorySmartHub.Presentation;
using System;

namespace SatisfactorySmartHub;

internal sealed class Program
{
    private static IServiceProvider? s_serviceProvider;

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        IHost host = CreateApplicationHost();
        s_serviceProvider = host.Services;


        //AppDomain.CurrentDomain.UnhandledException += (s, e) => OnUnhandledException(e);

        GetService<App>().Run();
    }

    public static T GetService<T>()
        => s_serviceProvider?.GetRequiredService(typeof(T)) is not T service
        ? throw new ArgumentException($"{typeof(T)} needs to be a registered service.")
        : service;

    private static IHost CreateApplicationHost()
        => Host.CreateDefaultBuilder().ConfigureServices((context, services)
            => services.RegisterServices(context.Configuration, context.HostingEnvironment)).Build();

    //private static void OnUnhandledException(UnhandledExceptionEventArgs args)
    //    => s_loggerService?.Log(LogCritical, args.ExceptionObject as Exception);
}
