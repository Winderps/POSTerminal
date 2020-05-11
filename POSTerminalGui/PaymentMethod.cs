using System;
using System.Collections.Generic;
using System.Text;

namespace POSTerminalGui
{
    abstract class PaymentMethod
    {
        public decimal amountPaid = 0;
        public bool paymentAccepted;

        public abstract void TakePayment(decimal amountDue, out decimal amountStillDue);
        public static List<PaymentMethod> RequestPayment(decimal amountDue)
        {
            List<PaymentMethod> payments = new List<PaymentMethod>();

            if (amountDue <= 0) return payments;

            decimal amountStillDue = amountDue;

            while (amountStillDue > 0)
            {
//                Console.WriteLine("\nAmount Due is $" + amountStillDue);
                Console.WriteLine("Please select your payment type:");
                Console.WriteLine("1) Cash");
                Console.WriteLine("2) Check");
                Console.WriteLine("3) Credit Card");

                int paymentType = 0;
                while (!int.TryParse(Console.ReadLine(), out paymentType) ||
                     paymentType <= 0 ||
                     paymentType > 3)
                {
                    Console.WriteLine("I'm sorry I didn't understand.  Please try again.");
                }

                PaymentMethod payment;

                payment = paymentType switch
                {
                    1 => new CashPaymentMethod(),
                    2 => new CheckPaymentMethod(),
                    3 => new CreditPaymentMethod(),
                    _ => throw new ArgumentException("invalid payment type")
                };

                payment.TakePayment(amountStillDue, out amountStillDue);
                if (!payment.paymentAccepted)
                {
                    Console.WriteLine("payment not applied");
                } else
                {
                    payments.Add(payment);
                }
            }// end while

            //Console.WriteLine("Thank you for your payment.  Have a nice day!");
            //foreach (PaymentMethod p in payments)
            //{
            //    Console.WriteLine("Payment: " + p.ToString() );
            //}
            return payments;

        }
    }
}
