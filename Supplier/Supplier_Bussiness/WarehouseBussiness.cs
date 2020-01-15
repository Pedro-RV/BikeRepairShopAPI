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
    public class WarehouseBussiness : IWarehouseBussiness
    {
        private SupplierContext dbContext;

        private ExceptionController exceptionController;

        public WarehouseBussiness()
        {
            SupplierContextProvider.InitializeSupplierContext();
            dbContext = SupplierContextProvider.GetSupplierContext();
            exceptionController = new ExceptionController();
        }

        public List<Warehouse> WarehousesBiggerThanAnExtensionList(int extension)
        {
            WarehouseRepository warehouseRepository = new WarehouseRepository(dbContext, exceptionController);

            List<Warehouse> ret = warehouseRepository.WarehousesBiggerThanAnExtensionList(extension);

            return ret;
        }

        public List<WarehouseData> WarehouseDataList()
        {
            WarehouseRepository warehouseRepository = new WarehouseRepository(dbContext, exceptionController);

            List<WarehouseData> ret = warehouseRepository.WarehouseDataList();

            return ret;
        }

        public bool InsertWarehouse(string WarehouseAddress, int Extension, int WarehouseAdminId)
        {
            bool ret;

            try
            {
                WarehouseAdminRepository warehouseAdminRepository = new WarehouseAdminRepository(dbContext, exceptionController);
                WarehouseAdmin attach = warehouseAdminRepository.Read(WarehouseAdminId);
                Warehouse add = new Warehouse(WarehouseAddress, Extension, attach);

                WarehouseRepository warehouseRepository = new WarehouseRepository(dbContext, exceptionController);

                ret = warehouseRepository.Insert(add);

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

        public bool InsertWarehouseAndAdmin(string WarehouseAddress, int Extension, DateTime StartDate, int EmployeeId)
        {
            bool ret;

            try
            {
                EmployeeRepository employeeRepository = new EmployeeRepository(dbContext, exceptionController);
                Employee attach = employeeRepository.Read(EmployeeId);
                WarehouseAdmin add = new WarehouseAdmin(StartDate, attach);

                WarehouseAdminRepository warehouseAdminRepository = new WarehouseAdminRepository(dbContext, exceptionController);

                bool ret2 = warehouseAdminRepository.Insert(add);

                WarehouseAdmin attach2 = warehouseAdminRepository.Read(add.WarehouseAdminId);
                Warehouse add2 = new Warehouse(WarehouseAddress, Extension, add);

                WarehouseRepository warehouseRepository = new WarehouseRepository(dbContext, exceptionController);

                bool ret3 = warehouseRepository.Insert(add2);

                ret = (ret2 && ret3);

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

        public Warehouse ReadWarehouse(int WarehouseId)
        {
            Warehouse ret;

            try
            {
                WarehouseRepository warehouseRepository = new WarehouseRepository(dbContext, exceptionController);

                ret = warehouseRepository.Read(WarehouseId);

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

        public bool UpdateWarehouse(Warehouse update)
        {
            bool ret;

            try
            {
                WarehouseRepository warehouseRepository = new WarehouseRepository(dbContext, exceptionController);

                Warehouse current = warehouseRepository.Read(update.WarehouseId);

                current = update;

                ret = warehouseRepository.Update(current);

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

        public bool DeleteWarehouse(int WarehouseId)
        {
            bool ret;

            try
            {
                WarehouseRepository warehouseRepository = new WarehouseRepository(dbContext, exceptionController);

                Warehouse del = warehouseRepository.Read(WarehouseId);

                ret = warehouseRepository.Delete(del);

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
