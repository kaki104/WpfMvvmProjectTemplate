using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfMvvm.Core.Extensions
{
    /// <summary>
    /// 커맨드 확장 메소드
    /// </summary>
    public static class CommandExtension
    {
        public static void NotifyCanExecuteChanged(this ICommand command)
        {
            if(command is RelayCommand relayCommand)
            {
                relayCommand.NotifyCanExecuteChanged();
            }
            if(command is AsyncRelayCommand asyncRelayCommand)
            {
                asyncRelayCommand.NotifyCanExecuteChanged();
            }
        }
    }
}
