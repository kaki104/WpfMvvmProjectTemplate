using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
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
    public class SignViewModel : ViewModelBase
    {
        private readonly IApplicationService _applicationService;
        /// <summary>
        /// 패스워드 채인지 커맨드
        /// </summary>
        public ICommand TextChangedCommand { get; set; }
        /// <summary>
        /// 사이인 커맨드
        /// </summary>
        public ICommand SigninCommand { get; set; }
        /// <summary>
        /// 취소 커맨드
        /// </summary>
        public ICommand CancelCommand { get; set; }

        private string _id;
        /// <summary>
        /// Id
        /// </summary>
        public string Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private SecureString _password;

        /// <summary>
        /// Password
        /// </summary>
        public SecureString Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public SignViewModel()
        {

        }

        public SignViewModel(IApplicationService applicationService)
        {
            _applicationService = applicationService;

            Init();
        }

        private void Init()
        {
            TextChangedCommand = new RelayCommand<object>(OnTextChanged);
            SigninCommand = new AsyncRelayCommand(OnSigninAsync,
                () => string.IsNullOrEmpty(Id) == false
                    && Password != null && Password.Length > 0);
            CancelCommand = new RelayCommand(OnCancel);

        }

        /// <summary>
        /// 취소
        /// </summary>
        private void OnCancel()
        {
            var result = MessageBox.Show("종료하시겠습니까?", "확인", MessageBoxButton.YesNo);
            if (result != MessageBoxResult.Yes) return;
            App.Current.Shutdown();
        }

        /// <summary>
        /// 사인인
        /// </summary>
        /// <returns></returns>
        private async Task OnSigninAsync()
        {
            await Task.Delay(1000);
            var user = new Person
            {
                Id = Id,
                Name = "kaki104",
                Sex = true,
                Description = "kaki104.tistory.com project template"
            };
            _applicationService.SetSigninUser(user);
            MessageBox.Show("로그인 완료");
            WeakReferenceMessenger.Default.Send(new SigninChangedMessage(user));
        }
        /// <summary>
        /// 패스워드 체인지 
        /// </summary>
        /// <param name="obj"></param>
        private void OnTextChanged(object obj)
        {
            Password = obj as SecureString;
            SigninCommand.NotifyCanExecuteChanged();
        }
    }
}
