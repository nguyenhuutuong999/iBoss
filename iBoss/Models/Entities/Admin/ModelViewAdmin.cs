using iBoss.Models.Entities.Human;
using iBoss.Models.Entities.Payroll;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iBoss.Models.Entities.Admin
{
    public class ModelViewAdmin
    {
        [Key]
        public int MANHANVIEN { get; set; }

        public int MAPHONGBAN { get; set; }
        public string HO { get; set; }

        public string TEN { get; set; }

        [DataType(DataType.Date)]
        public DateTime NGAYSINH { get; set; }

        public bool GIOITINH { set; get; }

        public string DIACHI { get; set; }

        public string TENPHONGBAN { get; set; }


    }
}
