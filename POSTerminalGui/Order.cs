using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POSTerminalGui
{
    class Order
    {
        private const decimal SalesTax = .06m;
        private List<PaymentMethod> _paymentMethods;

        public Dictionary<Product, int> Contents { get; set; }
        public decimal AmountPaid { get; set; }

        /// <summary>
        /// The list of payment methods received.
        /// </summary>
        public List<PaymentMethod> PaymentMethods
        {
            get
            {
                return _paymentMethods;
            }
            set
            {
                _paymentMethods = value;
                AmountPaid = 0.0m;
                _paymentMethods.ForEach(
                    payment => AmountPaid += payment.amountPaid
                    );
            }
        }

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
        public decimal Subtotal
        {
            get
            {
                return Math.Round(
                    Contents.Sum(item =>
                    (item.Key.Price * item.Value)), 2);
            }
        }

        /// <summary>
        /// Total cost with tax included
        /// </summary>
        public decimal GrandTotal
        {
            get
            {
                return Math.Round(Contents.Sum(item =>
                    (item.Key.Price * item.Value) //individual item price * quantity
                    * (1.0m + (item.Key.Taxable ? SalesTax : 0.0m))), 2);
            }
        }

        /// <summary>
        /// Total of sales tax only
        /// </summary>
        public decimal TaxTotal
        {
            get
            {
                return Math.Round(Contents.Sum(item =>
                    (item.Key.Price * item.Value)
                    * (item.Key.Taxable ? SalesTax : 0.0m)),2);
            }
        }

        /// <summary>
        /// The amount left to be paid, zero if fully paid
        /// </summary>
        public decimal AmountOwed
        {
            get
            {
                return Math.Max(GrandTotal - AmountPaid, 0.0m);
            }
        }

        /// <summary>
        /// Amount of change due or zero if order is incomplete
        /// </summary>
        public decimal ChangeDue
        {
            get
            {
                return Math.Max(AmountPaid - GrandTotal, 0.0m);
            }
        }

        public Order()
        {
            Contents = new Dictionary<Product, int>();
            _paymentMethods = new List<PaymentMethod>();
            AmountPaid = 0.0m;
        }

        public void AddProduct(Product product, int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Amount must be greater than 0!");
            }
            Contents.Add(product, quantity);
        }

        public static decimal GetLineSubtotal(KeyValuePair<Product, int> orderItem)
        {
            return (orderItem.Key.Price * orderItem.Value);
        }

        public static decimal GetLineTotal(KeyValuePair<Product, int> orderItem)
        {
            if (!orderItem.Key.Taxable)
            {
                return (orderItem.Key.Price * orderItem.Value);
            }
            return (orderItem.Key.Price * orderItem.Value) * (1.0m + SalesTax);
        }

        public static decimal GetTaxAmount(KeyValuePair<Product, int> orderItem)
        {
            if (!orderItem.Key.Taxable)
            {
                return 0.0m;
            }
            return (orderItem.Key.Price * orderItem.Value) * SalesTax;
        }

        public override string ToString()
        {
            return $"Subtotal: {Subtotal:C2}\nTax: {TaxTotal:C2}\nGrand Total: {GrandTotal:C2}";
        }
    }
}