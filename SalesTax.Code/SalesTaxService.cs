namespace SalesTax.Code
{
    public class SalesTaxService : ITaxService
    {
        readonly Order _order;

        private SalesTaxService()
        {}

        public SalesTaxService(Order order, TaxRate salesTaxRate)
        {

        }
        public double Calculate()
        {
            throw new System.NotImplementedException();
        }
    }
}