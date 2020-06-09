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
       
        public List<PERSONAL> getBirthDay(int id);
        public List<PERSONAL> getBirthDayInform(int month, int date);
        public List<ModelViewHuman> getHiringDay(int id);
        public List<ModelViewHuman> getHiringDayInform(int month, int date);
        public PERSONAL Search(int id);
        public void Add(ModelViewHuman request);
        public void Update(ModelViewHuman request);
        //public bool Delete(int request);
        public (int, int) getGender();
        public ModelViewHuman Detail(int id);
    }
}
