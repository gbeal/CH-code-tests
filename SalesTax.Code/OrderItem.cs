namespace SalesTax.Code
{
    using System;
    public class OrderItem
    {
        public IItem Item {get;set;}
        public double Quantity {get;set;}

        public string PrintLineItem()
        {
            throw new NotImplementedException("Please implement OrderItem.PrintLineItem");
        }
    }

}