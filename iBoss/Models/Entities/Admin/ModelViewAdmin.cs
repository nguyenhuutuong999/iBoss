using iBoss.Models.Entities.Human;
using iBoss.Models.Entities.Payroll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iBoss.Models.Entities.Admin
{
    public class ModelViewAdmin
    {
        //Personal
        [Key]
        [DisplayName("ID")]
        public int EMPLOYEE_ID { get; set; }
        [DisplayName("First Name")]
        public string CURRENT_FIRST_NAME { get; set; }
        [DisplayName("Last Name")]
        public string CURRENT_LAST_NAME { get; set; }

        [DisplayName("Birth Date")]
        [DataType(DataType.Date)]
        public DateTime? BIRTH_DATE { get; set; }
        [DisplayName("Address")]
        public string CURRENT_ADDRESS_1 { get; set; }
        [DisplayName("Security Number")]
        public string SOCIAL_SECURITY_NUMBER { get; set; }
        [DisplayName("Gender")]
        public bool CURRENT_GENDER { get; set; }
        [DisplayName("Phone Number")]
        public string CURRENT_PHONE_NUMBER { get; set; }
        [DisplayName("Marital Status")]
        public string CURRENT_MARITAL_STATUS { get; set; }
        [DisplayName("Email")]
        public string CURRENT_PERSONAL_EMAIL { get; set; }

        //emploment
        [DisplayName("Employment Status")]
        public string EMPLOYMENT_STATUS { get; set; }
        [DisplayName("Hire Date For Working")]
        [DataType(DataType.Date)]
        public DateTime? HIRE_DATE_FOR_WORKING { get; set; }
        [DisplayName("Number Days Requirement")]
        public decimal? NUMBER_DAYS_REQUIREMENT_OF_WORKING_PER_MONTH { get; set; }

        //employee
        [DisplayName("Pay Rate")]
        public string PayRate { get; set; }

        [DisplayName("PAY RATE NAME")]
        public int PayRatesidPayRates { get; set; }
        [DisplayName("Vacation Days")]
        public int? VacationDays { get; set; }


    }
}