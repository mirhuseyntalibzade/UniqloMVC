using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniqloDAL.Models;

namespace UniqloDAL.Contexts
{
    public class UniqloDBContext : DbContext
    {
        public UniqloDBContext(DbContextOptions options) : base(options){}
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
