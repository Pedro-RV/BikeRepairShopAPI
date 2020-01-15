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
    public class WarehouseAdminBussiness : IWarehouseAdminBussiness
    {
        private SupplierContext dbContext;

        private ExceptionController exceptionController;

        public WarehouseAdminBussiness()
        {
            SupplierContextProvider.InitializeSupplierContext();
            dbContext = SupplierContextProvider.GetSupplierContext();
            exceptionController = new ExceptionController();
        }

        public bool InsertWarehouseAdmin(DateTime StartDate, int EmployeeId)
        {
            bool ret;

            try
            {
                EmployeeRepository employeeRepository = new EmployeeRepository(dbContext, exceptionController);
                Employee attach = employeeRepository.Read(EmployeeId);
                WarehouseAdmin add = new WarehouseAdmin(StartDate, attach);

                WarehouseAdminRepository warehouseAdminRepository = new WarehouseAdminRepository(dbContext, exceptionController);

                ret = warehouseAdminRepository.Insert(add);

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

        public WarehouseAdmin ReadWarehouseAdmin(int WarehouseAdminId)
        {
            WarehouseAdmin ret;

            try
            {
                WarehouseAdminRepository warehouseAdminRepository = new WarehouseAdminRepository(dbContext, exceptionController);

                ret = warehouseAdminRepository.Read(WarehouseAdminId);

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

        public bool UpdateWarehouseAdmin(WarehouseAdmin update)
        {
            bool ret;

            try
            {
                WarehouseAdminRepository warehouseAdminRepository = new WarehouseAdminRepository(dbContext, exceptionController);

                WarehouseAdmin current = warehouseAdminRepository.Read(update.WarehouseAdminId);

                current = update;

                ret = warehouseAdminRepository.Update(current);

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

        public bool DeleteWarehouseAdmin(int WarehouseAdminId)
        {
            bool ret;

            try
            {
                WarehouseAdminRepository warehouseAdminRepository = new WarehouseAdminRepository(dbContext, exceptionController);

                WarehouseAdmin del = warehouseAdminRepository.Read(WarehouseAdminId);

                ret = warehouseAdminRepository.Delete(del);

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
