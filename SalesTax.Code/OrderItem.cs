namespace SalesTax.Code
{
    using System;
    public class OrderItem
    {
        IItem Item {get;set;}
        double Quantity {get;set;}

        public string PrintLineItem()
        {
            throw new NotImplementedException("Please implement OrderItem.PrintLineItem");
        }
    }

}