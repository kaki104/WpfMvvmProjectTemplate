using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using $safeprojectname$.ViewModels;

namespace $safeprojectname$.Views
{
    /// <summary>
    /// Interaction logic for SignView.xaml
    /// </summary>
    public partial class SignView : Page
    {
        public SignView()
        {
            InitializeComponent();

            //뷰모델 입력
            DataContext = App.Current.Services.GetService(typeof(SignViewModel));

        }
    }
}
