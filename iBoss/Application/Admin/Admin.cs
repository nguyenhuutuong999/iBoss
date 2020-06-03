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
    public class Admin : IAdmin
    {

        HumanDbContext _contextHuman;
        PayrollDbContext _contextPayroll;
        public Admin(HumanDbContext contextHuman, PayrollDbContext contextPayroll)
        {

            _contextHuman = contextHuman;
            _contextPayroll = contextPayroll;

        }
        public List<payrates> getAllPayrate()
        {
            return _contextPayroll.payratess.ToList<payrates>();
        }
        public IEnumerable<ModelViewAdmin> getAll()
        {

            var data = _contextHuman.PERSONALS.Join(
                 _contextHuman.EMPLOYMENTS,

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

                     EMPLOYMENT_STATUS = nhanvien.EMPLOYMENT_STATUS,
                     HIRE_DATE_FOR_WORKING = nhanvien.HIRE_DATE_FOR_WORKING,
                     NUMBER_DAYS_REQUIREMENT_OF_WORKING_PER_MONTH = nhanvien.NUMBER_DAYS_REQUIREMENT_OF_WORKING_PER_MONTH,

                 }

                 ).ToList<ModelViewHuman>();

            var data1 = data.Join(
            _contextPayroll.employees,
                human => human.EMPLOYEE_ID,
                payroll => payroll.EmployeeNumber,
                (human, payroll) => new ModelViewAdmin
                {
                    EMPLOYEE_ID = human.EMPLOYEE_ID,
                    CURRENT_FIRST_NAME = human.CURRENT_FIRST_NAME,
                    CURRENT_LAST_NAME = human.CURRENT_LAST_NAME,
                    BIRTH_DATE = human.BIRTH_DATE,
                    SOCIAL_SECURITY_NUMBER = human.SOCIAL_SECURITY_NUMBER,
                    CURRENT_ADDRESS_1 = human.CURRENT_ADDRESS_1,
                    CURRENT_GENDER = human.CURRENT_GENDER,
                    CURRENT_MARITAL_STATUS = human.CURRENT_MARITAL_STATUS,
                    CURRENT_PHONE_NUMBER = human.CURRENT_PHONE_NUMBER,
                    CURRENT_PERSONAL_EMAIL = human.CURRENT_PERSONAL_EMAIL,
                    HIRE_DATE_FOR_WORKING = human.HIRE_DATE_FOR_WORKING,
                    NUMBER_DAYS_REQUIREMENT_OF_WORKING_PER_MONTH = human.NUMBER_DAYS_REQUIREMENT_OF_WORKING_PER_MONTH,
                    EMPLOYMENT_STATUS = human.EMPLOYMENT_STATUS,

                    PayRate = payroll.PayRate,
                    PayRatesidPayRates = payroll.PayRatesidPayRates,
                    VacationDays = payroll.VacationDays,
                }
            ).ToList<ModelViewAdmin>();
            return data1;


        }
        public ModelViewAdmin Detail(int id)
        {
            var employment = _contextHuman.EMPLOYMENTS.Find(id);
            var personal = _contextHuman.PERSONALS.FromSqlRaw("SELECT * FROM PERSONAL where EMPLOYEE_ID ='" + id + "'").First<PERSONAL>();
            var employee = _contextPayroll.employees.FromSqlRaw("SELECT * FROM employee where EmployeeNumber ='" + id + "'").First<employee>();
            ModelViewAdmin model = new ModelViewAdmin
            {
                EMPLOYEE_ID = personal.EMPLOYEE_ID,
                CURRENT_FIRST_NAME = personal.CURRENT_FIRST_NAME,
                CURRENT_LAST_NAME = personal.CURRENT_LAST_NAME,
                BIRTH_DATE = personal.BIRTH_DATE,
                SOCIAL_SECURITY_NUMBER = personal.SOCIAL_SECURITY_NUMBER,
                CURRENT_ADDRESS_1 = personal.CURRENT_ADDRESS_1,
                CURRENT_GENDER = personal.CURRENT_GENDER,
                CURRENT_MARITAL_STATUS = personal.CURRENT_MARITAL_STATUS,
                CURRENT_PHONE_NUMBER = personal.CURRENT_PHONE_NUMBER,
                CURRENT_PERSONAL_EMAIL = personal.CURRENT_PERSONAL_EMAIL,

                HIRE_DATE_FOR_WORKING = employment.HIRE_DATE_FOR_WORKING,
                NUMBER_DAYS_REQUIREMENT_OF_WORKING_PER_MONTH = employment.NUMBER_DAYS_REQUIREMENT_OF_WORKING_PER_MONTH,
                EMPLOYMENT_STATUS = employment.EMPLOYMENT_STATUS,

                PayRate = employee.PayRate,
                PayRatesidPayRates = employee.PayRatesidPayRates,
                VacationDays = employee.VacationDays,
            };
            return model;
        }

        //    }

        public void Add(ModelViewAdmin request)
        {
            var id = _contextHuman.EMPLOYMENTS.Count<EMPLOYMENT>() + 1;
            EMPLOYMENT employment = new EMPLOYMENT
            {
                EMPLOYMENT_ID = id,
                HIRE_DATE_FOR_WORKING = request.HIRE_DATE_FOR_WORKING,
                EMPLOYMENT_STATUS = request.EMPLOYMENT_STATUS,
            };
            _contextHuman.EMPLOYMENTS.Add(employment);
            _contextHuman.SaveChanges();



            PERSONAL personal = new PERSONAL
            {
                EMPLOYEE_ID = id,
                CURRENT_FIRST_NAME = request.CURRENT_FIRST_NAME,
                CURRENT_LAST_NAME = request.CURRENT_LAST_NAME,
                BIRTH_DATE = request.BIRTH_DATE,
                SOCIAL_SECURITY_NUMBER = request.SOCIAL_SECURITY_NUMBER,
                CURRENT_ADDRESS_1 = request.CURRENT_ADDRESS_1,
                CURRENT_GENDER = request.CURRENT_GENDER,

                CURRENT_PHONE_NUMBER = request.CURRENT_PHONE_NUMBER,
                CURRENT_PERSONAL_EMAIL = request.CURRENT_PERSONAL_EMAIL,
            };
            _contextHuman.PERSONALS.Add(personal);
            _contextHuman.SaveChanges();

            employee employee = new employee
            {
                EmployeeNumber = id,
                idEmployee = id,
                LastName = request.CURRENT_LAST_NAME,
                FirstName = request.CURRENT_FIRST_NAME,
                PayRatesidPayRates = id,
                VacationDays = request.VacationDays,
            };
            _contextPayroll.employees.Add(employee);
            _contextPayroll.SaveChanges();

        }
        public void Update(ModelViewAdmin request)
        {
            var employment = _contextHuman.EMPLOYMENTS.Find(request.EMPLOYEE_ID);
            var personal = _contextHuman.PERSONALS.FromSqlRaw("SELECT * FROM PERSONAL where EMPLOYEE_ID ='" + request.EMPLOYEE_ID + "'").First<PERSONAL>();
            var employee = _contextPayroll.employees.FromSqlRaw("SELECT * FROM employee where EmployeeNumber ='" + request.EMPLOYEE_ID + "'").First<employee>();

            // update personal table
            personal.CURRENT_FIRST_NAME = request.CURRENT_FIRST_NAME;
            personal.CURRENT_LAST_NAME = request.CURRENT_LAST_NAME;
            personal.BIRTH_DATE = request.BIRTH_DATE;
            personal.SOCIAL_SECURITY_NUMBER = request.SOCIAL_SECURITY_NUMBER;
            personal.CURRENT_ADDRESS_1 = request.CURRENT_ADDRESS_1;
            personal.CURRENT_GENDER = request.CURRENT_GENDER;
            personal.CURRENT_PHONE_NUMBER = request.CURRENT_PHONE_NUMBER;
            personal.CURRENT_PERSONAL_EMAIL = request.CURRENT_PERSONAL_EMAIL;

            _contextHuman.SaveChanges();


            // update employment
            employment.HIRE_DATE_FOR_WORKING = request.HIRE_DATE_FOR_WORKING;
            employment.EMPLOYMENT_STATUS = request.EMPLOYMENT_STATUS;
        
            _contextHuman.SaveChanges();



            // update employee
            employee.LastName = request.CURRENT_LAST_NAME;
            employee.FirstName = request.CURRENT_FIRST_NAME;
            employee.PayRatesidPayRates = request.PayRatesidPayRates;
            employee.VacationDays = request.VacationDays;
          
          
            _contextPayroll.SaveChanges();
        }
        public bool Delete(int id)
        {
            try
            {
                var personal = _contextHuman.PERSONALS.FromSqlRaw("SELECT * FROM PERSONAL where EMPLOYEE_ID ='" + id + "'").First<PERSONAL>();
                _contextHuman.PERSONALS.Remove(personal);
                _contextHuman.SaveChanges();


                var employment = _contextHuman.EMPLOYMENTS.Find(id);
                _contextHuman.EMPLOYMENTS.Remove(employment);
                _contextHuman.SaveChanges();

                var employee = _contextPayroll.employees.FromSqlRaw("SELECT * FROM employee where EmployeeNumber ='" + id + "'").First<employee>();
                _contextPayroll.employees.Remove(employee);
                _contextPayroll.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
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

        //   

        //    public void Update(ModelViewAdmin request)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public ModelViewAdmin ViewDetail(int request)
        //    {
        //        throw new NotImplementedException();
        //    }
    }
}
