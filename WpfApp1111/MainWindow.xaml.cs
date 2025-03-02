using System;
using System.Linq;
using System.Windows;
using WpfApp1111.DatabaseContext;
using WpfApp1111.Entities;

namespace WpfApp1111
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ManageProjects_Click(object sender, RoutedEventArgs e)
        {
            var projectListWindow = new ProjectListWindow();
            projectListWindow.Show();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTb.Text;
            string password = PasswordPb.Password;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Логин не может быть пустым", "Ошибка");
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пароль не может быть пустым", "Ошибка");
                return;
            }

            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                var user = dbContext.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

                if (user != null)
                {
                    MessageBox.Show("Успешный вход", "Информация");

                    // Открываем окно управления проектами
                    ProjectListWindow projectListWindow = new ProjectListWindow();
                    projectListWindow.Show();

                    // Закрываем текущее окно авторизации
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль", "Ошибка");
                }
            }
        }


        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
        }
    }
}
