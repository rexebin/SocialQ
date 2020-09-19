using System;
using Akavache;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using Serilog;
using Sextant;
using Shiny;
using SocialQ.Forms.Dialogs;
using SocialQ.Forms.Queue;
using SocialQ.Forms.Startup;
using SocialQ.Forms.Stores;
using SocialQ.Queue;
using SocialQ.Splash;
using SocialQ.Startup;
using Splat;
using Splat.Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;

namespace SocialQ.Forms
{
    public class SocialQStartup : ShinyStartup
    {
        public override void ConfigureServices(IServiceCollection services)
        {

            RxApp.DefaultExceptionHandler = new SocialQExceptionHandler();
            BlobCache.ApplicationName = $"{nameof(SocialQ)}";

            services.UseNotifications();
            services
                .AddSerilog(() => new LoggerConfiguration())
                .AddSextant()
                .AddAkavache()
                .RegisterForNavigation<MainPage, MainViewModel>()
                .RegisterForNavigation<Queues, QueuesViewModel>()
                .RegisterForNavigation<SplashPage, SplashViewModel>()
                .RegisterForNavigation<StoreSearch, StoreSearchViewModel>()
                .RegisterForNavigation<StoreDetail, StoreDetailViewModel>()
                .AddApiContracts(true)
                .AddApiClients()
                .AddDataServices()
                .AddSingleton(SignalRParameters.Client)
                .AddSingleton<IDialogs, MaterialDialogs>()
                .AddSingleton<ISettings, Settings>()
                .AddSingleton<IAppStartup, AppStartup>()
                .AddSingleton<IStartupTask, UserStartup>()
                .AddTransient<IStartupTask, NotificationAccessTask>()
                .UseMicrosoftDependencyResolver();
        }

        public static Page NavigateToStart<T>()
            where T : IViewModel
        {
           Locator.Current.GetService<IParameterViewStackService>().PushPage<T>(resetStack: true, animate: false).Subscribe();
            return (NavigationPage) Locator.Current.GetService<IView>();
        }
    }
}