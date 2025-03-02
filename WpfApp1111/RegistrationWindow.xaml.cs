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
using System.Windows.Shapes;
using WpfApp1111.DatabaseContext;
using WpfApp1111.Entities;

namespace WpfApp1111
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
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
                bool isUsernameAlreadyExist = dbContext.Users.Any(u => u.Username == username);
                if (isUsernameAlreadyExist)
                {
                    MessageBox.Show("Пользователь с таким логином уже существует", "Ошибка");
                    return;
                }

                User user = new User
                {
                    Username = username,
                    Password = password
                };

                dbContext.Users.Add(user);
                dbContext.SaveChanges();

                MessageBox.Show("Пользователь успешно зарегистрирован", "Успех");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }
    }
}
