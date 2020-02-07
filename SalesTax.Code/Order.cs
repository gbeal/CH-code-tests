namespace SalesTax.Code
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Order
    {
        private List<OrderItem> _orderItems;

        public Order()
        {
            _orderItems=new List<OrderItem>();
        }

        public string PrintReceipt()
        {
            throw new NotImplementedException("please implement Order.PrintReceipt");
        }

        public Order Add(OrderItem item)
        {
            _orderItems.Add(item);
            return this;
        }

    }
}