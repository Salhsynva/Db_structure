using DbStructure.Data.DAL;
using DbStructure.Data.Entities;
using DbStructure.Data.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbStructure.Data.SqlServer
{
    class CommentServer
    {
        public void AddComment(StoreDbContext storeDbContext, Comment comment)
        {
            if (storeDbContext.Users.FirstOrDefault(x=> x.Id == comment.UserId) == null)
            {
                throw new UserDoesNotExistException($"{comment.UserId} id'li user movcud deyil");
            }
            else if (storeDbContext.Products.FirstOrDefault(x => x.Id == comment.ProductId) == null)
            {
                throw new ProductDoesNotExistException($"{comment.ProductId} id'li mehsul movcud deyil");
            }
            else
            {
                storeDbContext.Comments.Add(comment);
                storeDbContext.SaveChanges();
            }
        }

        public void DeleteComment(StoreDbContext storeDbContext, int id)
        {
            var data = storeDbContext.Comments.Find(id);
            if (data == null)
            {
                throw new CommentCannotFoundException($"{id} idli comment movcud deyil");
            }
            if (data != null)
            {
                storeDbContext.Comments.Remove(data);
            }
            storeDbContext.SaveChanges();
        }
        public void ShowComments(StoreDbContext storeDbContext, DateTime firstDate, DateTime endDate)
        {
            var comments = storeDbContext.Comments.Where(x => x.CreatedAt >= firstDate && x.CreatedAt <= endDate).ToList();
            if (comments == null)
            {
                throw new CommentCannotFoundException("bu tarix araliginda hec bir comment elave olunmayib");
            }
            foreach (var item in comments)
            {
                Console.WriteLine($"id: {item.Id} - text: {item.Text} - userId: {item.UserId} - productId: {item.ProductId} - createdAt: {item.CreatedAt}");
            }
        }
    }
}
