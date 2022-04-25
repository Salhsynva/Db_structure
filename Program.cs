using DbStructure.Data.DAL;
using DbStructure.Data.Entities;
using DbStructure.Data.Exceptions;
using DbStructure.Data.SqlServer;
using System;
using System.Security.Cryptography;
using System.Text;

namespace DbStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductServer productServer = new ProductServer();
            UserServer userServer = new UserServer();
            CommentServer commentServer = new CommentServer();
            StoreDbContext storeDbContext = new StoreDbContext();
            string answer;
            do
            {
                Console.WriteLine("========M E N U========");
                Console.WriteLine("1. Product elave et\n2. Productlar uzre axtaris et\n3. Secilmis productin commentlerine bax(productİd ile)\n4. User elave et\n5. Secilmis userin commentlerine bax(userİd ile)");
                Console.WriteLine("6. Comment elave et\n7. Commenti sil(id ile)\n8. Productlarin ortalama qiymetine bax\n9. Verilmis 2 tarix araligindaki Commentlere bax\n0. programi bitir");
                Console.WriteLine("seciminizi edin");
                answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        Console.WriteLine("productin adini daxil edin:");
                        string prName = Console.ReadLine();
                        Console.WriteLine("productin satis qiymetini daxil edin");
                        decimal costPrice = GetDecimal();
                        Console.WriteLine("productin maya deyerini daxil edin: ");
                        decimal salePrice = GetDecimal();
                        Console.WriteLine("productin sayini daxil edin: ");
                        int count = GetInt();
                        Console.WriteLine("product haqqinda melumat qeyd edin");
                        string aboutProduct = Console.ReadLine();
                        Product product = new Product()
                        {
                            Name = prName,
                            CostPrice = costPrice,
                            SalePrice = salePrice,
                            Count = count,
                            AboutProduct = aboutProduct
                        };
                        try
                        {
                            productServer.AddProduct(storeDbContext, product);
                        }
                        catch (ObjectAlreadyExistException ex)
                        {
                            Console.WriteLine(ex);
                        }
                        catch (NullReferenceException ex)
                        {
                            Console.WriteLine(ex);
                        }
                        catch (PriceCannotBeNegativeException ex)
                        {
                            Console.WriteLine(ex);
                        }
                        catch(CountCannotBeNegativeException ex)
                        {
                            Console.WriteLine(ex);
                        }
                        break;
                    case "2":
                        productServer.ShowProducts(storeDbContext);
                        break;
                    case "3":
                        Console.WriteLine("commentlerine baxmaq istediyiniz mehsulun id'sini daxil edin:");
                        int searchPrId = GetInt();
                        productServer.ShowCommentsById(storeDbContext, searchPrId);
                        break;
                    case "4":
                        Console.WriteLine("istifadecinin username'ni daxil edin:");
                        string userName = Console.ReadLine();
                        Console.WriteLine("istifadecin Emailini daxil edin: ");
                        string email = Console.ReadLine();
                        Console.WriteLine("parolu daxil edin:");
                        string password = Console.ReadLine();
                        User user = new User();
                        user.Username = userName;
                        user.Email = email;
                        user.PasswordHash = Sha256Hash(password);
                        try
                        {
                            userServer.AddUser(storeDbContext, user);
                        }
                        catch (UsernameCannotBeRepeatedException ex)
                        {
                            Console.WriteLine(ex);
                        }
                        catch(EmailAlreadyUsedException ex)
                        {
                            Console.WriteLine(ex);
                        }
                        catch (NotInEmailFormatException ex)
                        {
                            Console.WriteLine(ex);
                        }
                        break;
                    case "5":
                        Console.WriteLine("commentlerine baxmaq istediyiniz istifadecinin id'sini daxil edin:");
                        int searchUserId = GetInt();
                        userServer.ShowCommentsById(storeDbContext, searchUserId);
                        break;
                    case "6":
                        Console.WriteLine("commentin text'ini daxil edin:");
                        string commentText = Console.ReadLine();
                        Console.WriteLine("commentin userIdsini daxil edin:");
                        int userId = GetInt();
                        Console.WriteLine("commentin productIdsini daxil edin:");
                        int productId = GetInt();
                        Comment comment = new Comment()
                        {
                            Text = commentText,
                            UserId = userId,
                            ProductId = productId
                        };
                        try
                        {
                            commentServer.AddComment(storeDbContext, comment);
                        }
                        catch (UserDoesNotExistException ex)
                        {
                            Console.WriteLine(ex);
                        }
                        catch(ProductDoesNotExistException ex)
                        {
                            Console.WriteLine(ex);
                        }
                        break;
                    case "7":
                        Console.WriteLine("silmek istediyiniz commentin id'sini daxil edin:");
                        int commentId = GetInt();
                        try
                        {
                            commentServer.DeleteComment(storeDbContext,commentId);
                        }
                        catch (CommentCannotFoundException ex)
                        {
                            Console.WriteLine(ex);
                        }
                        break;
                    case "8":
                        Console.WriteLine(productServer.AvgPrice(storeDbContext));
                        break;
                    case "9":
                        Console.WriteLine("baslangic tarixi qeyd edin:");
                        DateTime firstDate = GetDatetime();
                        Console.WriteLine("son tarixi qeyd edin:");
                        DateTime endDate = GetDatetime();
                        try
                        {
                            commentServer.ShowComments(storeDbContext, firstDate, endDate);
                        }
                        catch (CommentCannotFoundException ex)
                        {
                            Console.WriteLine(ex);
                        }
                        break;
                    case "0":
                        Console.WriteLine("proqrami bitir");
                        break;
                    default:
                        Console.WriteLine("menuda bele secim yoxdur!");
                        break;
                }
            } while (answer != "0");
        }

        static decimal GetDecimal()
        {
            string decimalStr = Console.ReadLine();
            decimal number;
            while (!decimal.TryParse(decimalStr, out number))
            {
                Console.WriteLine("eded daxil edin");
                decimalStr = Console.ReadLine();
            }
            return number;
        }
        static int GetInt()
        {
            string intStr = Console.ReadLine();
            int number;
            while (!int.TryParse(intStr, out number))
            {
                Console.WriteLine("eded daxil edin");
                intStr = Console.ReadLine();
            }
            return number;
        }
        static string Sha256Hash(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }
            return Sb.ToString();
        }
        static DateTime GetDatetime()
        {
            string datetimeStr = Console.ReadLine();
            DateTime date;
            while (!DateTime.TryParse(datetimeStr, out date))
            {
                Console.WriteLine("eded daxil edin");
                datetimeStr = Console.ReadLine();
            }
            return date;
        }
    }
}
