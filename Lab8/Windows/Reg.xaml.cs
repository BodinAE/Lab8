using Lab8.Data;
using Lab8.Model;
using System.Windows;

namespace Lab8.Windows
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        public User NewUser {  get; set; }
        private ApplicationContext _appContext;
        public Reg(ApplicationContext appContext)
        {
            InitializeComponent();
            _appContext = appContext;
            RoleBox.ItemsSource = _appContext.Roles.ToList();
            RoleBox.SelectedIndex = 2;
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(LoginBox.Text) &&
                !String.IsNullOrWhiteSpace(PassBox.Text))
            {
                NewUser = new User()
                {
                    Login = LoginBox.Text,
                    Password = PassBox.Text,
                    Role = (Role)RoleBox.SelectedItem
                };
                DialogResult = true;
                return;
            }
            else
            {
                MessageBox.Show("Empty fields", "😨😨😨😨");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            return;
        }
    }
}
