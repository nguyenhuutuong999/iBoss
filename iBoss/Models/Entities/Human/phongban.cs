using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iBoss.Models.Entities.Human
{
    [Table("phongban")]
    public class phongban
    {
        [Key]
        public int MAPHONGBAN { get; set; }

        public string TENPHONGBAN { get; set; }
    }
    
}