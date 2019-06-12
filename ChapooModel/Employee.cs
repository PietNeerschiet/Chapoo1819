﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapooModel
{
    public enum EmployeeType { Ober, Kok, Barman, Manager }
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public EmployeeType EmployeeType { get; set; }
    }
}
