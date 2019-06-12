using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapooModel
{
    public class OrderItem
    {
        public MenuProduct MenuProduct { get; set; }
        public int OrderItemID { get; set; }
        public int Quantity { get; set; }
        public string Comment { get; set; }
        public bool Status { get; set; }
        public bool Served { get; set; }
        public DateTime Time { get; set; }
    }
}
