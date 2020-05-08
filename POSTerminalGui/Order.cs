using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POSTerminalGui
{
    class Order
    {
        private const double SalesTax = .06;

        public Dictionary<Product, int> Contents { get; set; }
        public List<PaymentMethod> PaymentMethods { get; set; }
        public bool Paid { get; set; }

        public Order()
        {
            Contents = new Dictionary<Product, int>();
            PaymentMethods = new List<PaymentMethod>();
            Paid = false;
        }

        public void AddProduct(Product product, int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Amount must be greater than 0!");
            }
            Contents.Add(product, quantity);
        }

        public double GetSubtotal()
        {
            double total = 0.0;
            foreach(KeyValuePair<Product, int> item in Contents)
            {
                total += (item.Key.Price * (double)item.Value);
            }
            return total;
        }

        public double GetSalesTax()
        {
            double taxTotal = 0.0;
            foreach (KeyValuePair<Product, int> item in Contents)
            { 
                // if (Product.Taxable)
                taxTotal += item.Key.Price * SalesTax;
            }
            return taxTotal;
        }

        public double GetGrandTotal()
        {
            return GetSubtotal() + GetSalesTax();
        }

        public static double GetLineSubtotal(KeyValuePair<Product, int> orderItem)
        {
            return (orderItem.Key.Price * orderItem.Value);
        }

        public static double GetLineTotal(KeyValuePair<Product, int> orderItem)
        {
            return (orderItem.Key.Price * orderItem.Value) * (1.0 + SalesTax);
        }

        public static double GetTaxAmount(KeyValuePair<Product, int> orderItem)
        {
            //if (!orderItem.Key.Taxable) return 0.0;
            return (orderItem.Key.Price * orderItem.Value) * SalesTax;
        }
    }
}