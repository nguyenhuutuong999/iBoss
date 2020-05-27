using iBoss.Models.Entities.Human;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iBoss.Application.Human
{
    public interface IManageHuman
    {
        public IEnumerable<ModelViewHuman> getAll();
        public List<phongban> getAllPhongBan();
        public List<nhanvien> getBirthDayNhanVien(int id);

        public void Add(ModelViewHuman request);
        public void Update(ModelViewHuman request);
        public bool Delete(int request);
        public ModelViewHuman ViewDetail(int request);
        public ModelViewHuman Detail(int id);
    }
}
