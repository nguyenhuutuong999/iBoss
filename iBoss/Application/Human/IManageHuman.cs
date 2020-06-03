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
       
        public List<PERSONAL> getBirthDayNhanVien(int id);
        public PERSONAL Search(int id);
        public void Add(ModelViewHuman request);
        public void Update(ModelViewHuman request);
        //public bool Delete(int request);
        
        public ModelViewHuman Detail(int id);
    }
}
