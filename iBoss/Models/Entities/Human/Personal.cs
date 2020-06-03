using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iBoss.Models.Entities.Human
{
    [Table("PERSONAL")]
    public partial class PERSONAL
    {

        [Key]
        public int PERSONAL_ID { get; set; }

        
        [DisplayName("ID")]
        public int EMPLOYEE_ID { get; set; }
        [DisplayName("FIRST NAME")]
        public string CURRENT_FIRST_NAME { get; set; }
        [DisplayName("LAST NAME")]
        public string CURRENT_LAST_NAME { get; set; }
       
        [DataType(DataType.Date)]
        public DateTime? BIRTH_DATE { get; set; }
        public string SOCIAL_SECURITY_NUMBER { get; set; }
        [DisplayName("ADDRESS")]
        public string CURRENT_ADDRESS_1 { get; set; }

        [DisplayName("GENDER")]
        public bool CURRENT_GENDER { get; set; }
        public string CURRENT_PHONE_NUMBER { get; set; }
        public string CURRENT_MARITAL_STATUS { get; set; }
        public string CURRENT_PERSONAL_EMAIL { get; set; }

      //  public virtual BenefitPlans BenefitPlan { get; set; }
        //public EMPLOYEMENT EMPLOYEMENT { get; set; }
    }
}
