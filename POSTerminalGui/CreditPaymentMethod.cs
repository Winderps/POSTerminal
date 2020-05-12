using System;
using System.Collections.Generic;
using System.Text;

namespace POSTerminalGui
{
    class CreditPaymentMethod : PaymentMethod
    {
        public long CreditCardNumber { set; get; }
        public override string ToString()
        {
            return "Credit Card " + CreditCardNumber + ", amount Paid $" + amountPaid;
        }

        public override void TakePayment(decimal amountDue, out decimal amountStillDue)
        {
            //For cash, ask the amount tendered and provide change.
            //For check, get the check number.
            //For credit, get the credit card number, expiration, and CW.

            Console.WriteLine("Please entered the credit card number: ");
            long ccNumber = 0;
            while (!long.TryParse(Console.ReadLine(), out ccNumber) ||
                 ccNumber <= 0)
            {
                Console.WriteLine("I'm sorry I didn't understand.  Please try again: ");
            }

            CreditCardNumber = ccNumber;

            Console.Write("Please entered the credit card expiration date (MM/DD/YYYY): ");
            DateTime ccExpDate;
            DateTime today = DateTime.Now;
            
            while (!DateTime.TryParse(Console.ReadLine(), out ccExpDate) ||
                 ccExpDate == null || ccExpDate <= today
                 )
            {
                if (ccExpDate <= today)
                {
                    Console.WriteLine("PAYMENT CANCELLED: Credit card is expired.  Please provide another payment method.");
                    amountStillDue = amountDue;
                    return;
                }
                Console.WriteLine("I'm sorry I didn't understand.  Please enter the expiration date (MM/DD/YYYY): ");
            }

            Console.Write("Please entered the credit card CW: ");
            int ccCW = 0;
            while (!int.TryParse(Console.ReadLine(), out ccCW) ||
                 ccCW <= 0)
            {
                Console.Write("I'm sorry I didn't understand.  Please enter the credit card CW: ");
            }

            Console.Write("Please entered the amount tendered. $");
            decimal amountTendered = 0;
            while (!decimal.TryParse(Console.ReadLine(), out amountTendered) ||
                 amountTendered <= 0)
            {
                Console.Write("I'm sorry I didn't understand.  Please enter an amount greater than zero. $");
            }

            amountStillDue = amountDue - amountTendered;

            if (amountStillDue < 0)
            {
                Console.WriteLine("PAYMENT CANCELLED: credit card charge cannot be for more than the amount due");
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
                paymentAccepted = true;
            }
        }
    }
}
