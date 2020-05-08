using System;
using System.Collections.Generic;
using System.Text;

namespace POSTerminalGui
{
    class CheckPaymentMethod
    {
        public bool TakePayment(double amountDue, out double amountStillDue)
        {
            //For check, get the check number.

            Console.WriteLine("Please entered the check number: ");
            int checkNumber = 0;
            while (int.TryParse(Console.ReadLine(), out checkNumber) ||
                 checkNumber <= 0)
            {
                Console.WriteLine("I'm sorry I didn't understand.  Please try again.");
            }

            Console.WriteLine("Please entered the amount tendered: ");
            double amountTendered = 0;
            while (double.TryParse(Console.ReadLine(), out amountTendered) ||
                 amountTendered <= 0)
            {
                Console.WriteLine("I'm sorry I didn't understand.  Please try again.");
            }

            amountStillDue = amountDue - amountTendered;

            if (amountStillDue < 0)
            {
                Console.WriteLine("Check cannot be for more than the amount due");
                amountStillDue = amountDue;
                return false;
            }
            else if (amountStillDue == 0) {
                return true;
            }
            else // amountStillDue > 0
            {                
                Console.WriteLine("Amount still due:" + amountStillDue);
                return false;
            }

        }
    }
}
