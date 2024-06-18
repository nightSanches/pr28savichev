using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr28savichev.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string RentStart { get; set; }
        public int Duration { get; set; }

        public Users(int Id, string FIO, string RentStart, int Duration)
        {
            this.Id = Id;
            this.FIO = FIO;
            this.RentStart = RentStart;
            this.Duration = Duration;
        }
    }
}
