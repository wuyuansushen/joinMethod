using System;
using System.Collections.Generic;
using System.Linq;

namespace joinMethod
{
    class Product
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }

    class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }

    class Program
    {
        public static void Main()
        {
            List<Product> products = new List<Product>
    {
        new Product { Name = "Cola", CategoryId = 0 },
        new Product { Name = "Tea", CategoryId = 0 },
        new Product { Name = "Apple", CategoryId = 1 },
        new Product { Name = "Kiwi", CategoryId = 1 },
        new Product { Name = "Carrot", CategoryId = 2 },
    };

            List<Category> categories = new List<Category>
    {
        new Category { Id = 0, CategoryName = "Beverage" },
        new Category { Id = 1, CategoryName = "Fruit" },
        new Category { Id = 2, CategoryName = "Vegetable" }
    };

            // Join products and categories based on CategoryId
            var query = from product in products
                        join category in categories on product.CategoryId equals category.Id
                        select new { product.Name, category.CategoryName };

            foreach (var item in query)
            {
                Console.WriteLine($"{item.Name} - {item.CategoryName}");
            }

            // This code produces the following output:
            //
            // Cola - Beverage
            // Tea - Beverage
            // Apple - Fruit
            // Kiwi - Fruit
            // Carrot - Vegetable

            Console.WriteLine();


            var querymtd = Enumerable.Join<Product, Category, int, MtdResult>(products, categories, (product) => product.CategoryId
            , (category) => category.Id, (prod, cate) =>new MtdResult { Name=prod.Name,CategoryName=cate.CategoryName});

            foreach (var item in querymtd)
            {
                Console.WriteLine($"{item.Name} - {item.CategoryName}");
            }
        }
    }
    public class MtdResult
    {
        public string Name { get; set; }
        public string CategoryName { get; set; }
    }
}
