using MySql.Data.MySqlClient;
using pr28savichev.Classes.Common;
using pr28savichev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr28savichev.Classes
{
    public class ClubsContext : Clubs
    {
        public ClubsContext(int Id, string Name, string Address, string WorkTime) : base(Id, Name, Address, WorkTime) { }
        public static List<ClubsContext> Select()
        {
            List<ClubsContext> AllClubs = new List<ClubsContext>();
            string SQL = "SELECT * FROM `Clubs`";
            MySqlConnection connection = Connection.OpenConnection();
            MySqlDataReader Data = Connection.Query(SQL, connection);
            while (Data.Read())
            {
                AllClubs.Add(new ClubsContext(
                    Data.GetInt32(0),
                    Data.GetString(1),
                    Data.GetString(2),
                    Data.GetString(3)));
            }
            Connection.CloseConnection(connection);
            return AllClubs;
        }

        public void Add()
        {
            string SQL = $"INSERT INTO `Clubs`(`Id`, `Name`, `Address`, `WorkTime`) VALUES ('{this.Id}','{this.Name}','{this.Address}','{this.WorkTime}')";
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Query(SQL, connection);
            Connection.CloseConnection(connection);
        }

        public void Update()
        {
            string SQL = $"UPDATE `Clubs` SET `Name`='{this.Name}',`Address`='{this.Address}',`WorkTime`='{this.WorkTime}' WHERE `Id`='{this.Id}'";
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Query(SQL, connection);
            Connection.CloseConnection(connection);
        }

        public void Delete()
        {

            string SQL = $"DELETE FROM `Clubs` WHERE `Id`='{this.Id}'";
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Query(SQL, connection);
            Connection.CloseConnection(connection);
        }
    }
}
