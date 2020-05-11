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

            List <Product> allProducts = Product.GetProducts();// Nate loads the text file
            ProductView productView = new ProductView();
            productView.Display();

            string cont = "y";

            do
            {
                Console.WriteLine("Enter the item number you wish to add: ");

                int itemNumber = 0;
                while (!int.TryParse(Console.ReadLine(), out itemNumber) ||
                    itemNumber <= 1 ||
                    itemNumber > allProducts.Count)
                {
                    Console.WriteLine("I'm sorry I didn't understand.  Please enter one of the item numbers.");
                }

                Console.WriteLine("Enter the quantity you wish to add: ");

                int itemQuantity = 0;
                while (!int.TryParse(Console.ReadLine(), out itemQuantity) ||
                    itemQuantity < 1 )
                {
                    Console.WriteLine("I'm sorry I didn't understand.  Please enter a whole number 1 or greater.");
                }

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
