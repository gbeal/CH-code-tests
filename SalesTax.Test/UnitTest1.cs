using System;
using Xunit;
using Xunit.Abstractions;

namespace SalesTax.Test
{
    using System.Collections.Generic;
    using SalesTax.Code;

    public class UnitTest1
    {
        ITestOutputHelper _output;
        public UnitTest1(ITestOutputHelper output)
        {
            _output = output;
        }


        [Fact]
        public void Test_Purchase1()
        {
            //build out expected results
            const double expectedGrandTotal = 42.32;
            const double expectedTaxTotal = 1.50;
            var expectedReceipt = new System.Text.StringBuilder();
            expectedReceipt.AppendLine($"Book: 24.98 (2 @ 12.49)");
            expectedReceipt.AppendLine($"Music CD: 16.49");
            expectedReceipt.AppendLine($"Chocolate bar: 0.85");
            expectedReceipt.AppendLine($"Sales Taxes: 1.50");
            expectedReceipt.AppendLine($"Total: 42.32");

            //start a new order
            var salesTaxRate = new TaxRate(.1);
            var importTaxRate = new TaxRate(.05);
            var salesTaxService = new SalesTaxService(salesTaxRate);
            var importTaxService = new ImportTaxService(importTaxRate);

            var orderItems = new List<OrderItem>{
                new OrderItem(salesTaxService, importTaxService)
                {
                    Quantity=1,
                    Item=new Item
                    {
                        IsImported =false,
                        ItemType=ItemType.Book,
                        Name="Book", UnitPrice=12.49
                    }
                },
                new OrderItem(salesTaxService, importTaxService)
                {
                    Quantity=1,
                    Item=new Item
                    {
                        IsImported =false,
                        ItemType=ItemType.Book,
                        Name="Book",
                        UnitPrice=12.49
                    }
                },
                new OrderItem(salesTaxService, importTaxService)
                {
                    Quantity=1,
                    Item=new Item
                    {
                        IsImported =false,
                        ItemType=ItemType.Other,
                        Name="Music CD",
                        UnitPrice=14.99
                    }
                },
                new OrderItem(salesTaxService, importTaxService)
                {
                    Quantity=1,
                    Item=new Item
                    {
                        IsImported =false,
                        ItemType=ItemType.Food,
                        Name="Chocolate bar",
                        UnitPrice=.85
                    }
                }
            };

            var order = new Order(salesTaxService, importTaxService);
            order.Add(orderItems);


            _output.WriteLine($"Order total is {order.GrandTotal}");
            _output.WriteLine($"Tax total is {order.TaxTotal}");

            var receipt = FormattedReceiptService.Print(order);
            _output.WriteLine(receipt);

            Assert.True(order.GrandTotal == expectedGrandTotal);
            Assert.True(order.TaxTotal == expectedTaxTotal);
            Assert.True(receipt == expectedReceipt.ToString());

        }

        [Fact]
        public void Test_Purchase2()
        {
            const double expectedGrandTotal = 65.15;
            const double expectedTaxTotal = 7.65;
            var expectedReceipt = new System.Text.StringBuilder();
            expectedReceipt.AppendLine($"Imported box of chocolates: 10.50");
            expectedReceipt.AppendLine($"Imported bottle of perfume: 54.65");
            expectedReceipt.AppendLine($"Sales Taxes: 7.65");
            expectedReceipt.AppendLine($"Total: 65.15");

            var salesTaxRate = new TaxRate(.1);
            var importTaxRate = new TaxRate(.05);
            var salesTaxService = new SalesTaxService(salesTaxRate);
            var importTaxService = new ImportTaxService(importTaxRate);

            var orderItems = new List<OrderItem>{
                new OrderItem(salesTaxService, importTaxService)
                {
                    Quantity=1,
                    Item=new Item
                    {
                        IsImported =true,
                        ItemType=ItemType.Food,
                        Name="Imported box of chocolates",
                        UnitPrice=10.00
                    }
                },
                new OrderItem(salesTaxService, importTaxService)
                {
                    Quantity=1,
                    Item=new Item
                    {
                        IsImported =true,
                        ItemType=ItemType.Other,
                        Name="Imported bottle of perfume",
                        UnitPrice=47.50
                    }
                },
            };

            var order = new Order(salesTaxService, importTaxService);
            order.Add(orderItems);

            _output.WriteLine($"Order total is {order.GrandTotal}");
            _output.WriteLine($"Tax total is {order.TaxTotal}");

            var receipt = FormattedReceiptService.Print(order);
            _output.WriteLine(receipt);

            Assert.True(order.GrandTotal == expectedGrandTotal);
            Assert.True(order.TaxTotal == expectedTaxTotal);
            Assert.True(receipt == expectedReceipt.ToString());
        }


        [Fact]
        public void Test_Purchase3()
        {
            const double expectedGrandTotal = 86.53;
            const double expectedTaxTotal = 7.30;
            var expectedReceipt = new System.Text.StringBuilder();
            expectedReceipt.AppendLine($"Imported bottle of perfume: 32.19");
            expectedReceipt.AppendLine($"Bottle of perfume: 20.89");
            expectedReceipt.AppendLine($"Packet of headache pills: 9.75");
            expectedReceipt.AppendLine($"Imported box of chocolates: 23.70 (2 @ 11.85)");
            expectedReceipt.AppendLine($"Sales Taxes: 7.30");
            expectedReceipt.AppendLine($"Total: 86.53");

            var salesTaxRate = new TaxRate(.1);
            var importTaxRate = new TaxRate(.05);
            var salesTaxService = new SalesTaxService(salesTaxRate);
            var importTaxService = new ImportTaxService(importTaxRate);

            var orderItems = new List<OrderItem>{
                new OrderItem(salesTaxService, importTaxService)
                {
                    Quantity=1,
                    Item=new Item
                    {
                        IsImported =true,
                        ItemType=ItemType.Other,
                        Name="Imported bottle of perfume",
                        UnitPrice=27.99
                    }
                },
                new OrderItem(salesTaxService, importTaxService)
                {
                    Quantity=1,
                    Item=new Item
                    {
                        IsImported =false,
                        ItemType=ItemType.Other,
                        Name="Bottle of perfume",
                        UnitPrice=18.99
                    }
                },
                new OrderItem(salesTaxService, importTaxService)
                {
                    Quantity=1,
                    Item=new Item
                    {
                        IsImported =false,
                        ItemType=ItemType.MedicalSupply,
                        Name="Packet of headache pills",
                        UnitPrice=9.75
                    }
                },
                new OrderItem(salesTaxService, importTaxService)
                {
                    Quantity=1,
                    Item=new Item
                    {
                        IsImported =true,
                        ItemType=ItemType.Food,
                        Name="Imported box of chocolates",
                        UnitPrice=11.25
                    }
                },
                new OrderItem(salesTaxService, importTaxService)
                {
                    Quantity=1,
                    Item=new Item
                    {
                        IsImported =true,
                        ItemType=ItemType.Food,
                        Name="Imported box of chocolates",
                        UnitPrice=11.25
                    }
                }
            };

            var order = new Order(salesTaxService, importTaxService);
            order.Add(orderItems);

            _output.WriteLine($"Order total is {order.GrandTotal}");
            _output.WriteLine($"Tax total is {order.TaxTotal}");

            var receipt = FormattedReceiptService.Print(order);
            _output.WriteLine(receipt);

            Assert.True(order.GrandTotal == expectedGrandTotal);
            Assert.True(order.TaxTotal == expectedTaxTotal);
            Assert.True(receipt == expectedReceipt.ToString());
        }

    }
}
