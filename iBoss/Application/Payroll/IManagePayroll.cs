using iBoss.Models.Entities.Payroll;
using System;
using System.Collections.Generic;
using System.Text;

namespace iBoss.Application.Payroll
{
    public interface IManagePayroll
    {

        public IEnumerable<ModelViewPayroll> getAll();
        public List<employee> getBirthDayNhanVien(int id);
        public List<employee> getAllEmployee();
        public List<payrates> getAllPayrate();
        public List<payrates> getAllPay();
        public void Add(ModelViewPayroll request);
        public void Update(ModelViewPayroll request);
        public bool Delete(int request);
        public employee ViewDetail(int request);
        public ModelViewPayroll Detail(int id);

    }
}
