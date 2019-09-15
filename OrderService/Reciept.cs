using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService
{
    public class Reciept
    {
        public string Company { get; set; }
        public List<OrderLine> Orders { get; set; }
        public double SubTotal { get; set; }
        public double MVA { get; set; }
        public double Total { get; set; }
    }
}
