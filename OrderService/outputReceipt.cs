using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace OrderService
{
    public class OutputReceipt
    {
        private readonly Order order;
        public OutputReceipt(Order order)
        {
            this.order = order;
        }
        public string GenerateReceipt()
        {
            var orderLines = order.GetOrder().ToList();
            var result = new StringBuilder($"Order receipt for '{order.Company}'{Environment.NewLine}");

            foreach (var line in orderLines)
            {
                result.AppendLine(
                    $"\t{line.Quantity} x {line.Product.ProductType} {line.Product.ProductName} = {line.PriceForOrderLine():C}");
            }

            result.AppendLine($"Subtotal: {order.TotalAmount():C}");
            result.AppendLine($"MVA: {order.TotalTax:C}");
            result.Append($"Total: {(order.TotalAmount() + order.TotalTax):C}");
            return result.ToString();
        }

        public string GenerateHtmlReceipt()
        {
            var orderLines = order.GetOrder().ToList();
            var result = new StringBuilder($"<html><body><h1>Order receipt for '{order.Company}'</h1>");
            if (order.GetOrder().Any())
            {
                result.Append("<ul>");
                foreach (var line in orderLines)
                {
                    result.Append(
                        $"<li>{line.Quantity} x {line.Product.ProductType} {line.Product.ProductName} = {line.PriceForOrderLine():C}</li>");
                }
                result.Append("</ul>");
            }
            result.Append($"<h3>Subtotal: {order.TotalAmount():C}</h3>");
            result.Append($"<h3>MVA: {order.TotalTax:C}</h3>");
            result.Append($"<h2>Total: {(order.TotalAmount() + order.TotalTax):C}</h2>");
            result.Append("</body></html>");
            return result.ToString();
        }

        public string GenerateJsonReceipt()
        {
            var jsonObject = new Reciept
            {
                Company = order.Company,
                Orders = order.GetOrder().ToList(),
                SubTotal = order.TotalAmount(),
                MVA = order.TotalTax,
                Total = order.TotalAmount() + order.TotalTax
            };
       
            var apa = JsonConvert.SerializeObject(jsonObject);
            return JsonConvert.SerializeObject(jsonObject);
        }
    }
}
