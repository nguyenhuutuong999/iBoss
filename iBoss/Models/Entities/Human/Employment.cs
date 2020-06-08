using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iBoss.Models.Entities.Human
{
    [Table("EMPLOYMENT")]
    public partial class EMPLOYMENT
    {
        //public EMPLOYEMENT()
        //{
        //    EmploymentWorkingTime = new HashSet<EmploymentWorkingTime>();
        //    JobHistory = new HashSet<JobHistory>();
        //    Personal = new HashSet<PERSONAL>();
        //}

        [Key]
        [DisplayName("ID")]
        public int EMPLOYMENT_ID { get; set; }
        [DisplayName("STATUS")]
        public string EMPLOYMENT_STATUS { get; set; }
        [DisplayName("HIRE DATE FOR WORKING")]
        [DataType(DataType.Date)]
        public DateTime? HIRE_DATE_FOR_WORKING { get; set; }
        [DisplayName("WORKERS CODE")]
        public string WORKERS_COMP_CODE { get; set; }
        [DisplayName("TERMINATION DATE")]
        public DateTime? TERMINATION_DATE { get; set; }
        [DisplayName("HIRE DATE FOR WORKING")]
        [DataType(DataType.Date)]
        public DateTime? REHIRE_DATE_FOR_WORKING { get; set; }
        [DisplayName("LAST REVIEW DATE")]
        [DataType(DataType.Date)]
        public DateTime? LAST_REVIEW_DATE { get; set; }
        [DisplayName("NUMBER DAYS REQUIREMENT OF WORKING PER MONTH")]
        public decimal? NUMBER_DAYS_REQUIREMENT_OF_WORKING_PER_MONTH { get; set; }

        //public virtual ICollection<EmploymentWorkingTime> EmploymentWorkingTime { get; set; }
        //public virtual ICollection<JobHistory> JobHistory { get; set; }
        //public PERSONAL Personal { get; set; }
    }
}