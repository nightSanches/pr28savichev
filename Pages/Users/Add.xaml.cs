using pr28savichev;
using pr28savichev.Classes;
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

namespace savichev28pr.Pages.Users
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        UsersContext users;
        public Add(UsersContext users = null)
        {
            InitializeComponent();
            if (users != null)
            {
                this.users = users;
                FIO.Text = users.FIO;
                RentDate.Text = users.RentStart.ToString();
                Duration.Text = users.Duration.ToString();
                bthAdd.Content = "Изменить";
            }
        }

        private void AddRecord(object sender, RoutedEventArgs e)
        {
            if (FIO.Text == "")
            {
                MessageBox.Show("Не заполнено ФИО");
                return;
            }
            if (RentDate.Text == "")
            {
                MessageBox.Show("Не заполнена дата аренды");
                return;
            }
            if (Duration.Text == "")
            {
                MessageBox.Show("Не заполнена продолжительность аренды");
                return;
            }
            
            if(this.users == null)
            {
                UsersContext newUser = new UsersContext(
                    0,
                    FIO.Text,
                    RentDate.Text,
                    Convert.ToInt32(Duration.Text));
                newUser.Add();
                MessageBox.Show("Запись успешно добавлена");
            }
            else
            {
                users = new UsersContext(
                    users.Id,
                    FIO.Text,
                    RentDate.Text,
                    Convert.ToInt32(Duration.Text));
                users.Update();
                MessageBox.Show("Запись успешно обновлена");
            }
            MainWindow.init.OpenPage(new Pages.Users.Main());
        }
    }
}
