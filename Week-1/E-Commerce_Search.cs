using System;
using System.Collections.Generic;

namespace EcommerceSearch
{
    public class Product : IComparable<Product>
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }

        public Product(int id, string name, string category)
        {
            ProductId = id;
            ProductName = name;
            Category = category;
        }


        public int CompareTo(Product? other)
        {
            if (other == null) return 1;
            return this.ProductName.CompareTo(other.ProductName);
        }

        public override string ToString()
        {
            return $"ID: {ProductId}, Name: {ProductName}, Category: {Category}";
        }
    }

    class Program
    {

        public static Product? LinearSearch(Product[] products, string searchName)
        {
            foreach (var product in products)
            {
                if (product.ProductName.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                    return product;
            }
            return null;
        }

        public static Product? BinarySearch(Product[] products, string searchName)
        {
            int left = 0;
            int right = products.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                int comparison = string.Compare(products[mid].ProductName, searchName, StringComparison.OrdinalIgnoreCase);

                if (comparison == 0)
                    return products[mid];
                else if (comparison < 0)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return null;
        }

        static void Main(string[] args)
        {
            
            Product[] products = new Product[]
            {
                new Product(101, "Laptop", "Electronics"),
                new Product(102, "Shoes", "Footwear"),
                new Product(103, "Book", "Stationery"),
                new Product(104, "Smartphone", "Electronics"),
                new Product(105, "Watch", "Accessories")
            };

            Console.WriteLine("Linear Search: Searching for 'shoes'");
            var result1 = LinearSearch(products, "shoes");
            Console.WriteLine(result1 != null ? result1.ToString() : "Product not found");

            Array.Sort(products); 

            Console.WriteLine("\nBinary Search: Searching for 'shoes'");
            var result2 = BinarySearch(products, "shoes");
            Console.WriteLine(result2 != null ? result2.ToString() : "Product not found");

            /*
             *Time Complexity:
             * Linear Search: O(n) – useful for small or unsorted lists
             * Binary Search: O(log n) – is faster but requires sorted list
             * 
             *For performance in an e-commerce platform with many products
             * Binary Search
             */
        }
    }
}