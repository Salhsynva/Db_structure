using DbStructure.Data.DAL;
using DbStructure.Data.Entities;
using DbStructure.Data.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbStructure.Data.SqlServer
{
    class UserServer
    {
        public void AddUser(StoreDbContext storeDbContext, User user)
        {
            if (storeDbContext.Users.FirstOrDefault(x => x.Username == user.Username) != null)
            {
                throw new UsernameCannotBeRepeatedException("bu adda istifadeci artiq movcuddur");
            }
            else if (storeDbContext.Users.FirstOrDefault(x => x.Username == user.Email) != null)
            {
                throw new EmailAlreadyUsedException("e-poct artiq istifade edilmisdir");
            }
            else if (!user.Email.Contains("@"))
            {
                throw new NotInEmailFormatException("deyer e-poct formatinda deyil");
            }
            else
            {
                storeDbContext.Users.Add(user);
                storeDbContext.SaveChanges();
            }
        }
        public void ShowCommentsById(StoreDbContext storeDbContext, int id)
         {
            List<Comment> comments = storeDbContext.Comments.Where(x => x.UserId == id).ToList();
            foreach (var cm in comments)
            {
                Console.WriteLine($"Id: {cm.Id} - Text: {cm.Text} - ProductId: {cm.ProductId} - CreatedAt: {cm.CreatedAt}");
            }
         }


    }
}
