using System.Windows;
using WpfMvvm.ViewModels;

namespace WpfMvvm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //뷰모델 입력
            DataContext = App.Current.Services.GetService(typeof(MainViewModel));
        }
    }
}
