using System;
using System.Collections.Generic;

namespace iBoss.Models.Entities.Human
{
    public partial class Employment
    {
        public Employment()
        {
            EmploymentWorkingTime = new HashSet<EmploymentWorkingTime>();
            JobHistory = new HashSet<JobHistory>();
            Personal = new HashSet<Personal>();
        }

        public string EmploymentId { get; set; }
        public string EmploymentStatus { get; set; }
        public DateTime? HireDateForWorking { get; set; }
        public string WorkersCompCode { get; set; }
        public DateTime? TerminationDate { get; set; }
        public DateTime? RehireDateForWorking { get; set; }
        public DateTime? LastReviewDate { get; set; }
        public decimal? NumberDaysRequirementOfWorkingPerMonth { get; set; }

        public virtual ICollection<EmploymentWorkingTime> EmploymentWorkingTime { get; set; }
        public virtual ICollection<JobHistory> JobHistory { get; set; }
        public virtual ICollection<Personal> Personal { get; set; }
    }
}
