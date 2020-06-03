using iBoss.Models.Entities.Admin;
using iBoss.Models.Entities.Human;
using iBoss.Models.Entities.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iBoss.Application.Admin
{
    public interface IAdmin
    
    {
        public IEnumerable<ModelViewAdmin> getAll();
       
        public void Add(ModelViewAdmin request);
        public void Update(ModelViewAdmin request);
        public bool Delete(int request);
        
        public List<payrates> getAllPayrate();
        public ModelViewAdmin Detail(int id);
    }
}
