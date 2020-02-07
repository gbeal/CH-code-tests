namespace SalesTax.Code
{
    using System;

    public class ImportTaxService : ITaxService
    {
        private readonly TaxRate _importTaxRate;
        private ImportTaxService()
        {
        }

        public ImportTaxService(TaxRate importTaxRate)
        {
            _importTaxRate = importTaxRate;
        }

        /// <summary>
        /// Calculate Import tax at the given rate for all imported items, rounded up to the nearest 5 cents
        /// </summary>
        /// <param name="item">The item for which we will compute tax</param>
        /// <returns></returns>
        public double Calculate(OrderItem item)
        {
            if (!item.Item.IsImported) return 0.00;
            return Math.Ceiling((item.Quantity * item.Item.UnitPrice * _importTaxRate.Rate) * 20) / 20;
        }
    }
}