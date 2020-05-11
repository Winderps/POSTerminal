using System;
using System.Collections.Generic;
using System.Text;

namespace POSTerminalGui
{
    class Controller
    {
        public static List<Order> myOrders = new List<Order>();
        public static void TakeOrder()
        {

            string cont = "y";

            do
            {
                Console.WriteLine("Welcome to the online store");
                Console.WriteLine("Here is the list of items you have to choose from:");
                Order myOrder = new Order();
                OrderView myOrderView = new OrderView(myOrder);

                List <Product> allProducts = Product.GetProducts();// Nate loads the text file
                ProductView productView = new ProductView();
                productView.Display();

                do
                {
                    Console.WriteLine("Enter the item number you wish to add: ");

                    int itemNumber = 0;
                    while (!int.TryParse(Console.ReadLine(), out itemNumber) ||
                        itemNumber < 1 ||
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

                    Console.WriteLine("Would you like to add more items? (y/n)");
                    cont = Console.ReadLine();
                
                    while (!cont.Equals("y") && !cont.Equals("n"))
                    {
                        Console.WriteLine("I'm sorry I didn't understand.  Please enter 'y' for yes or 'n' for no.");
                        cont = Console.ReadLine();
                    }

                } while (cont.Equals("y"));

                Console.WriteLine("\nHere is your order:");

                myOrderView.Display();

                myOrder.PaymentMethods = PaymentMethod.RequestPayment(myOrder.GrandTotal);

                Console.WriteLine("Thank you for your order.  Here is your receipt:");
                myOrderView.Display();

                myOrders.Add(myOrder);

                Console.WriteLine("Would you like to make a new order? (y/n)");
                cont = Console.ReadLine();

                while (!cont.Equals("y") && !cont.Equals("n"))
                {
                    Console.WriteLine("I'm sorry I didn't understand.  Please enter 'y' for yes or 'n' for no.");
                    cont = Console.ReadLine();
                }

            } while (cont.Equals("y")); // loop orders

            Console.WriteLine("\nAll done.  Here are the completed orders:");
            for (int i=0; i < myOrders.Count; i++)
            {
                Console.WriteLine("\nOrder " + (i+1) + ": " + myOrders[i].ToString() );
            }
        }
    }
}
