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
    public class UsersContext : Users
    {
        public UsersContext(int Id, string FIO, string RentStart, int Duration) : base(Id, FIO, RentStart, Duration) { }
        public static List<UsersContext> Select()
        {
            List<UsersContext> AllUsers = new List<UsersContext>();
            string SQL = "SELECT * FROM `Users`";
            MySqlConnection connection = Connection.OpenConnection();
            MySqlDataReader Data = Connection.Query(SQL, connection);
            while (Data.Read())
            {
                AllUsers.Add(new UsersContext(
                    Data.GetInt32(0),
                    Data.GetString(1),
                    Data.GetString(2),
                    Data.GetInt32(3)));
            }
            Connection.CloseConnection(connection);
            return AllUsers;
        }

        public void Add()
        {
            string SQL = $"INSERT INTO `Users`(`Id`, `FIO`, `RentStart`, `Duration`) VALUES ('{this.Id}','{this.FIO}','{this.RentStart}','{this.Duration}')";
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Query(SQL, connection);
            Connection.CloseConnection(connection);
        }

        public void Update()
        {
            string SQL = $"UPDATE `Users` SET `FIO`='{this.FIO}',`RentStart`='{this.RentStart}',`Duration`='{this.Duration}' WHERE `Id`='{this.Id}'";
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Query(SQL, connection);
            Connection.CloseConnection(connection);
        }

        public void Delete()
        {

            string SQL = $"DELETE FROM `Users` WHERE `Id`='{this.Id}'";
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Query(SQL, connection);
            Connection.CloseConnection(connection);
        }
    }
}
