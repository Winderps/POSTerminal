using System;
using System.Collections.Generic;
using System.Text;

namespace POSTerminalGui
{
    class OrderView
    {
        public Order Transaction { get; set; }

        public OrderView(Order transaction)
        {
            Transaction = transaction;
        }

        public void Display()
        {
            Console.WriteLine($"{"Item Name",20}{"Department",15}{"Amt@Price",15}{"Tax",10}{"Subtotal",15}{"Total",15}");
            Console.WriteLine(new String('=', 90));

            foreach (KeyValuePair<Product, int> item in Transaction.Contents)
            {
                Product p = item.Key;
                double lineSubtotal = Order.GetLineSubtotal(item);
                double tax = Order.GetTaxAmount(item);
                Console.WriteLine(
                    $"{p.Name,20}" +
                    $"{p.ProductCategory,15}" +
                    $"{item.Value+"@"+p.Price.ToString("C2"),15}" +
                    $"{Order.GetTaxAmount(item),10:C2}" +
                    $"{Order.GetLineSubtotal(item),15:C2}" +
                    $"{lineSubtotal + tax,15:C2}");
            }

            Console.WriteLine(new String('=',90));
            Console.WriteLine(
                $"{"Totals",6}" +
                $"{Transaction.GetSalesTax(),54:C2}" +
                $"{Transaction.GetSubtotal(),15:C2}" +
                $"{Transaction.GetGrandTotal(),15:C2}"
                );
        }

        public static void TestMe()
        {
            List<Product> p = Product.GetProducts();

            Order o = new Order();
            OrderView view = new OrderView(o);
            o.AddProduct(p[0], 3);
            o.AddProduct(p[1], 1);
            o.AddProduct(p[4], 5);
            view.Display();
        }
    }
}
