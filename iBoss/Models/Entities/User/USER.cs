using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace iBoss.Models.Entities.User
{
    [Table("USER")]
    public class USER
    {
        [Key]
        [Required]
        public string USERNAME { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string PASSWORD { get; set; }
        public string NAME { get; set; }
        public string ROLE { get; set; }

    }
}
