﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr28savichev.Models
{
    public class Clubs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string WorkTime { get; set; }
        public Clubs(int Id, string Name, string Address, string WorkTime)
        {
            this.Id = Id;
            this.Name = Name;
            this.Address = Address; 
            this.WorkTime = WorkTime;
        }
    }
}
