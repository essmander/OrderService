using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Helpers
{
    public static class Validator
    {
        public static bool CheckForDiscoountOnLine(this OrderLine orderline)
        {
            switch (orderline.Product.Price)
            {
                case Prices.OneThousand:
                    return orderline.Quantity >= orderline.QuantityWhenDiscount ? true : false;
                case Prices.TwoThousand:
                    return orderline.Quantity >= orderline.QuantityWhenDiscount ? true : false;
                default:
                    return false;
            }
        }
    }
}
