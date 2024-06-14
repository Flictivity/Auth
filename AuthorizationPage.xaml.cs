using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DemoIlyas.Pages
{
    /// <summary>
    /// Interaction logic for AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbLogin.Text))
            {
                MessageBox.Show("Логин не может быть пустым!", "Ошибка!");
                return;
            }

            if (string.IsNullOrEmpty(pbPassword.Password))
            {
                MessageBox.Show("Пароль не может быть пустым!", "Ошибка!");
                return;
            }

            var user = App.Connection.User.FirstOrDefault(x => x.Login == tbLogin.Text);

            if (user == null)
            {
                MessageBox.Show("Пользователя с таким логином не существует!", "Ошибка!");
                return;
            }

            if (user.Password != pbPassword.Password)
            {
                MessageBox.Show("Неверный пароль!", "Ошибка!");
                return;
            }

            App.CurrentUser = user;

            if (App.CurrentUser.RoleId == 3)
            {
                NavigationService.Navigate(new RequestsPage());
            }
        }
    }
}
