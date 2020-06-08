using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Employee ID")]
        public int idEmployee { get; set; }
        [DisplayName("Employee Number")]
        public int EmployeeNumber { get; set; }

        [StringLength(50)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [DisplayName("SSN")]
        public decimal SSN { get; set; }

        [DisplayName("Pay Rate")]
        [StringLength(50)]
        public string PayRate { get; set; }

        [DisplayName("PAY RATE NAME")]
        public int PayRatesidPayRates { get; set; }
        [DisplayName("Vacation Days")]
        public int? VacationDays { get; set; }
        [DisplayName("Padi to Date")]
        public decimal? PaidToDate { get; set; }
        [DisplayName("Paid Last Year")]
        public decimal? PaidLastYear { get; set; }
        
        public payrates Payrates { get; set; }
    }
}