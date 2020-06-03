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
        public int EMPLOYEE_ID { get; set; }
        public string CURRENT_FIRST_NAME { get; set; }
        public string CURRENT_LAST_NAME { get; set; }


        [DataType(DataType.Date)]
        public DateTime? BIRTH_DATE { get; set; }
        public string CURRENT_ADDRESS_1 { get; set; }
        public string SOCIAL_SECURITY_NUMBER { get; set; }
        public bool CURRENT_GENDER { get; set; }
        public string CURRENT_PHONE_NUMBER { get; set; }
        public string CURRENT_MARITAL_STATUS { get; set; }
        public string CURRENT_PERSONAL_EMAIL { get; set; }

        //emploment
        public string EMPLOYMENT_STATUS { get; set; }

        [DataType(DataType.Date)]
        public DateTime? HIRE_DATE_FOR_WORKING { get; set; }
        public decimal? NUMBER_DAYS_REQUIREMENT_OF_WORKING_PER_MONTH { get; set; }

        //employee
        public string PayRate { get; set; }

        [DisplayName("PAY RATE NAME")]
        public int PayRatesidPayRates { get; set; }
        [DisplayName("Vacation Days")]
        public int? VacationDays { get; set; }


    }
}
