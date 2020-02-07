namespace SalesTax.Code
{
    using System;
    public interface IOrderService
    {
        double ItemTotal { get; }
        double ImportTaxTotal { get; }

        double SalesTaxTotal { get; }
    }
}