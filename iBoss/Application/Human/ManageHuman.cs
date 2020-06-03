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
           //return  _context.PERSONALS.ToList<PERSONAL>();

            var data = _context.PERSONALS.Join(
                _context.EMPLOYMENTS,

                canhan => canhan.EMPLOYEE_ID,
                nhanvien => nhanvien.EMPLOYMENT_ID,
                (canhan, nhanvien) => new ModelViewHuman
                {
                    EMPLOYEE_ID = canhan.EMPLOYEE_ID,
                    CURRENT_FIRST_NAME = canhan.CURRENT_FIRST_NAME,
                    CURRENT_LAST_NAME = canhan.CURRENT_LAST_NAME,
                    BIRTH_DATE = canhan.BIRTH_DATE,
                    SOCIAL_SECURITY_NUMBER = canhan.SOCIAL_SECURITY_NUMBER,
                    CURRENT_ADDRESS_1 = canhan.CURRENT_ADDRESS_1,
                    CURRENT_GENDER = canhan.CURRENT_GENDER,
                    CURRENT_MARITAL_STATUS = canhan.CURRENT_MARITAL_STATUS,
                    CURRENT_PHONE_NUMBER = canhan.CURRENT_PHONE_NUMBER,
                    CURRENT_PERSONAL_EMAIL = canhan.CURRENT_PERSONAL_EMAIL,
                    HIRE_DATE_FOR_WORKING = nhanvien.HIRE_DATE_FOR_WORKING,
                    NUMBER_DAYS_REQUIREMENT_OF_WORKING_PER_MONTH = nhanvien.NUMBER_DAYS_REQUIREMENT_OF_WORKING_PER_MONTH,
                }

                ).ToList();
            return data;
        }
        public ModelViewHuman Detail(int id)
        {

            var nhanvien = _context.EMPLOYMENTS.Find(id);

            var canhan = _context.PERSONALS.FromSqlRaw("SELECT * FROM PERSONAL where EMPLOYEE_ID ='" + id + "'").First<PERSONAL>();
            ModelViewHuman model = new ModelViewHuman
            {

                EMPLOYEE_ID = id,
                CURRENT_FIRST_NAME = canhan.CURRENT_FIRST_NAME,
                CURRENT_LAST_NAME = canhan.CURRENT_LAST_NAME,
                BIRTH_DATE = canhan.BIRTH_DATE,
                SOCIAL_SECURITY_NUMBER = canhan.SOCIAL_SECURITY_NUMBER,
                CURRENT_ADDRESS_1 = canhan.CURRENT_ADDRESS_1,
                CURRENT_GENDER = canhan.CURRENT_GENDER,
                CURRENT_MARITAL_STATUS = canhan.CURRENT_MARITAL_STATUS,
                CURRENT_PHONE_NUMBER = canhan.CURRENT_PHONE_NUMBER,
                CURRENT_PERSONAL_EMAIL = canhan.CURRENT_PERSONAL_EMAIL,
                HIRE_DATE_FOR_WORKING = nhanvien.HIRE_DATE_FOR_WORKING,
                NUMBER_DAYS_REQUIREMENT_OF_WORKING_PER_MONTH = nhanvien.NUMBER_DAYS_REQUIREMENT_OF_WORKING_PER_MONTH,
            };
            return model;
        }
        public void Add(ModelViewHuman request)
        {
            var maNhanVien = _context.PERSONALS.Count<PERSONAL>() + 1;

            EMPLOYMENT nhanvien = new EMPLOYMENT
            {
                EMPLOYMENT_ID = maNhanVien,
                HIRE_DATE_FOR_WORKING = request.HIRE_DATE_FOR_WORKING,
                NUMBER_DAYS_REQUIREMENT_OF_WORKING_PER_MONTH = request.NUMBER_DAYS_REQUIREMENT_OF_WORKING_PER_MONTH,
            };
            _context.EMPLOYMENTS.Add(nhanvien);
            _context.SaveChanges();

          

            PERSONAL canhan = new PERSONAL
            {
                
                EMPLOYEE_ID = maNhanVien,
                CURRENT_FIRST_NAME = request.CURRENT_FIRST_NAME,
                CURRENT_LAST_NAME = request.CURRENT_LAST_NAME,
                BIRTH_DATE = request.BIRTH_DATE,
                CURRENT_ADDRESS_1 = request.CURRENT_ADDRESS_1,
                CURRENT_GENDER = request.CURRENT_GENDER,
                CURRENT_PHONE_NUMBER = request.CURRENT_PHONE_NUMBER,
                CURRENT_PERSONAL_EMAIL = request.CURRENT_PERSONAL_EMAIL,
            };
            _context.PERSONALS.Add(canhan);
            _context.SaveChanges();


        }
        public void Update(ModelViewHuman request)
        {
            var canhan = _context.PERSONALS.FromSqlRaw("SELECT * FROM PERSONAL WHERE PERSONAL_ID ='" + request.EMPLOYEE_ID + "' ").First<PERSONAL>();
            canhan.CURRENT_FIRST_NAME = request.CURRENT_FIRST_NAME;
            canhan.CURRENT_LAST_NAME = request.CURRENT_LAST_NAME;
            canhan.BIRTH_DATE = request.BIRTH_DATE;
            canhan.CURRENT_ADDRESS_1 = request.CURRENT_ADDRESS_1;
            canhan.CURRENT_GENDER = request.CURRENT_GENDER;
            canhan.CURRENT_PHONE_NUMBER = request.CURRENT_PHONE_NUMBER;
            canhan.CURRENT_PERSONAL_EMAIL = request.CURRENT_PERSONAL_EMAIL;


            var nhanvien = _context.EMPLOYMENTS.Find(request.EMPLOYEE_ID);
            nhanvien.HIRE_DATE_FOR_WORKING = request.HIRE_DATE_FOR_WORKING;
            nhanvien.NUMBER_DAYS_REQUIREMENT_OF_WORKING_PER_MONTH = request.NUMBER_DAYS_REQUIREMENT_OF_WORKING_PER_MONTH;

            _context.SaveChanges();
        }
      

        //public bool Delete(int request)
        //{
        //    try {
        //        var nhanvien = _context.nhanviens.FromSqlRaw("Select * FROM nhanvien Where MANHANVIEN = '" + request + "'").First<nhanvien>();
        //        _context.nhanviens.Remove(nhanvien);
        //        _context.SaveChanges();
        //        return true;
        //    } 
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

       
       

        ////get PhongBan's List to show select option of TENPHONGBAN
        //public List<phongban> getAllPhongBan()
        //{
        //    return _context.phongbans.ToList<phongban>();
        //}
        
       
       
        public List<PERSONAL> getBirthDayNhanVien(int id)
        {
            return _context.PERSONALS.FromSqlRaw("SELECT * FROM PERSONAL WHERE MONTH(BIRTH_DATE) = '" + id + "'").ToList<PERSONAL>();
        }

        public PERSONAL Search(int id)
        {
            throw new NotImplementedException();
        }
    }
}
