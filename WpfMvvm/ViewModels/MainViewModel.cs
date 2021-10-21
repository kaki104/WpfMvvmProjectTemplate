using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMvvm.Core;
using WpfMvvm.Core.Bases;
using WpfMvvm.Core.Extensions;
using WpfMvvm.Core.Interfaces;
using WpfMvvm.Core.Messages;

namespace WpfMvvm.ViewModels
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
