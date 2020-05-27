using iBoss.Models.EF;
using iBoss.Models.Entities.Human;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iBoss.Application.Human
{
    public class ManageHuman : IManageHuman
    {
        public HumanDbContext _context;

        public ManageHuman(HumanDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ModelViewHuman> getAll()
        {

            var data = _context.nhanviens.Join(
                _context.phongbans,

                nhanvien => nhanvien.phongban.MAPHONGBAN,
                phongban => phongban.MAPHONGBAN,
                (nhanvien, phongban) => new ModelViewHuman
                {

                    MANHANVIEN = nhanvien.MANHANVIEN,
                    MAPHONGBAN = nhanvien.MAPHONGBAN,
                    HO = nhanvien.HO,
                    TEN = nhanvien.TEN,
                    NGAYSINH = Convert.ToDateTime(nhanvien.NGAYSINH),
                    GIOITINH = nhanvien.GIOITINH,
                    DIACHI = nhanvien.DIACHI,
                    TENPHONGBAN = phongban.TENPHONGBAN,
                }

                ).ToList();
            return data;
        }
        public void Add(ModelViewHuman request)
        {
            var maNhanVien = _context.nhanviens.Count<nhanvien>()+1; 

            nhanvien nhanvien = new nhanvien
            {
                MANHANVIEN = maNhanVien,
                HO = request.HO,
                TEN = request.TEN,
                NGAYSINH = request.NGAYSINH,
                GIOITINH = request.GIOITINH,
                DIACHI = request.DIACHI,
                MAPHONGBAN = request.MAPHONGBAN,
            };
            _context.nhanviens.Add(nhanvien);
            _context.SaveChanges();

        }
        public void Update(ModelViewHuman request)
        {

            var nhanvien = _context.nhanviens.Find(request.MANHANVIEN);
            nhanvien.HO = request.HO;
            nhanvien.TEN = request.TEN;
            nhanvien.NGAYSINH = request.NGAYSINH;
            nhanvien.GIOITINH = request.GIOITINH;
            nhanvien.DIACHI = request.DIACHI;
            nhanvien.MAPHONGBAN = request.MAPHONGBAN;
            _context.SaveChanges();
        }

        public bool Delete(int request)
        {
            try {
                var nhanvien = _context.nhanviens.FromSqlRaw("Select * FROM nhanvien Where MANHANVIEN = '" + request + "'").First<nhanvien>();
                _context.nhanviens.Remove(nhanvien);
                _context.SaveChanges();
                return true;
            } 
            catch (Exception)
            {
                return false;
            }
        }

        public ModelViewHuman Detail(int id)
        {
            
            var nhanvien = _context.nhanviens.Find(id);
            var maPhongBan = nhanvien.MAPHONGBAN;
            var phongban = _context.phongbans.FromSqlRaw("SELECT * FROM phongban where MAPHONGBAN ='" + maPhongBan + "'").First<phongban>();
            ModelViewHuman model = new ModelViewHuman
            {
                MANHANVIEN = id,
                MAPHONGBAN = nhanvien.MAPHONGBAN,
                HO = nhanvien.HO,
                TEN = nhanvien.TEN,
                NGAYSINH = nhanvien.NGAYSINH,
                GIOITINH  = nhanvien.GIOITINH,
                DIACHI = nhanvien.DIACHI,
                TENPHONGBAN = phongban.TENPHONGBAN,
            };
            return model;
        }
        
       

        //get PhongBan's List to show select option of TENPHONGBAN
        public List<phongban> getAllPhongBan()
        {
            return _context.phongbans.ToList<phongban>();
        }
        
       
        public ModelViewHuman ViewDetail(int request)
        {
            var nhanvien = _context.nhanviens.Find(request);

            var pban = _context.phongbans.FromSqlRaw("SELECT * FROM phongban where MAPHONGBAN ='" + nhanvien.MAPHONGBAN + "'").First<phongban>();
            
            ModelViewHuman model = new ModelViewHuman
            {
                MANHANVIEN = request,
                MAPHONGBAN = nhanvien.MAPHONGBAN,
                HO = nhanvien.HO,
                TEN = nhanvien.TEN,
                NGAYSINH = Convert.ToDateTime(nhanvien.NGAYSINH),
                GIOITINH = nhanvien.GIOITINH,
                DIACHI = nhanvien.DIACHI,
                TENPHONGBAN = pban.TENPHONGBAN,

            };
            return model;
        }
        public List<nhanvien> getBirthDayNhanVien(int id)
        {
            return _context.nhanviens.FromSqlRaw("SELECT * FROM nhanvien WHERE MONTH(NGAYSINH) = '" + id + "'").ToList<nhanvien>();
        }
        

    }
}
