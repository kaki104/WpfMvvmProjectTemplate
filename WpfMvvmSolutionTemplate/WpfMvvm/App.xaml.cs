using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using $safeprojectname$.Core.Interfaces;
using $safeprojectname$.Core.Services;
using $safeprojectname$.ViewModels;

namespace $safeprojectname$
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public App()
        {
            Services = ConfigureServices();
        }
        /// <summary>
        /// Current 생성
        /// </summary>
        public new static App Current => (App)Application.Current;

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
        /// </summary>
        public IServiceProvider Services { get; private set; }

        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            //Singleton service 등록
            services.AddSingleton<IApplicationService, ApplicationService>();

            //viewmodel 등록
            services.AddTransient<MainViewModel>();
            services.AddTransient<SignViewModel>();
            services.AddTransient<RootViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
