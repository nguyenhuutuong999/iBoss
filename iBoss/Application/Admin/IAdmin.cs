using iBoss.Models.Entities.Admin;
using iBoss.Models.Entities.Human;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iBoss.Application.Admin
{
    public interface IAdmin
    
    {
        public IEnumerable<ModelViewAdmin> getAll();
        public List<phongban> getAllPhongBan();
        public void Add(ModelViewAdmin request);
        public void Update(ModelViewAdmin request);
        public bool Delete(int request);
        public ModelViewAdmin ViewDetail(int request);
        public ModelViewAdmin Detail(int id);
    }
}
