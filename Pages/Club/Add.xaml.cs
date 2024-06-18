using pr28savichev;
using pr28savichev.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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

namespace savichev28pr.Pages.Club
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        ClubsContext clubs;
        public Add(ClubsContext clubs = null)
        {
            InitializeComponent();

            if (clubs != null)
            {
                this.clubs = clubs;
                Name.Text = clubs.Name;
                Address.Text = clubs.Address;
                Time.Text = clubs.WorkTime;
                bthAdd.Content = "Изменить";
            }
        }

        private void AddRecord(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "")
            {
                MessageBox.Show("Не заполнено наименоваие");
                return;
            }
            if (Address.Text == "")
            {
                MessageBox.Show("Не заполнен адрес");
                return;
            }
            if (Time.Text == "")
            {
                MessageBox.Show("Не заполнено время работы");
                return;
            }

            if (this.clubs == null)
            {
                ClubsContext newClub = new ClubsContext(
                    0,
                    Name.Text,
                    Address.Text,
                    Time.Text);
                newClub.Add();
                MessageBox.Show("Запись успешно добавлена");
            }
            else
            {
                clubs = new ClubsContext(
                    clubs.Id,
                    Name.Text,
                    Address.Text,
                    Time.Text);

                clubs.Update();
                MessageBox.Show("Запись успешно обновлена");
            }
            MainWindow.init.OpenPage(new Pages.Club.Main());
        }
    }
}
