using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace iBoss.Models.Entities.Payroll
{ 
    [Table("employee")]
    public class employee
    {

        [Key]
        public int idEmployee { get; set; }
        public int EmployeeNumber { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        public decimal SSN { get; set; }

        [StringLength(50)]
        public string PayRate { get; set; }

        public int PayRatesidPayRates { get; set; }
        public int? VacationDays { get; set; }

        public decimal? PaidToDate { get; set; }
        public decimal? PaidLastYear { get; set; }

        public payrates Payrates { get; set; }
    }
}
