using iBoss.Models.Entities.Payroll;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace iBoss.Models.EF
{
    public class PayrollDbContext : DbContext
    {
        public PayrollDbContext(DbContextOptions<PayrollDbContext> options): base(options)
        {

        }
       
        public DbSet<employee> employees { get; set; }
        public DbSet<payrates> payratess { get; set; }

        public DbSet<iBoss.Models.Entities.Payroll.ModelViewPayroll> ModelViewPayroll { get; set; }


    }
}
