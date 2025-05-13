using System.Windows;
using Lab8.Data;
using Lab8.Windows;

namespace Lab8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ApplicationContext _appContext;
        public MainWindow()
        {
            _appContext = new ApplicationContext();
            Auth auth = new Auth(_appContext);
            auth.ShowDialog();
            if (auth.DialogResult == true)
            {
                InitializeComponent();
                UserView.ItemsSource = _appContext.Users.ToList();
            }
            else
            {
                this.Close();
            }
        }
    }
}