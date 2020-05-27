using iBoss.Application.Human;
using iBoss.Application.Payroll;
using iBoss.Models.EF;
using iBoss.Models.Entities.Admin;
using iBoss.Models.Entities.Human;
using iBoss.Models.Entities.Payroll;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iBoss.Application.Admin
{
    //public class Admin : IAdmin
    //{
    //    AdminDbContext _context;
    //   HumanDbContext _contextHuman;
    //    PayrollDbContext _contextPayroll;
    //    public Admin(HumanDbContext contextHuman, PayrollDbContext contextPayroll, AdminDbContext context)
    //    {
    //        _context = context;
    //        _contextHuman = contextHuman;
    //        _contextPayroll = contextPayroll;

    //    }

    //    public IEnumerable<ModelViewAdmin> getAll()
    //    {

    //        var data = _contextHuman.nhanviens.Join(
    //           _contextHuman.phongbans,

    //           nhanvien => nhanvien.phongban.MAPHONGBAN,
    //           phongban => phongban.MAPHONGBAN,
    //           (nhanvien, phongban) => new ModelViewAdmin
    //           {

    //               MANHANVIEN = nhanvien.MANHANVIEN,
    //               MAPHONGBAN = nhanvien.MAPHONGBAN,
    //               HO = nhanvien.HO,
    //               TEN = nhanvien.TEN,
    //               NGAYSINH = Convert.ToDateTime(nhanvien.NGAYSINH),
    //               GIOITINH = nhanvien.GIOITINH,
    //               DIACHI = nhanvien.DIACHI,
    //               TENPHONGBAN = phongban.TENPHONGBAN,
    //           }

    //           ).ToList();
    //        return data;

            
    //    }

    //    public void Add(ModelViewAdmin request)
    //    {
    //        nhanvien nhanvien = new nhanvien
    //        {
    //            HO = request.HO,
    //            TEN = request.TEN,
    //            NGAYSINH = request.NGAYSINH,
    //            GIOITINH = request.GIOITINH,
    //            DIACHI = request.DIACHI,
    //            MAPHONGBAN = request.MAPHONGBAN,
    //        };
    //        _contextHuman.nhanviens.Add(nhanvien);
    //        _contextHuman.SaveChanges();

           
    //        var maIDNhanVien = _contextHuman.nhanviens.FromSqlRaw("SELECT TOP 1 * FROM nhanvien ORDER BY MANHANVIEN DESC").SingleOrDefault<nhanvien>();

    //        NHANVIEN NHANVIEN = new NHANVIEN
    //        {
    //            MANHANVIEN = maIDNhanVien.MANHANVIEN,
    //            HO = request.HO,
    //            TEN = request.TEN,
    //            NGAYSINH = request.NGAYSINH,
    //        };
    //        _contextPayroll.NHANVIENS.Add(NHANVIEN);
    //        _contextPayroll.SaveChanges();

    //    }
    //    public List<phongban> getAllPhongBan()
    //    {
    //        return _contextHuman.phongbans.ToList<phongban>();
    //    }

    //    //public bool Delete(int request)
    //    //{
    //    //    try
    //    //    {
    //    //        var nhanvien = _contextHuman.nhanviens.FromSqlRaw("Select * FROM nhanvien Where MANHANVIEN = '" + request + "'").First<nhanvien>();
    //    //        _contextHuman.nhanviens.Remove(nhanvien);
    //    //        _contextHuman.SaveChanges();


    //    //        var luong = _contextPayroll.LUONGS.FromSqlRaw("Select * FROM LUONG Where MANHANVIEN = '" + request + "'").First<LUONG>();
    //    //        _contextPayroll.LUONGS.Remove(luong);
    //    //        _contextPayroll.SaveChanges();

    //    //        var NHANVIEN = _contextPayroll.NHANVIENS.FromSqlRaw("Select * FROM NHANVIEN Where MANHANVIEN = '" + request + "'").First<NHANVIEN>();
    //    //        _contextPayroll.NHANVIENS.Remove(NHANVIEN);
    //    //        _contextPayroll.SaveChanges();

    //    //        return true;
    //    //    }
    //    //    catch (Exception)
    //    //    {
    //    //        return false;
    //    //    }
    //    //}

    //    public ModelViewAdmin Detail(int id)
    //    {
    //        var nhanvien = _contextHuman.nhanviens.Find(id);
    //        var maPhongBan = nhanvien.MAPHONGBAN;
    //        var phongban = _contextHuman.phongbans.FromSqlRaw("SELECT * FROM phongban where MAPHONGBAN ='" + maPhongBan + "'").First<phongban>();
    //        ModelViewAdmin model = new ModelViewAdmin
    //        {
    //            MANHANVIEN = id,
    //            MAPHONGBAN = nhanvien.MAPHONGBAN,
    //            HO = nhanvien.HO,
    //            TEN = nhanvien.TEN,
    //            NGAYSINH = nhanvien.NGAYSINH,
    //            GIOITINH = nhanvien.GIOITINH,
    //            DIACHI = nhanvien.DIACHI,
    //            TENPHONGBAN = phongban.TENPHONGBAN,
    //        };
    //        return model;
    //    }

    //    public void Update(ModelViewAdmin request)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public ModelViewAdmin ViewDetail(int request)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
