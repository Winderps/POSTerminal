using System;
using System.Collections.Generic;
using System.Text;

namespace POSTerminalGui
{
    class ProductView
    {

        public void Display()
        {
            Console.WriteLine($"{"Item Name",-20}{"Description",25}{"Price",15}{"Category",15}");
            Console.WriteLine(new String('=', 90));

            List<Product> ProductsList = Product.ReadProducts();

            int i = 1;
            foreach (Product item in ProductsList)
            {
                Console.WriteLine($"{i,3}){item.Name,-16}{item.Description,25}{item.Price,15:c2}{item.ProductCategory,15}");
                i++;
            }
        }
    }
}
