using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace iBoss.Models.Entities.Payroll
{
    [Table("payrates")]
    public class payrates
    {
        [Key]
        [DisplayName("ID")]
        public int idPayRates { get; set; }
        [DisplayName("Pay Rate Name")]
        public string PayRateName { get; set; }
        [DisplayName("Value")]
        public decimal Value { get; set; }
        [DisplayName("Tax Percentage")]
        public decimal TaxPercentage { get; set; }
        [DisplayName("Pay Type")]
        public int PayType { get; set; }
        [DisplayName("Pay Amount")]
        public decimal PayAmount { get; set; }
        [DisplayName("PT Level C")]
        public decimal PTLevelC { get; set; }
    }
}