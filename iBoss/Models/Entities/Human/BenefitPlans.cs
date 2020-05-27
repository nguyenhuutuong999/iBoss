using System;
using System.Collections.Generic;

namespace iBoss.Models.Entities.Human
{
    public partial class BenefitPlans
    {
        public BenefitPlans()
        {
            Personal = new HashSet<Personal>();
        }

        public decimal BenefitPlansId { get; set; }
        public string PlanName { get; set; }
        public decimal? Deductable { get; set; }
        public decimal? PercentageCopay { get; set; }

        public virtual ICollection<Personal> Personal { get; set; }
    }
}
