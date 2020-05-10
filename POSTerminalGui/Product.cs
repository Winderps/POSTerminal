using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace POSTerminalGui
{
    class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Category ProductCategory { get; set; }
        public bool Taxable { get; set; }

        public Product(string name, string description, double price, Category productCategory, bool taxable)
        {
            Name = name;
            Description = description;
            Price = price;
            ProductCategory = productCategory;
            Taxable = taxable;
        }

        public Product() 
        {
        
        }

        public static List<Product> GetProducts()
        {
            return ReadProducts();
        }

        public static void SaveProducts(List<Product> products)
        {
            StreamWriter writer = new StreamWriter("Product.txt");
            foreach (Product p in products)
            {
                writer.WriteLine($"{p.Name}|{p.Description}|{p.Price}|{p.ProductCategory}|{p.Taxable}");
            }
            writer.Close();
        }
        public static List<Product> ReadProducts()
        {
            List<Product> productList2 = new List<Product>();

            StreamReader reader = new StreamReader("Product.txt");
            string line = reader.ReadLine();
            while (line != null)
            {
                string[] productProps = line.Split('|');
                productList2.Add(new Product(productProps[0], productProps[1], double.Parse(productProps[2]), (Category)Enum.Parse(typeof(Category),productProps[3]), bool.Parse(productProps[4])));
                line = reader.ReadLine();
            }
            reader.Close();
            return productList2;
        }
    }
}
