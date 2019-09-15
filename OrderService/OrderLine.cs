using OrderService.Helpers;
using OrderService.Interfaces;

namespace OrderService
{
    public class OrderLine : IOrderLine
    {
        public OrderLine(Product product, int quantity, int quantityWhenDiscount, int discountInPrecentage)
        {
            Product = product;
            Quantity = quantity;
            QuantityWhenDiscount = quantityWhenDiscount;
            DiscountInPrecentege = discountInPrecentage == 0 ? 1 : (double)discountInPrecentage / 100;
        }

        public Product Product { get; }
        public int Quantity { get; }
        public int QuantityWhenDiscount { get; }
        public double DiscountInPrecentege { get; }
        public double PriceWithDiscount
        {
            get { return (double)(this.Product.Price * DiscountInPrecentege); }
        }

        public double PriceForOrderLine()
        {
            return this.CheckForDiscoountOnLine() ? Quantity * PriceWithDiscount : Quantity * Product.Price;
        }
    }
}