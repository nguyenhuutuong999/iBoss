using System;
using System.Collections.Generic;

namespace iBoss.Models.Entities.Human
{
    public partial class JobHistory
    {
        public decimal JobHistoryId { get; set; }
        public string EmploymentId { get; set; }
        public string Department { get; set; }
        public string Division { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ThruDate { get; set; }
        public string JobTitle { get; set; }
        public string Supervisor { get; set; }
        public string Location { get; set; }
        public short? TypeOfWork { get; set; }

        public virtual EMPLOYEMENT Employment { get; set; }
    }
}
