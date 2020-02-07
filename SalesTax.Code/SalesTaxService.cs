namespace SalesTax.Code
{
    using System;

    public class SalesTaxService : ITaxService
    {
        readonly TaxRate _salesTaxRate;

        private SalesTaxService()
        { }

        public SalesTaxService(TaxRate salesTaxRate)
        {
            _salesTaxRate = salesTaxRate;
        }

        /// <summary>
        /// Calculate Sales tax at the given rate for all imported items, rounded up to the nearest 5 cents
        /// </summary>
        /// <param name="item">The item for which we will compute tax</param>
        /// <returns></returns>
        public double Calculate(OrderItem item)
        {
            if (!item.Item.IsTaxable) return 0.00;

            return Math.Ceiling((item.Quantity * item.Item.UnitPrice * _salesTaxRate.Rate) * 20) / 20;
        }
    }
}