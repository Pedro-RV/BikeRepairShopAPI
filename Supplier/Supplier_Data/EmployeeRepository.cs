using Supplier_Entities.EntityModel;
using Supplier_Data.Context;
using System.Linq;
using System.Data.Entity;
using Supplier_Data.Interfaces;
using System;
using Supplier_Helper.ExceptionController;
using System.Collections.Generic;

namespace Supplier_Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private SupplierContext dbContext;

        private ExceptionController exceptionController;

        public EmployeeRepository(SupplierContext dbContext, ExceptionController exceptionController)
        {
            this.dbContext = dbContext;
            this.exceptionController = exceptionController;
        }

        public List<Employee> EmployeesList()
        {
            List<Employee> ret = dbContext.Employee.ToList();

            return ret;
        }

        public bool Insert(Employee add)
        {
            bool result;

            try
            {
                if (add == null)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.NullObject);
                }

                if (add.DNI == null)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.NullDNI);
                }              

                dbContext.Employee.Add(add);
                dbContext.SaveChanges();
                result = true;

            }
            catch (SupplierException)
            {
                throw;
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }

            return result;
        }

        public Employee Read(int EmployeeId)
        {
            Employee ret;

            try
            {
                ret = dbContext.Employee.Where(x => x.EmployeeId == EmployeeId).FirstOrDefault();

                if (ret == null)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.ObjectNotFound);
                }

            }
            catch (SupplierException)
            {
                throw;
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }

            return ret;
        }

        public Employee ReadDNI(string DNI)
        {
            Employee ret;

            try
            {
                ret = dbContext.Employee.Where(x => x.DNI == DNI).FirstOrDefault();

                if (ret == null)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.ObjectNotFound);
                }

            }
            catch (SupplierException)
            {
                throw;
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }

            return ret;
        }

        public bool Update(Employee update)
        {
            bool ret = false;
            bool exist = Lookfor(update);

            try
            {

                if (!exist)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.ObjectNotFound);
                }
                
                dbContext.Entry(update).State = EntityState.Modified;
                dbContext.SaveChanges();
                ret = true;

            }
            catch (SupplierException)
            {
                throw;
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }

            return ret;
        }

        public bool Delete(Employee del)
        {
            bool ret = false;
            bool exist = Lookfor(del);

            try
            {
                if (!exist)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.ObjectNotFound);
                }

                dbContext.Entry(del).State = EntityState.Deleted;
                dbContext.SaveChanges();
                ret = true;
  
            }
            catch (SupplierException)
            {
                throw;
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }

            return ret;
        }

        private bool Lookfor(Employee orig)
        {
            bool found;

            found = dbContext.Employee.Any(x => x.EmployeeId == orig.EmployeeId);

            return found;
        }

    }
}
