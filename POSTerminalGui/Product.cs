using System;
using System.Collections.Generic;
using System.Text;

namespace POSTerminalGui
{
    class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Category ProductCategory { get; set; }


        public Product(string name, string description, double price, Category productCategory)
        {
            Name = name;
            Description = description;
            Price = price;
            ProductCategory = productCategory;
        }

        public Product() { }

        public static List<Product> GetProducts()
        {
            List<Product> product = new List<Product>()
            {
                new Product("Hotdog", "Meat log on a bun", 1.50, Category.Food),
                new Product("Big Gulp", "XL Frozen Goodness", 1.99, Category.Drink),
                new Product("Hula Girl", "Dancing figurine", 5.99, Category.Chachkie),
                new Product("Churro", "Fried dough pastry", 0.99, Category.Food),
                new Product("Milk", "Moo juice", 2.99, Category.Drink),
            };

            return product;
        }
    }
}
