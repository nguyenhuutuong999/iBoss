
using iBoss.Models.EF;
using iBoss.Models.Entities.Payroll;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iBoss.Application.Payroll
{
    public class ManagePayroll : IManagePayroll
    {
        public PayrollDbContext _context;

        public ManagePayroll(PayrollDbContext context)
        {
            _context = context;
        }

        public List<payrates> getAllPayrate() {
            return _context.payratess.ToList<payrates>();
        }
        public ModelViewPayroll Detail(int id)
        {
            var nhanVien = _context.employees.Find(id);
            var luong = _context.payratess.Find(nhanVien.PayRatesidPayRates);

            ModelViewPayroll mdp = new ModelViewPayroll
            {
                idEmployee = nhanVien.idEmployee,
                EmployeeNumber = nhanVien.EmployeeNumber,
                LastName = nhanVien.LastName,
                FirstName = nhanVien.FirstName,
                SSN = nhanVien.SSN,
                PayRate = nhanVien.PayRate,
                VacationDays = nhanVien.VacationDays,

                PayRateName = luong.PayRateName,
                Value = luong.Value,
                TaxPercentage = luong.TaxPercentage,
                PayType = luong.PayType,
                PayAmount = luong.PayAmount,
                PTLevelC = luong.PTLevelC,
            };
            return mdp;
        }
        public void Add(ModelViewPayroll request)
        {
            var idE = _context.employees.Count<employee>() + 1;

            employee nhanvien = new employee
            {

                idEmployee = idE,
                EmployeeNumber = idE,
                LastName = request.LastName,
                FirstName = request.FirstName,
                SSN = request.SSN,
                PayRate = request.PayRate,
                PayRatesidPayRates = request.PayRatesidPayRates,
                VacationDays = request.VacationDays,
            };
            _context.employees.Add(nhanvien);
            _context.SaveChanges();

        }

        public bool Delete(int request)
        {
            try
            {
                var luong = _context.employees.FromSqlRaw("SELECT * FROM employee where EmployeeNumber ='" + request + "'").First<employee>();
                _context.employees.Remove(luong);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void Update(ModelViewPayroll request)
        {

            var nhanvien = _context.employees.FromSqlRaw("SELECT * FROM employee WHERE EmployeeNumber= '" + request.EmployeeNumber+"'").First<employee>();

            nhanvien.LastName = request.LastName;
            nhanvien.FirstName = request.FirstName;
            nhanvien.SSN = request.SSN;
            nhanvien.PayRate = request.PayRate;
            nhanvien.PayRatesidPayRates = request.PayRatesidPayRates;
            nhanvien.VacationDays = request.VacationDays;
           
            _context.SaveChanges();
        }


       

        public IEnumerable<ModelViewPayroll> getAll()
        {

            var data = _context.employees.Join(
                _context.payratess,


                 nhanVien => nhanVien.Payrates.idPayRates,
                   luong => luong.idPayRates,
                 (nhanVien, luong) => new ModelViewPayroll
                 {
                     idEmployee = nhanVien.idEmployee,
                     EmployeeNumber = nhanVien.EmployeeNumber,
                     LastName = nhanVien.LastName,
                     FirstName = nhanVien.FirstName,
                     SSN = nhanVien.SSN,
                     PayRate = nhanVien.PayRate,
                     VacationDays = nhanVien.VacationDays,
                     PayRatesidPayRates = nhanVien.PayRatesidPayRates,
                     PayRateName = luong.PayRateName,
                     Value = luong.Value,
                    
                     TaxPercentage = luong.TaxPercentage,

                     PayType = luong.PayType,
                     PayAmount = luong.PayAmount,
                     PTLevelC = luong.PTLevelC,

                 }

                ).ToList();
            return data;
        }
        public List<employee> getAllEmployee()
        {
            return _context.employees.ToList<employee>();
        }
        public List<payrates> getAllPay()
        {
            return _context.payratess.ToList<payrates>();
        }

        public List<employee> getBirthDayNhanVien(int id)
        {
            throw new NotImplementedException();
        }

      
        public employee ViewDetail(int id)
        {
            return _context.employees.FromSqlRaw("SELECT * FROM employee WHERE EmployeeNumber= '" + id + "'").First<employee>();
        }
        //// Update Payroll
        //public void Add(ModelViewPayroll request)
        //{


        //    NHANVIEN nhanvien = new NHANVIEN
        //    {

        //        HO = request.HO,
        //        TEN = request.TEN,
        //        NGAYSINH = request.NGAYSINH,
        //    };
        //    _context.NHANVIENS.Add(nhanvien);
        //    _context.SaveChanges();

        //    var maIDNhanVien = _context.NHANVIENS.FromSqlRaw("SELECT TOP 1 * FROM NHANVIEN ORDER BY MANHANVIEN DESC").SingleOrDefault<NHANVIEN>();

        //    LUONG luong = new LUONG
        //    {
        //        MANHANVIEN = maIDNhanVien.MANHANVIEN,
        //        HESOLUONG = request.HESOLUONG,
        //        NGAYNGHI = request.NGAYNGHI,
        //        LUONGCOBAN = request.LUONGCOBAN,
        //        SONGAYCONG = request.SONGAYCONG,
        //        LUONGTHUCLINH = request.LUONGTHUCLINH,
        //    };

        //    _context.LUONGS.Add(luong);
        //    _context.SaveChanges();

        //}



        //public int Delete(ModelViewPayroll request)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Update(ModelViewPayroll request)
        //{
        //    var luong = _context.LUONGS.FromSqlRaw("SELECT TOP 1 * FROM LUONG WHERE MANHANVIEN = '"+request.ID+"' ORDER BY MANHANVIEN DESC").SingleOrDefault<LUONG>();
        //    var nhanvien = _context.NHANVIENS.Find(request.ID);


        //    luong.NGAYNGHI = request.NGAYNGHI;
        //    luong.HESOLUONG = request.HESOLUONG;
        //    luong.LUONGCOBAN = request.LUONGCOBAN;
        //    luong.SONGAYCONG = request.SONGAYCONG;
        //    luong.LUONGTHUCLINH = request.LUONGTHUCLINH;


        //    nhanvien.HO = request.HO;
        //    nhanvien.TEN = request.TEN;
        //    nhanvien.NGAYSINH = request.NGAYSINH;


        //    _context.SaveChanges();
        //}

        //public ModelViewPayroll ViewDetail(int id)
        //{

        //    var luong = _context.LUONGS.FromSqlRaw("SELECT * FROM LUONG where MANHANVIEN ='"+id+"'").First<LUONG>();
        //    var nhanvien = _context.NHANVIENS.Find(id);
        //    ModelViewPayroll model = new ModelViewPayroll
        //    {
        //        MANHANVIEN = id,
        //        HO = nhanvien.HO,
        //        TEN = nhanvien.TEN,
        //        NGAYSINH = nhanvien.NGAYSINH,
        //        HESOLUONG = luong.HESOLUONG,
        //        NGAYNGHI = luong.NGAYNGHI,
        //        LUONGCOBAN = luong.LUONGCOBAN,
        //        SONGAYCONG = luong.SONGAYCONG,
        //        LUONGTHUCLINH = luong.LUONGTHUCLINH,

        //    };
        //    return model;
        //}

        //public ModelViewPayroll Detail(int id)
        //{
        //    var luong = _context.LUONGS.FromSqlRaw("SELECT * FROM LUONG where MANHANVIEN ='" + id + "'").First<LUONG>();
        //    var nhanvien = _context.NHANVIENS.Find(id);
        //    ModelViewPayroll model = new ModelViewPayroll
        //    {
        //        MANHANVIEN = id,
        //        HO = nhanvien.HO,
        //        TEN = nhanvien.TEN,
        //        NGAYSINH = nhanvien.NGAYSINH,
        //        HESOLUONG = luong.HESOLUONG,
        //        NGAYNGHI = luong.NGAYNGHI,
        //        LUONGCOBAN = luong.LUONGCOBAN,
        //        SONGAYCONG = luong.SONGAYCONG,
        //        LUONGTHUCLINH = luong.LUONGTHUCLINH,

        //    };
        //    return model;
        //}
        //public bool Delete(int id)
        //{
        //    try {
        //        var luong = _context.LUONGS.FromSqlRaw("SELECT * FROM LUONG where MANHANVIEN ='" + id + "'").First<LUONG>();
        //        _context.LUONGS.Remove(luong);
        //        _context.SaveChanges();
        //        var nhanvien = _context.NHANVIENS.Find(id);
        //        _context.NHANVIENS.Remove(nhanvien);
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }

        //}

        //public List<NHANVIEN> getBirthDayNhanVien(int id)
        //{
        //    return _context.NHANVIENS.FromSqlRaw("SELECT * FROM NHANVIEN WHERE MONTH(NGAYSINH) = '"+id+"'").ToList<NHANVIEN>();
        //}

        //public List<NHANVIEN> getAllNhanVien()
        //{
        //   return _context.NHANVIENS.ToList<NHANVIEN>();
        //}

        //public List<employee> getBirthDayNhanVien(int id)
        //{
        //    throw new NotImplementedException();
        //}


    }
}
