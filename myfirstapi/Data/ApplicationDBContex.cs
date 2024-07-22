using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myfirstapi.Models;

namespace myfirstapi.Data
{
    public class ApplicationDBContex : DbContext
    {
        public ApplicationDBContex(DbContextOptions dbContextOptions)
        :base(dbContextOptions)
        {
            
        }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}