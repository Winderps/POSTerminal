using System;
using System.Collections.Generic;
using System.Text;

namespace POSTerminalGui
{
    class CashPaymentMethod : PaymentMethod
    {
        public int CheckNumber { set; get; }
        public override string ToString()
        {
            return "Cash $" + amountPaid;
        }

        public override void TakePayment(decimal amountDue, out decimal amountStillDue)
        {
           //For cash, ask the amount tendered and provide change.
           //For check, get the check number.
           //For credit, get the credit card number, expiration, and CW.

           Console.WriteLine("Please entered the amount tendered: ");
           decimal amountTendered = 0;
           while (!decimal.TryParse(Console.ReadLine(), out amountTendered) ||
                amountTendered <= 0)
            {
                Console.WriteLine("I'm sorry I didn't understand.  Please try again.");
            }

           if (amountTendered >= amountDue)
            {
                decimal change = amountTendered - amountDue;
                //amountPaid = amountDue;
                amountPaid = amountTendered;
                //Console.WriteLine("Here is your change: $" + change);
                amountStillDue = 0;
                paymentAccepted = true;
            } else
            {
                amountPaid = amountTendered;
                amountStillDue = amountDue - amountTendered;
                // Console.WriteLine("Amount still due:" + amountStillDue);
                paymentAccepted = true;
            }
        }
    }
}
