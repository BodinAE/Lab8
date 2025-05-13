using Lab8.Data;
using Lab8.Model;
using System.Windows;

namespace Lab8.Windows
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        ApplicationContext _appContext;
        public Auth(ApplicationContext appContext)
        {
            _appContext = appContext;
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(LoginBox.Text) &&
                !String.IsNullOrWhiteSpace(PassBox.Text))
            {
                User? loginUser = _appContext.Users.FirstOrDefault(q => q.Login == LoginBox.Text &&
                                                                        q.Password == PassBox.Text);
                if (loginUser != null)
                {
                    DialogResult = true;
                    return;
                }
                else
                {
                    MessageBox.Show("Wrong credentials", "😡😡😡😡😡😡");
                }
            }
            else
            {
                MessageBox.Show("Empty fields", "😡😡😡😡😡😡");
            }
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            Reg reg = new Reg(_appContext);
            reg.ShowDialog();
            if (reg.DialogResult == true)
            {
                _appContext.Users.Add(reg.NewUser);
                _appContext.SaveChanges();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            return;
        }
    }
}
