using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Lesson18.EntityFramework
{
    public class UserDataContext: DbContext
    {

        public UserDataContext()
        {
            
        }

        public UserDataContext(string connectionString) : base(connectionString)
        {
            
        }

        public virtual DbSet<User> Users { get; set; }
    }
}
