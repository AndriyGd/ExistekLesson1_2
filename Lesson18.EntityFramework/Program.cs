using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson18.EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new UserDataContext();
#if false
            //var users = db.Users.ToList();

            //Console.WriteLine($"OK: {users.Count}");

            var user = new User
            {
                UserName = "Olha",
                Password = "HN-90-ua"
            };

            db.Users.Add(user);
            db.SaveChanges();

            Console.WriteLine($"User Id: {user.UserId}"); 
#endif
            //PrintUsers(db);
            //Console.WriteLine();
            //PrintUsers(db);

            var user = db.Users.FirstOrDefault();
            if (user != null)
            {
                //Console.WriteLine(user.Password);
                //user.Password = "JOK-POL-89";
                //db.SaveChanges();

                Console.WriteLine(user.UserName);
 
                db.Users.Remove(user);
                db.SaveChanges();
            }

            Console.ReadLine();
        }

        private static void PrintUsers(UserDataContext db)
        {
            var users = from u in db.Users where u.UserId >= 2 orderby u.UserName select u;
            foreach (var user in users)
            {
                Console.WriteLine($"Name: {user.UserName}; Password: {user.Password}");
            }
        }
    }
}
