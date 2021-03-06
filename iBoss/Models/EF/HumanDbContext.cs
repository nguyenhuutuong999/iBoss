﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iBoss.Models.Entities.Human;
using iBoss.Models.Entities.Admin;
namespace iBoss.Models.EF
{
    public class HumanDbContext : DbContext
    {
        public HumanDbContext(DbContextOptions<HumanDbContext> options) : base(options)
        {

        }

     
        public DbSet<ModelViewHuman> ModelViewHuman { get; set; }

        public DbSet<PERSONAL> PERSONALS { get; set; }
        public DbSet<EMPLOYMENT> EMPLOYMENTS { get; set; }
        public DbSet<iBoss.Models.Entities.Admin.ModelViewAdmin> ModelViewAdmin { get; set; }
      

    }
}
