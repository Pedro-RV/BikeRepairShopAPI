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

        public List<WarehouseData> WarehouseDataList(string warehouseAddress)
        {
            WarehouseRepository warehouseRepository = new WarehouseRepository(dbContext, exceptionController);

            //List<WarehouseData> ret = warehouseRepository.WarehouseDataList();

            //Llamar a la de Dapper
            List<WarehouseData> ret = warehouseRepository.WarehouseDataListWithDapper(warehouseAddress);

            return ret;
        }

        public bool InsertWarehouse(Warehouse warehouseAdd)
        {
            bool ret;

            try
            {
                WarehouseRepository warehouseRepository = new WarehouseRepository(dbContext, exceptionController);

                ret = warehouseRepository.Insert(warehouseAdd);

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

        public bool InsertWarehouseAndAdmin(WarehouseAdmin warehouseAdminAdd, Warehouse warehouseAdd)
        {
            bool ret;

            try
            {
                WarehouseAdminRepository warehouseAdminRepository = new WarehouseAdminRepository(dbContext, exceptionController);

                bool ret2 = warehouseAdminRepository.Insert(warehouseAdminAdd);

                warehouseAdd.WarehouseAdminId = warehouseAdminAdd.WarehouseAdminId;
                warehouseAdd.WarehouseAdmin = warehouseAdminAdd;

                WarehouseRepository warehouseRepository = new WarehouseRepository(dbContext, exceptionController);

                bool ret3 = warehouseRepository.Insert(warehouseAdd);

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

                current.WarehouseAddress = !String.IsNullOrEmpty(update.WarehouseAddress) ? update.WarehouseAddress : current.WarehouseAddress;
                current.Extension = update.Extension != 0 ? update.Extension : current.Extension;
                current.WarehouseAdmin = update.WarehouseAdmin != null ? update.WarehouseAdmin : current.WarehouseAdmin;
                current.WarehouseAdminId = update.WarehouseAdmin != null ? update.WarehouseAdminId : current.WarehouseAdminId;

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
