namespace SalesTax.Code
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Order
    {
        readonly ITaxService _salesTaxService;
        readonly ITaxService _importTaxService;

        public List<OrderItem> Items { get; }


        //Order details are computed from the order items...
        public double SalesTax => Math.Round(Items.Sum(i => i.SalesTax), 2);
        public double ImportTax => Math.Round(Items.Sum(i => i.ImportTax), 2);
        public double TaxTotal => Math.Round(SalesTax + ImportTax, 2);
        public double ItemTotal => Math.Round(Items.Sum(i => i.Quantity * i.Item.UnitPrice), 2);
        public double GrandTotal => Math.Round(ItemTotal + TaxTotal, 2);

        public Order()
        {
            Items = new List<OrderItem>();
        }
        public Order(ITaxService salesTaxService, ITaxService importTaxService) : this()
        {
            _salesTaxService = salesTaxService;
            _importTaxService = importTaxService;
        }


        public Order Add(OrderItem item)
        {
            Items.Add(item);
            return this;
        }

        public Order Add(List<OrderItem> items)
        {
            Items.AddRange(items);
            return this;
        }
    }
}