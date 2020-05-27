using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iBoss.Models.Entities.Payroll
{
    public class ModelViewPayroll
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

        public string PayRateName { get; set; }
        public decimal Value { get; set; }
        public decimal TaxPercentage { get; set; }
        public int PayType { get; set; }
        public decimal PayAmount { get; set; }
        public decimal PTLevelC { get; set; }

    }
}
