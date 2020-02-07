namespace SalesTax.Code
{
    using System;
    public class OrderItem
    {
        ITaxService _importTaxService;
        ITaxService _salesTaxService;
        public Item Item { get; set; }
        public double Quantity { get; set; }

        private OrderItem() { }

        public OrderItem(Item item, ITaxService salesTaxService, ITaxService importTaxService) : this(salesTaxService, importTaxService)
        {
            Item = item;
        }

        public OrderItem(ITaxService salesTaxService, ITaxService importTaxService)
        {
            _salesTaxService = salesTaxService;
            _importTaxService = importTaxService;
        }

        public double GrandTotal => Math.Round(EachTotal * Quantity, 2);
        public double EachTotal => Math.Round(Item.UnitPrice + SalesTax + ImportTax, 2);
        public double SalesTax => _salesTaxService?.Calculate(this) ?? 0.00;

        public double ImportTax => _importTaxService?.Calculate(this) ?? 0.00;
    }

}