namespace SalesTax.Code
{
    using System.Collections.Generic;
    public interface ITaxService
    {
        double Calculate(OrderItem item);
    }
}