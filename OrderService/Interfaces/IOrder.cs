using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Interfaces
{
    public interface IOrder
    {
        string Company { get; set; }
        void AddLine(OrderLine orderLine);
        IList<OrderLine> GetOrder();
        double TotalAmount();
        double TotalTax { get; }

    }
}
