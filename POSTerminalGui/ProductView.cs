using System;
using System.Collections.Generic;
using System.Text;

namespace POSTerminalGui
{
    class ProductView
    {

        public void Display()
        {
            Console.WriteLine($"{"Item Name",-20}{"Item Description",15}{"Item Price",15}{"Item Category",15}");
            Console.WriteLine(new String('=', 90));

            List<Product> ProductsList = Product.ReadProducts();

            int i = 1;
            foreach (Product item in ProductsList)
            {
                Console.WriteLine($"{i}){item.Name,-20}{item.Description,15}{item.Price,15}{item.ProductCategory,15}");
                i++;
            }
        }
    }
}
