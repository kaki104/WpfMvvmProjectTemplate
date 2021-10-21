using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using $safeprojectname$.Core;
using $safeprojectname$.Core.Bases;
using $safeprojectname$.Core.Extensions;
using $safeprojectname$.Core.Interfaces;
using $safeprojectname$.Core.Messages;

namespace $safeprojectname$.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        private string _navigateSource;
        /// <summary>
        /// 네비게이션 소스
        /// </summary>
        public string NavigateSource
        {
            get { return _navigateSource; }
            set { SetProperty(ref _navigateSource, value); }
        }
        /// <summary>
        /// 디자인타임 생성자
        /// </summary>
        public MainViewModel()
        {
        }

        /// <summary>
        /// Injection 생성자
        /// </summary>
        /// <param name="applicationService"></param>
        public MainViewModel(IApplicationService applicationService)
        {
            Init();
        }
        /// <summary>
        /// 초기화
        /// </summary>
        private void Init()
        {
            NavigateSource = "/Views/SignView.xaml";

            WeakReferenceMessenger.Default.Register<SigninChangedMessage>(this, 
                (sender, args) => 
                { 
                    if(args != null)
                    {
                        NavigateSource = "/Views/RootView.xaml";
                    }
                });
        }

    }
}
