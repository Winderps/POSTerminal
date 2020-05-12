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

            if (amountDue <= 0m) return payments;

            decimal amountStillDue = amountDue;

            while (amountStillDue > 0)
            {
                Console.WriteLine("\nAmount Due is " + amountStillDue.ToString("C2") +".  ");
                Console.WriteLine("Here are your payment options");
                Console.WriteLine("1) Cash  2) Check  3) Credit Card");
                Console.Write("Please select your payment type: ");

                int paymentType = 0;
                while (!int.TryParse(Console.ReadLine(), out paymentType) ||
                     paymentType <= 0 ||
                     paymentType > 3)
                {
                    Console.Write("I'm sorry I didn't understand.  Please enter 1-3 for one of the payment options: ");
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
                if (payment.paymentAccepted)
                {
                    payments.Add(payment);
                }
            }// end while

            return payments;

        }
    }
}