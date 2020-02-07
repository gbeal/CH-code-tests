namespace SalesTax.Code
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class FormattedReceiptService
    {
        static StringBuilder _receipt;

        private FormattedReceiptService()
        {
            _receipt = new StringBuilder();
        }

        /// <summary>
        /// Print a receipt formatted per IT Director's specifications
        /// </summary>
        /// <param name="order">The order for which a receipt is being printed</param>
        /// <returns></returns>
        public static string Print(Order order)
        {
            _receipt = new StringBuilder();

            //project order items, grouped by name and per-item price plus tax
            var groupedItems = order.Items.GroupBy(c => new { c.Item.Name, c.EachTotal });
            double totalSalesTax = 0.00;
            double grandTotal = 0.00;
            foreach (var item in groupedItems)
            {
                var name = item.Key.Name;
                var quantity = item.Sum(c => c.Quantity);
                var eachPrice = item.Key.EachTotal;
                var totalPrice = quantity * eachPrice;

                //only show quantity @ eachprice where quantity> 1
                if (quantity > 1)
                {
                    _receipt.AppendLine($"{name}: {totalPrice:F} ({quantity} @ {eachPrice:F})");
                }
                else
                {
                    _receipt.AppendLine($"{name}: {totalPrice:F}");
                }
                //accummulated tax and total here
                totalSalesTax += item.Sum(c => c.SalesTax + c.ImportTax);
                grandTotal += item.Sum(c => c.GrandTotal);

            }

            //always show sales tax even if nont is collected
            _receipt.AppendLine($"Sales Taxes: {totalSalesTax:F}");
            _receipt.AppendLine($"Total: {grandTotal:F}");
            return _receipt.ToString();
        }
    }
}