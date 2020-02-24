using AutoMapper;
using InterconnectServicesLibrary.Entities.SupplierSpecific;
using Supplier_Bussiness.Interfaces;
using Supplier_Data;
using Supplier_Data.Context;
using Supplier_Data.Interfaces;
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
        private IExceptionController exceptionController;

        private IEmployeeRepository employeeRepository;

        private IMapper mapper;

        public EmployeeBussiness(IExceptionController exceptionController,
            IEmployeeRepository employeeRepository
            )
        {
            this.exceptionController = exceptionController;
            this.employeeRepository = employeeRepository;


            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeSpecific, Employee>();
            });

            mapper = config.CreateMapper();
        }

        public List<Employee> EmployeesList()
        {
            List<Employee> ret = this.employeeRepository.EmployeesList();

            return ret;
        }

        public bool InsertEmployee(EmployeeSpecific employeeSpecific)
        {
            bool ret;

            try
            {                
                Employee employeeAdd = mapper.Map<EmployeeSpecific, Employee>(employeeSpecific);

                ret = this.employeeRepository.Insert(employeeAdd);
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
                ret = this.employeeRepository.Read(EmployeeId);
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
                ret = this.employeeRepository.ReadDNI(DNI);
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
                Employee current = this.employeeRepository.Read(update.EmployeeId);

                current.EmployeeName = !string.IsNullOrEmpty(update.EmployeeName) ? update.EmployeeName : current.EmployeeName;
                current.Surname = !string.IsNullOrEmpty(update.Surname) ? update.Surname : current.Surname;
                current.Email = !string.IsNullOrEmpty(update.Email) ? update.Email : current.Email;
                current.DNI = !string.IsNullOrEmpty(update.DNI) ? update.DNI : current.DNI;
                current.EmployeeAddress = !string.IsNullOrEmpty(update.EmployeeAddress) ? update.EmployeeAddress : current.EmployeeAddress;
                current.CP = !string.IsNullOrEmpty(update.CP) ? update.CP : current.CP;
                current.MobileNum = !string.IsNullOrEmpty(update.MobileNum) ? update.MobileNum : current.MobileNum;

                ret = this.employeeRepository.Update(current);

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
                Employee del = this.employeeRepository.Read(EmployeeId);

                ret = this.employeeRepository.Delete(del);

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
