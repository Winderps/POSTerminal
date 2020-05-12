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

        public override void TakePayment(decimal amountDue, out decimal amountStillDue)
        {
            //For check, get the check number.

            Console.Write("Please entered the check number: ");
            int checkNum = 0;
            while (!int.TryParse(Console.ReadLine(), out checkNum) ||
                 checkNum <= 0)
            {
                Console.Write("I'm sorry I didn't understand.  Please enter the check number: ");
            }

            CheckNumber = checkNum;

            Console.Write("Please entered the amount tendered: $");
            decimal amountTendered = 0;
            while (!decimal.TryParse(Console.ReadLine(), out amountTendered) ||
                 amountTendered <= 0)
            {
                Console.Write("I'm sorry I didn't understand.  Please enter an amount greater than zero. $");
            }

            amountStillDue = amountDue - amountTendered;

            if (amountStillDue < 0)
            {
                Console.WriteLine("PAYMENT CANCELLED: check cannot be for more than the amount due");
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
                paymentAccepted = true;
            }

        }
    }
}
