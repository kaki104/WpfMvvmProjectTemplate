using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using $safeprojectname$.Interfaces;

namespace $safeprojectname$.Bases
{
    /// <summary>
    /// 뷰모델 베이스
    /// </summary>
    public abstract class ViewModelBase : ObservableObject, IViewModelBase
    {
        private string _title;
        /// <summary>
        /// 타이틀
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
    }
}
