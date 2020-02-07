namespace SalesTax.Code
{
    public class OrderService : IOrderService
    {
        readonly Order _order;
        readonly TaxRate _salesTaxRate;
        readonly TaxRate _importTaxRate;
        public OrderService(Order order, TaxRate salesTaxRate, TaxRate importTaxRate)
        {
            _order = order;
            _salesTaxRate = salesTaxRate;
            _importTaxRate = importTaxRate;
        }
        public double ItemTotal => throw new System.NotImplementedException();

        public double ImportTaxTotal => throw new System.NotImplementedException();

        public double SalesTaxTotal => throw new System.NotImplementedException();

    }
}