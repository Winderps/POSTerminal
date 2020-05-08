using System;
using System.Collections.Generic;
using System.Text;

namespace POSTerminalGui
{
    class CashPaymentMethod
    {
        public bool TakePayment(double amountDue, out double amountStillDue)
        {
           //For cash, ask the amount tendered and provide change.
           //For check, get the check number.
           //For credit, get the credit card number, expiration, and CW.

           Console.WriteLine("Please entered the amount tendered: ");
           double amountTendered = 0;
           while (!double.TryParse(Console.ReadLine(), out amountTendered) ||
                amountTendered <= 0)
            {
                Console.WriteLine("I'm sorry I didn't understand.  Please try again.");
            }

           if (amountTendered >= amountDue)
            {
                double change = amountTendered - amountDue;
                Console.WriteLine("Here is your change:" + change);
                amountStillDue = 0;
                return true;
            } else
            {
                amountStillDue = amountDue - amountTendered;
                Console.WriteLine("Amount still due:" + amountStillDue);
                return false;
            }
        }
    }
}
