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
            Console.WriteLine("Welcome to our online store!");

            do
            {    
                Console.WriteLine("Here is the list of items you have to choose from:");
                Order myOrder = new Order();
                OrderView myOrderView = new OrderView(myOrder);

                List <Product> allProducts = Product.GetProducts();// text file is loaded here
                ProductView productView = new ProductView();
                productView.Display();

                do
                {
                    Console.Write("\nEnter the item number you wish to add: ");

                    int itemNumber = 0;
                    while (!int.TryParse(Console.ReadLine(), out itemNumber) ||
                        itemNumber < 1 ||
                        itemNumber > allProducts.Count)
                    {
                        Console.Write("I'm sorry I didn't understand.  Please enter one of the item numbers: ");
                    }

                    Console.Write("How many " + allProducts[itemNumber-1].Name + "s would you like? ");

                    int itemQuantity = 0;
                    while (!int.TryParse(Console.ReadLine(), out itemQuantity) ||
                        itemQuantity < 1 )
                    {
                        Console.Write("I'm sorry I didn't understand.  Please enter a whole number 1 or greater: ");
                    }

                    myOrder.AddProduct(allProducts[itemNumber-1], itemQuantity);

                    Console.Write("Would you like to add more items? (y/n): ");
                    cont = Console.ReadLine();
                
                    while (!cont.Equals("y") && !cont.Equals("n"))
                    {
                        Console.Write("I'm sorry I didn't understand.  Please enter 'y' for yes or 'n' for no: ");
                        cont = Console.ReadLine();
                    }

                } while (cont.Equals("y"));

                Console.WriteLine("\nHere is your order:");

                myOrderView.Display();

                myOrder.PaymentMethods = PaymentMethod.RequestPayment(myOrder.GrandTotal);

                Console.WriteLine("\nThank you for your order.  Here is your receipt:\n");
                myOrderView.Display();

                myOrders.Add(myOrder);

                Console.Write("Would you like to make a new order? (y/n)");
                cont = Console.ReadLine();

                while (!cont.Equals("y") && !cont.Equals("n"))
                {
                    Console.Write("I'm sorry I didn't understand.  Please enter 'y' for yes or 'n' for no.");
                    cont = Console.ReadLine();
                }

                if (cont.Equals("y")) {
                    Console.Clear();
                }
            } while (cont.Equals("y")); // loop orders

            Console.Clear();
            Console.WriteLine("Thank you for your purchases!  Here are your completed orders:");
            for (int i=0; i < myOrders.Count; i++)
            {
                Console.WriteLine("\nOrder " + (i+1) + ": " + myOrders[i].ToString() );
            }
        }
    }
}
