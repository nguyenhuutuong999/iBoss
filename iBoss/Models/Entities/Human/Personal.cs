﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iBoss.Models.Entities.Human
{
    public partial class Personal
    {
        public decimal PersonalId { get; set; }
        public string EmployeeId { get; set; }
        public string CurrentFirstName { get; set; }
        public string CurrentLastName { get; set; }
        public string CurrentMiddleName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string DriversLicense { get; set; }
        public string CurrentAddress1 { get; set; }
        public string CurrentAddress2 { get; set; }
        public string CurrentCity { get; set; }
        public string CurrentCountry { get; set; }
        public decimal? CurrentZip { get; set; }
        public string CurrentGender { get; set; }
        public string CurrentPhoneNumber { get; set; }
        public string CurrentPersonalEmail { get; set; }
        public string CurrentMaritalStatus { get; set; }
        public string Ethnicity { get; set; }
        public short? ShareholderStatus { get; set; }
        public decimal? BenefitPlanId { get; set; }

        public virtual BenefitPlans BenefitPlan { get; set; }
        public virtual Employment Employee { get; set; }
    }
}
