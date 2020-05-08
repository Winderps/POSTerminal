using System;
using System.Collections.Generic;
using System.Text;

namespace POSTerminalGui
{
    class CheckPaymentMethod: PaymentMethod
    {
        public int CheckNumber { set; get; }
        public override string ToString()
        {
            return "Check " + CheckNumber + ", amount Paid $" + amountPaid;
        }

        public override void TakePayment(double amountDue, out double amountStillDue)
        {
            //For check, get the check number.

            Console.WriteLine("Please entered the check number: ");
            int checkNum = 0;
            while (!int.TryParse(Console.ReadLine(), out checkNum) ||
                 checkNum <= 0)
            {
                Console.WriteLine("I'm sorry I didn't understand.  Please try again.");
            }

            CheckNumber = checkNum;

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
                Console.WriteLine("Check cannot be for more than the amount due");
                amountStillDue = amountDue;
                paymentAccepted = false;
            }
            else if (amountStillDue == 0) {
                amountPaid = amountTendered;
                paymentAccepted = true;
            }
            else // amountStillDue > 0
            {
                amountPaid = amountTendered;
                // Console.WriteLine("Amount still due:" + amountStillDue);
                paymentAccepted = true;
            }

        }
    }
}
