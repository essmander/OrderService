using Newtonsoft.Json;
using NUnit.Framework;

namespace OrderService.Tests
{
    [TestFixture]
    public class OrderTests
    {
        private static readonly Product MotorSuper= new Product("Car Insurance", "Super", Prices.TwoThousand);
        private static readonly Product MotorKasko = new Product("Car Insurance", "Kasko", Prices.OneThousand);

        [Test]
        public void can_generate_receipt_for_motor_super()
        {
            var order = new Order("Test Company");
            order.AddLine(new OrderLine(MotorSuper, 1, 5, 90));
            var receipt = new OutputReceipt(order);
            var actual = receipt.GenerateReceipt();
            //var actual = order.GenerateReceipt();
            var expected = 
                $"Order receipt for 'Test Company'\r\n\t1 x Car Insurance Super = 2{System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator}000,00 kr\r\nSubtotal: 2{System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator}000,00 kr\r\nMVA: 500,00 kr\r\nTotal: 2{System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator}500,00 kr";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void can_generate_html_receipt_for_motor_super()
        {
            var order = new Order("Test Company");
            order.AddLine(new OrderLine(MotorSuper, 1, 5, 90));
            var receipt = new OutputReceipt(order);
            var actual = receipt.GenerateHtmlReceipt();

            var expected =
                $"<html><body><h1>Order receipt for 'Test Company'</h1><ul><li>1 x Car Insurance Super = 2{System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator}000,00 kr</li></ul><h3>Subtotal: 2{System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator}000,00 kr</h3><h3>MVA: 500,00 kr</h3><h2>Total: 2{System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator}500,00 kr</h2></body></html>";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void can_generate_receipt_for_motor_kasko()
        {
            var order = new Order("Test Company");
            order.AddLine(new OrderLine(MotorKasko, 1, 3, 90));
            var receipt = new OutputReceipt(order);
            var actual = receipt.GenerateReceipt();
            var expected =
                $"Order receipt for 'Test Company'\r\n\t1 x Car Insurance Kasko = 1{System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator}000,00 kr\r\nSubtotal: 1{System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator}000,00 kr\r\nMVA: 250,00 kr\r\nTotal: 1{System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator}250,00 kr";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void can_generate_html_receipt_for_motor_kasko()
        {
            var order = new Order("Test Company");
            order.AddLine(new OrderLine(MotorKasko, 1, 3, 90));
            var receipt = new OutputReceipt(order);
            var actual = receipt.GenerateHtmlReceipt();

            var expected =
                $"<html><body><h1>Order receipt for 'Test Company'</h1><ul><li>1 x Car Insurance Kasko = 1{System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator}000,00 kr</li></ul><h3>Subtotal: 1{System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator}000,00 kr</h3><h3>MVA: 250,00 kr</h3><h2>Total: 1{System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator}250,00 kr</h2></body></html>";

            Assert.AreEqual(expected, actual);
        }

    }
}