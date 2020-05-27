using System;
using System.Collections.Generic;

namespace iBoss.Models.Entities.Human
{
    public partial class EmploymentWorkingTime
    {
        public decimal EmploymentWorkingTimeId { get; set; }
        public string EmploymentId { get; set; }
        public DateTime? YearWorking { get; set; }
        public decimal? MonthWorking { get; set; }
        public decimal? NumberDaysActualOfWorkingPerMonth { get; set; }
        public decimal? TotalNumberVacationWorkingDaysPerMonth { get; set; }

        public virtual Employment Employment { get; set; }
    }
}
