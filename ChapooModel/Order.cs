using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapooModel
{
    public class Order
    {
        public List<OrderItem> OrderItems { get; set; }
        public Table Table { get; set; }
        public Employee Employee { get; set; }
        public int OrderID { get; set; }
        public double TotalPrice { get; set; }
        public string Comment { get; set; }
        public int TotalPaid { get; set; }
    }
}
