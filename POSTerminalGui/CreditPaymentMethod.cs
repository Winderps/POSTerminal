using System;
using System.Collections.Generic;
using System.Text;

namespace POSTerminalGui
{
    class CreditPaymentMethod : PaymentMethod
    {
        public int CreditCardNumber { set; get; }
        public override string ToString()
        {
            return "Credit Card " + CreditCardNumber + ", amount Paid $" + amountPaid;
        }

        public override void TakePayment(double amountDue, out double amountStillDue)
        {
            //For cash, ask the amount tendered and provide change.
            //For check, get the check number.
            //For credit, get the credit card number, expiration, and CW.

            Console.WriteLine("Please entered the credit card number: ");
            int ccNumber = 0;
            while (!int.TryParse(Console.ReadLine(), out ccNumber) ||
                 ccNumber <= 0)
            {
                Console.WriteLine("I'm sorry I didn't understand.  Please try again.");
            }

            CreditCardNumber = ccNumber;

            Console.WriteLine("Please entered the credit card expiration date (MM/DD/YYYY): ");
            DateTime ccExpDate;
            while (!DateTime.TryParse(Console.ReadLine(), out ccExpDate) ||
                 ccExpDate == null)
            {
                Console.WriteLine("I'm sorry I didn't understand.  Please try again.");
            }

            Console.WriteLine("Please entered the credit card CW: ");
            int ccCW = 0;
            while (!int.TryParse(Console.ReadLine(), out ccCW) ||
                 ccCW <= 0)
            {
                Console.WriteLine("I'm sorry I didn't understand.  Please try again.");
            }

            Console.WriteLine("Please entered the amount tendered: ");
            double amountTendered = 0;
            while (!double.TryParse(Console.ReadLine(), out amountTendered) ||
                 amountTendered <= 0)
            {
                Console.WriteLine("I'm sorry I didn't understand.  Please try again.");
            }

            amountStillDue = amountDue - amountTendered;

            if (amountStillDue < 0)
            {
                Console.WriteLine("Credit card charge cannot be for more than the amount due");
                amountStillDue = amountDue;
                paymentAccepted = false;
            }
            else if (amountStillDue == 0)
            {
                amountPaid = amountTendered;
                paymentAccepted = true;
            }
            else // amountStillDue > 0
            {
                amountPaid = amountTendered;
                //Console.WriteLine("Amount still due:" + amountStillDue);
                paymentAccepted = true;
            }
        }
    }
}
