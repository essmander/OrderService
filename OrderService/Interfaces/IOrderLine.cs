using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Interfaces
{
    public interface IOrderLine
    {
        Product Product { get; }
        int Quantity { get; }
        int QuantityWhenDiscount { get; }
        double DiscountInPrecentege { get; }
        double PriceWithDiscount { get; }
        double PriceForOrderLine();
    }
}
