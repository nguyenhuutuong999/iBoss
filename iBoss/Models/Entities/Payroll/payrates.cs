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
        [DisplayName("")]
        public string PayRateName { get; set; }
        [DisplayName("Value")]
        public decimal Value { get; set; }
        public decimal TaxPercentage { get; set; }
        public int PayType { get; set; }
        public decimal PayAmount { get; set; }
        public decimal PTLevelC { get; set; }
    }
}
