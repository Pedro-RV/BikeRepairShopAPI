using Supplier_Bussiness.Interfaces;
using Supplier_Data;
using Supplier_Data.Context;
using Supplier_Entities.EntityModel;
using Supplier_Helper.ExceptionController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Bussiness
{
    public class EmployeeBussiness : IEmployeeBussiness
    {
        private SupplierContext dbContext;

        private ExceptionController exceptionController;

        public EmployeeBussiness()
        {
            SupplierContextProvider.InitializeSupplierContext();
            dbContext = SupplierContextProvider.GetSupplierContext();
            exceptionController = new ExceptionController();            
        }

        public List<Employee> EmployeesList()
        {
            EmployeeRepository employeeRepository = new EmployeeRepository(dbContext, exceptionController);

            List<Employee> ret = employeeRepository.EmployeesList();

            return ret;
        }

        public bool InsertEmployee(string EmployeeName, string Surname, string DNI, string Email, string EmployeeAddress, string CP, string MobileNum)
        {
            bool ret;

            try
            {
                //Comentario de prueba.
                Employee add = new Employee(EmployeeName, Surname, DNI, Email, EmployeeAddress, CP, MobileNum);

                EmployeeRepository employeeRepository = new EmployeeRepository(dbContext, exceptionController);

                ret = employeeRepository.Insert(add);
            }
            catch (SupplierException)
            {
                throw;
            }
            catch (MissingMethodException)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.MethodNotExist);
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);

            }

            return ret;
        }

        public Employee ReadEmployee(int EmployeeId)
        {
            Employee ret;

            try
            {              
                EmployeeRepository employeeRepository = new EmployeeRepository(dbContext, exceptionController);

                ret = employeeRepository.Read(EmployeeId);
            }
            catch (SupplierException)
            {
                throw;
            }
            catch (MissingMethodException)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.MethodNotExist);
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);

            }

            return ret;
        }

        public Employee ReadEmployeeDNI(string DNI)
        {
            Employee ret;

            try
            {
                EmployeeRepository employeeRepository = new EmployeeRepository(dbContext, exceptionController);

                ret = employeeRepository.ReadDNI(DNI);
            }
            catch (SupplierException)
            {
                throw;
            }
            catch (MissingMethodException)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.MethodNotExist);
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);

            }

            return ret;
        }

        public bool UpdateEmployee(int EmployeeId, string EmployeeName, string Surname, string DNI, string Email, string EmployeeAddress, string CP, string MobileNum)
        {
            bool ret;

            try
            {
                EmployeeRepository employeeRepository = new EmployeeRepository(dbContext, exceptionController);

                Employee update = employeeRepository.Read(EmployeeId);

                if (EmployeeName != null)
                {
                    update.EmployeeName = EmployeeName;
                }

                if (Surname != null)
                {
                    update.Surname = Surname;
                }

                if (DNI != null)
                {
                    update.DNI = DNI;
                }

                if (Email != null)
                {
                    update.Email = Email;
                }

                if (EmployeeAddress != null)
                {
                    update.EmployeeAddress = EmployeeAddress;
                }

                if (CP != null)
                {
                    update.CP = CP;
                }

                if (MobileNum != null)
                {
                    update.MobileNum = MobileNum;
                }

                ret = employeeRepository.Update(update);

            }
            catch (SupplierException)
            {
                throw;
            }
            catch (MissingMethodException)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.MethodNotExist);
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }

            return ret;
        }

        public bool DeleteEmployee(int EmployeeId)
        {
            bool ret;

            try
            {
                EmployeeRepository employeeRepository = new EmployeeRepository(dbContext, exceptionController);

                Employee del = employeeRepository.Read(EmployeeId);

                ret = employeeRepository.Delete(del);

            }
            catch (SupplierException)
            {
                throw;
            }
            catch (MissingMethodException)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.MethodNotExist);
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }

            return ret;
        }

    }
}   
