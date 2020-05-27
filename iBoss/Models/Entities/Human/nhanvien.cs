using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iBoss.Models.Entities.Human
{
    [Table("nhanvien")]
    public class nhanvien
    {
        [Key]
        public int MANHANVIEN { get; set; }
        
        public string HO { get; set; }
        
        public string TEN { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime NGAYSINH { get; set; }

        public bool GIOITINH { set; get; }

        public string DIACHI { get; set; }

        public int MAPHONGBAN { get; set; }
        
        [ForeignKey("MAPHONGBAN")]
        public  phongban phongban { get; set; }
    }
}