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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace savichev28pr.Pages.Users.Items
{
    public partial class Item : UserControl
    {
        UsersContext user;
        Main main;
        public Item(UsersContext user, Main main)
        {
            InitializeComponent();
            FIO.Text = user.FIO;
            RentDate.Text = user.RentStart.ToString();
            Duration.Text = user.Duration.ToString();
            this.user = user;
            this.main = main;
        }

        private void EditRecord(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPage(new Pages.Users.Add(this.user));
        }

        private void DeleteRecord(object sender, RoutedEventArgs e)
        {
            user.Delete();
            main.parent.Children.Remove(this);
        }
    }
}
