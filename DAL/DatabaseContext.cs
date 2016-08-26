using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace DAL
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext()
            : base("OrderManagement")
        {

        }
        public DbSet<Category> Categoires { get; set; }
        public DbSet<Product> Products { get; set; }
    }

}
