using Microsoft.VisualBasic.CompilerServices;
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
        public double AmountPaid { get; set; }

        /// <summary>
        /// True if order has a nonzero total and payment is greater than grand total
        /// </summary>
        public bool Paid
        {
            get
            {
                return (Contents.Count > 0
                        && AmountPaid >= GrandTotal);
            }
        }

        /// <summary>
        /// Total cost of the order before tax
        /// </summary>
        public double Subtotal
        {
            get
            {
                return Contents.Sum(item =>
                    (item.Key.Price * item.Value));
            }
        }

        /// <summary>
        /// Total cost with tax included
        /// </summary>
        public double GrandTotal
        {
            get
            {
                return Contents.Sum(item =>
                    (item.Key.Price * item.Value) //individual item price * quantity
                    * 1.0 + SalesTax); // * 1.0 + (item.Key.Taxable ? SalesTax : 0.0)
            }
        }

        /// <summary>
        /// Total of sales tax only
        /// </summary>
        public double TaxTotal
        {
            get
            {
                return Contents.Sum(item =>
                    (item.Key.Price * item.Value)
                    * SalesTax);
            }
        }

        /// <summary>
        /// The amount left to be paid, zero if fully paid
        /// </summary>
        public double AmountOwed
        {
            get
            {
                return Math.Max(GrandTotal - AmountPaid, 0.0d);
            }
        }

        /// <summary>
        /// Amount of change due or zero if order is incomplete
        /// </summary>
        public double ChangeDue
        {
            get
            {
                return Math.Max(AmountPaid - GrandTotal, 0.0d);
            }
        }

        public Order()
        {
            Contents = new Dictionary<Product, int>();
            PaymentMethods = new List<PaymentMethod>();
            AmountPaid = 0.0;
        }

        public void AddProduct(Product product, int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Amount must be greater than 0!");
            }
            Contents.Add(product, quantity);
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