using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListApi.BLL
{
    public interface ICategory
    {
        int Id { get; set; }
        string Name { get; set; }
        List<IProduct> Products { get; set; }

        void AddProduct(IProduct product);
    }

    public class Category : ICategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<IProduct> Products { get; set; }

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
            Products = new List<IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            Products.Add(product);
        }
    }

    public interface IProduct
    {
        int Id { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
    }

    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }

    public interface ICompany
    {
        List<ICategory> Categories { get; set; }
        int Id { get; set; }
        string Name { get; set; }

        void AddCategory(ICategory category);
        List<IProduct> GetProdutsBelongsToMultipleCategory();
        object GetTopCategoryBySumOfProductPrices();
        string GetTopCategoryNameByProductCount();
    }

    public class Company : ICompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ICategory> Categories { get; set; }

        public Company(int id, string name)
        {
            Id = id;
            Name = name;
            Categories = new List<ICategory>();
        }

        public void AddCategory(ICategory category)
        {
            Categories.Add(category);
        }

        public string GetTopCategoryNameByProductCount()
        {
            var categoryName = Categories
                .OrderByDescending(c => c.Products.Count)
                .Select(c => c.Name)
                .FirstOrDefault();

            return categoryName;
        }

        public List<IProduct> GetProdutsBelongsToMultipleCategory()
        {
            var products = Categories
                .SelectMany(c => c.Products)
                .GroupBy(p => p.Id)
                .Where(g => g.Count() > 1)
                .Select(g => g.First())
                .ToList();

            return products;
        }

        public object GetTopCategoryBySumOfProductPrices()
        {
            var category = Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    TotalValue = c.Products.Sum(p => p.Price)
                })
                .OrderByDescending(c => c.TotalValue)
                .FirstOrDefault();

            return category;
        }
    }
}
