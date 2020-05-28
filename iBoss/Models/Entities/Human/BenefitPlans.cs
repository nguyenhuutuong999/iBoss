using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iBoss.Models.Entities.Human
{
    public partial class BenefitPlans
    {
        public BenefitPlans()
        {
            Personal = new HashSet<PERSONAL>();
        }
        [Key]
        public decimal BenefitPlansId { get; set; }
        public string PlanName { get; set; }
        public decimal? Deductable { get; set; }
        public decimal? PercentageCopay { get; set; }

        public virtual ICollection<PERSONAL> Personal { get; set; }
    }
}
