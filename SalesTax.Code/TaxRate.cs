namespace SalesTax.Code
{
    public class TaxRate
    {
        public double Rate { get; }

        private TaxRate()
        { }
        public TaxRate(double rate)
        {
            Rate = rate;
        }
    }
}