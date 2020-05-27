using iBoss.Models.Entities.Admin;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iBoss.Models.EF
{
   
    public class AdminDbContext : DbContext
    {
        public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options)
        {

        }

      
        public DbSet<ModelViewAdmin> ModelViewAdmin { get; set; }


    }
}
