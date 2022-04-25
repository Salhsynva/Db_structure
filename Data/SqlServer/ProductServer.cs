using DbStructure.Data.DAL;
using DbStructure.Data.Entities;
using DbStructure.Data.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbStructure.Data.SqlServer
{
    class ProductServer
    {
        public void AddProduct(StoreDbContext storeDbContext, Product product)
        {
            if (storeDbContext.Products.FirstOrDefault(x => x.Name == product.Name) != null)
            {
                throw new ObjectAlreadyExistException("bu product artiq elave olunub");
            }
            else if (product.Name == null)
            {
                throw new NullReferenceException("mehsulun adi null ola bilmez");
            }
            else if (product.CostPrice < 0 || product.SalePrice < 0)
            {
                throw new PriceCannotBeNegativeException("mehsulun qiymeti menfi ola bilmez");
            }
            else if (product.Count < 0)
            {
                throw new CountCannotBeNegativeException("mehsulun sayi menfi ola bilmez");
            }
            else
            {
                storeDbContext.Products.Add(product);
                storeDbContext.SaveChanges();
            }
        }
        public void ShowProducts(StoreDbContext storeDbContext)
        {
            List<Product> products = storeDbContext.Products.ToList();
            foreach (var pr in products)
            {
                Console.WriteLine($"id: {pr.Id} - name: {pr.Name} - costPirce: {pr.CostPrice} - salePrice: {pr.SalePrice} - count: {pr.Count} - createdAt: {pr.CratedAt}");
            }
        }
        public void ShowCommentsById(StoreDbContext storeDbContext, int id)
        {
            List<Comment> comments = storeDbContext.Comments.Where(x => x.ProductId == id).ToList();
            foreach (var cm in comments)
            {
                Console.WriteLine($"Id: {cm.Id} - Text: {cm.Text} - UserId: {cm.UserId} - CreatedAt: {cm.CreatedAt}");
            }
        }
        public decimal AvgPrice(StoreDbContext storeDbContext)
        {
            return storeDbContext.Products.Average(x => x.SalePrice);
        }
        
    }
}
