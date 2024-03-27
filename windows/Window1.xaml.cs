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
using WpfApp52_практика.windows.classes;

namespace WpfApp52_практика.windows
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow reg = new MainWindow();
            reg.Show();
            this.Hide();

            var Login = LoginBox.Text;
            var pass = PasswordBox.Text;
            var Email = EmailBox;
            var povtor = PovtorBox.Text; 
            var context = new AppDbContext();

            var user_exist = context .Users.FirstOrDefault(x => x.Login == Login);
            if (user_exist is not null)
            {
                MessageBox.Show ("Такой пользователь уже зарегистрирован");
                return;
            }
            var user = new User { Login = Login, Password = pass };
            context.Users.Add(user);
            context.SaveChanges();
            MessageBox.Show("Welcome to the club, buddy)))");
        }
        

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);    
        }
    }
}
