using Autofac;
using Supplier_Bussiness;
using Supplier_Bussiness.Interfaces;
using Supplier_Entities.EntityModel;
using Supplier_Entities.Specific;
using Supplier_Helper.Authentication;
using Supplier_Helper.ExceptionController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Http.Headers;

namespace Supplier_Service.Controllers
{
    public class EmployeeController : BaseController
    {
        private IEmployeeBussiness employeeBussiness;
        private IExceptionController exceptionController;
        private IAuthenticationProvider authenticationProvider;

        public EmployeeController(IEmployeeBussiness employeeBussiness,
            IExceptionController exceptionController,
            IAuthenticationProvider authenticationProvider)
        {
            this.employeeBussiness = employeeBussiness;
            this.exceptionController = exceptionController;
            this.authenticationProvider = authenticationProvider;

        }

        // GET
        [HttpGet]
        [Route("api/employee/EmployeesList")]
        public List<Employee> EmployeesList()
        {
            try
            {
                var request = Request;
                HttpRequestHeaders headers = null;

                if(request != null)
                {
                    headers = request.Headers;
                }

                if (!this.authenticationProvider.CheckAuthentication(headers))
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.AuthenticationError);
                }

                List<Employee> result = this.employeeBussiness.EmployeesList();

                return result;

            }
            catch (SupplierException)
            {
                throw;
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }

        }                 

        // GET
        [HttpGet]
        [Route("api/employee/GetEmployee/{employeeId}")]
        public Employee GetEmployee(int employeeId)
        {
            try 
            {
                var request = Request;
                HttpRequestHeaders headers = null;

                if (request != null)
                {
                    headers = request.Headers;
                }

                if (!this.authenticationProvider.CheckAuthentication(headers))
                { 
                    throw this.exceptionController.CreateMyException(ExceptionEnum.AuthenticationError);
                }

                Employee result = this.employeeBussiness.ReadEmployee(employeeId);

                return result;

            }
            catch (SupplierException)
            {
                throw;
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }
            
        }

        // GET
        [HttpGet]
        [Route("api/employee/GetEmployeeDNI/{dni}")]
        public Employee GetEmployeeDNI(string dni)
        {
            try
            {
                var request = Request;
                HttpRequestHeaders headers = null;

                if (request != null)
                {
                    headers = request.Headers;
                }

                if (!this.authenticationProvider.CheckAuthentication(headers))
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.AuthenticationError);
                }

                Employee result = this.employeeBussiness.ReadEmployeeDNI(dni);

                return result;

            }
            catch (SupplierException)
            {
                throw;
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }
        }

        // POST
        [HttpPost]
        [Route("api/employee/InsertEmployee")]
        public string InsertEmployee(EmployeeSpecific employeeSpecific)
        {
            try
            {
                var request = Request;
                HttpRequestHeaders headers = null;

                if(request != null)
                {
                    headers = request.Headers;
                }

                if (!this.authenticationProvider.CheckAuthentication(headers))
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.AuthenticationError);
                }

                bool introduced_well = this.employeeBussiness.InsertEmployee(employeeSpecific);

                if (introduced_well == true)
                {
                    return "Action completed satisfactorily.";
                }
                else
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.ActionNotCompleted);
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
        }

        // PUT
        [HttpPut]
        [Route("api/employee/UpdateEmployee")]
        public string UpdateEmployee(EmployeeSpecific update)
        {
            try
            {
                var request = Request;
                HttpRequestHeaders headers = null;

                if (request != null)
                {
                    headers = request.Headers;
                }

                if (!this.authenticationProvider.CheckAuthentication(headers))
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.AuthenticationError);
                }

                bool updated_well = this.employeeBussiness.UpdateEmployee(update);

                if (updated_well == true)
                {
                    return "Action completed satisfactorily.";
                }
                else
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.ActionNotCompleted);
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
        }

        // DELETE
        [HttpDelete]
        [Route("api/employee/DeleteEmployee/{employeeId}")]
        public string DeleteEmployee(int employeeId)
        {
            try
            {
                var request = Request;
                HttpRequestHeaders headers = null;

                if (request != null)
                {
                    headers = request.Headers;
                }

                if (!this.authenticationProvider.CheckAuthentication(headers))
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.AuthenticationError);
                }

                bool deleted_well = this.employeeBussiness.DeleteEmployee(employeeId);

                if (deleted_well == true)
                {
                    return "Action completed satisfactorily.";
                }
                else
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.ActionNotCompleted);
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
        }
    }
}
