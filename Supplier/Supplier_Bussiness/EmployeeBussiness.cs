using AutoMapper;
using Supplier_Bussiness.Interfaces;
using Supplier_Data;
using Supplier_Data.Context;
using Supplier_Entities.EntityModel;
using Supplier_Entities.Specific;
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

        private IMapper mapper;

        public EmployeeBussiness()
        {
            SupplierContextProvider.InitializeSupplierContext();
            dbContext = SupplierContextProvider.GetSupplierContext();
            exceptionController = new ExceptionController();


            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeSpecific, Employee>();
            });

            mapper = config.CreateMapper();
        }

        public List<Employee> EmployeesList()
        {
            EmployeeRepository employeeRepository = new EmployeeRepository(dbContext, exceptionController);

            List<Employee> ret = employeeRepository.EmployeesList();

            return ret;
        }

        public bool InsertEmployee(EmployeeSpecific employeeSpecific)
        {
            bool ret;

            try
            {
                EmployeeRepository employeeRepository = new EmployeeRepository(dbContext, exceptionController);
                
                Employee employeeAdd = mapper.Map<EmployeeSpecific, Employee>(employeeSpecific);

                ret = employeeRepository.Insert(employeeAdd);
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

        public bool UpdateEmployee(EmployeeSpecific update)
        {
            bool ret;

            try
            {
                EmployeeRepository employeeRepository = new EmployeeRepository(dbContext, exceptionController);

                Employee current = employeeRepository.Read(update.EmployeeId);

                current.EmployeeName = !String.IsNullOrEmpty(update.EmployeeName) ? update.EmployeeName : current.EmployeeName;
                current.Surname = !String.IsNullOrEmpty(update.Surname) ? update.Surname : current.Surname;
                current.Email = !String.IsNullOrEmpty(update.Email) ? update.Email : current.Email;
                current.DNI = !String.IsNullOrEmpty(update.DNI) ? update.DNI : current.DNI;
                current.Email = !String.IsNullOrEmpty(update.Email) ? update.Email : current.Email;
                current.CP = !String.IsNullOrEmpty(update.CP) ? update.CP : current.CP;
                current.MobileNum = !String.IsNullOrEmpty(update.MobileNum) ? update.MobileNum : current.MobileNum;

                ret = employeeRepository.Update(current);

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
