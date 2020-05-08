using System;
using System.Collections.Generic;
using System.Text;

namespace POSTerminalGui
{
    abstract class PaymentMethod
    {
        public abstract bool TakePayment(double amountDue, out double amountStillDue);

        public void RequestPayment(double amountDue)
        {

        }

    }
}
