using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iBoss.Models.Entities.Human
{
    public class ModelViewHuman
    {
        [Key]
        [DisplayName("ID")]
        public int EMPLOYEE_ID { get; set; }
        [DisplayName("FIRST NAME")]
        public string CURRENT_FIRST_NAME { get; set; }
        [DisplayName("LAST NAME")]
        public string CURRENT_LAST_NAME { get; set; }

        [DisplayName("BIRTH DATE")]
        [DataType(DataType.Date)]
        public DateTime? BIRTH_DATE { get; set; }
        [DisplayName("SECURITY NUMBER")]
        public string SOCIAL_SECURITY_NUMBER { get; set; }
        [DisplayName("ADDRESS")]
        public string CURRENT_ADDRESS_1 { get; set; }
        [DisplayName("STATUS")]
        public string EMPLOYMENT_STATUS { get; set; }
        [DisplayName("GENDER")]
        public bool CURRENT_GENDER { get; set; }
        [DisplayName("MARITAL STATUS")]
        public string CURRENT_MARITAL_STATUS { get; set; }
        [DisplayName("PHONE NUMBER")]
        public string CURRENT_PHONE_NUMBER { get; set; }
        [DisplayName("EMAIL")]
        public string CURRENT_PERSONAL_EMAIL { get; set; }
        [DisplayName("HIRE DATE FOR WORKING")]
        [DataType(DataType.Date)]
        public DateTime? HIRE_DATE_FOR_WORKING { get; set; }
        [DisplayName("NUMBER DAYS REQUIREMENT OF WORKING PER MONTH")]
        public decimal? NUMBER_DAYS_REQUIREMENT_OF_WORKING_PER_MONTH { get; set; }

    }
}