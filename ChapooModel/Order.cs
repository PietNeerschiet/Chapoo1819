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
        public double TotalPaid { get; set; }
        public double Tip { get; set; }
        public DateTime OrderDate { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        
    }
}
