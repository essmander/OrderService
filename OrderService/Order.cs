using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrderService.Helpers;
using OrderService.Interfaces;

namespace OrderService
{
    public class Order : IOrder
    {
        private readonly IList<OrderLine> orderLines = new List<OrderLine>();

        public Order(string company)
        {
            Company = company;
        }

        public string Company { get; set; }

        public void AddLine(OrderLine orderLine)
        {
            orderLines.Add(orderLine);
        }

        public IList<OrderLine> GetOrder()
        {
            return orderLines;
        }
        public double TotalAmount()
        {
            double totalAmount = 0;
            foreach (var line in orderLines)
            {
                totalAmount += line.CheckForDiscoountOnLine() ? line.Quantity * line.PriceWithDiscount :
                                                   line.Quantity * line.Product.Price;

            }
            return totalAmount;
        }

        public double TotalTax
        {
            get { return TotalAmount() * Prices.TaxRate; }
        }
    }
}