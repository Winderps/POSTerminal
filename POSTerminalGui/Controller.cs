using System;
using System.Collections.Generic;
using System.Text;

namespace POSTerminalGui
{
    class Controller
    {
        public static void TakeOrder()
        {
            Console.WriteLine("Welcome to the online store");
            Console.WriteLine("Here is the list of items you have to choose from:");
            Order myOrder = new Order();
            OrderView myOrderView = new OrderView(myOrder);

            List <Product> allProducts = Product.GetProducts();

            for (int i=0; i < allProducts.Count; i++)
            {
                Console.WriteLine(i+1 + ") " + allProducts[i].Name + "\t Price: " + allProducts[i].Price.ToString("C2"));
            }

            string cont = "y";

            do
            {
                Console.WriteLine("Enter the item number you wish to add: ");
                int itemNumber = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the quantity you wish to add: ");
                int itemQuantity = int.Parse(Console.ReadLine());

                myOrder.AddProduct(allProducts[itemNumber-1], itemQuantity);

                Console.WriteLine("Would you like to add more items?");
                cont = Console.ReadLine();
            } while (cont.Equals("y"));

            Console.WriteLine("Here is your order:");

            myOrderView.Display();

            myOrder.PaymentMethods = PaymentMethod.RequestPayment(myOrder.GrandTotal);

            Console.WriteLine("Thank you for your order.  Here is your receipt:");
            myOrderView.Display();

        }
    }
}
