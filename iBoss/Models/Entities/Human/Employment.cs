using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iBoss.Models.Entities.Human
{   [Table("EMPLOYMENT")]
    public partial class EMPLOYEMENT
    {
        //public EMPLOYEMENT()
        //{
        //    EmploymentWorkingTime = new HashSet<EmploymentWorkingTime>();
        //    JobHistory = new HashSet<JobHistory>();
        //    Personal = new HashSet<PERSONAL>();
        //}

        [Key]
        public int EMPLOYMENT_ID { get; set; }
        public string EMPLOYMENT_STATUS { get; set; }
        public DateTime? HIRE_DATE_FOR_WORKING { get; set; }
        public string WORKERS_COMP_CODE { get; set; }
        public DateTime? TERMINATION_DATE { get; set; }
        public DateTime? REHIRE_DATE_FOR_WORKING { get; set; }
        public DateTime? LAST_REVIEW_DATE { get; set; }
        public decimal? NUMBER_DAYS_REQUIREMENT_OF_WORKING_PER_MONTH { get; set; }

        //public virtual ICollection<EmploymentWorkingTime> EmploymentWorkingTime { get; set; }
        //public virtual ICollection<JobHistory> JobHistory { get; set; }
        //public virtual ICollection<PERSONAL> Personal { get; set; }
    }
}
