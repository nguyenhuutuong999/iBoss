using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iBoss.Models.Entities.Payroll
{
    public class ModelViewPayroll
    {


        [Key]
        [DisplayName("Employee ID")]
        public int idEmployee { get; set; }
        [DisplayName("ID")]
        public int EmployeeNumber { get; set; }

        [StringLength(50)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [StringLength(50)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("SSN")]
        public decimal SSN { get; set; }
        [DisplayName("Pay Rate")]
        [StringLength(50)]
        public string PayRate { get; set; }
        [DisplayName("Pay Rates")]
        public int PayRatesidPayRates { get; set; }
        [DisplayName("Vacation")]
        public int? VacationDays { get; set; }
        [DisplayName("Pay Rate Name")]
        public string PayRateName { get; set; }
        [DisplayName("Value")]
        public decimal Value { get; set; }
        [DisplayName("Tax Percentage")]
        public decimal TaxPercentage { get; set; }
        [DisplayName("Pay Type")]
        public int PayType { get; set; }
        [DisplayName("Pay Amount")]
        public decimal PayAmount { get; set; }
        [DisplayName("PT Level C")]
        public decimal PTLevelC { get; set; }

    }
}