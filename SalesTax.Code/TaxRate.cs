namespace SalesTax.Code
{
    public class TaxRate
    {
        readonly double _rate;
        public double Rate => _rate;

        private TaxRate()
        { }
        public TaxRate(double rate)
        {
            _rate = rate;
        }
    }
}