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
    public class WarehouseBussiness : IWarehouseBussiness
    {
        private SupplierContext dbContext;

        private ExceptionController exceptionController;

        private IMapper mapper;

        public WarehouseBussiness()
        {
            SupplierContextProvider.InitializeSupplierContext();
            dbContext = SupplierContextProvider.GetSupplierContext();
            exceptionController = new ExceptionController();


            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<WarehouseSpecific, Warehouse>();
            });

            mapper = config.CreateMapper();
        }

        public List<Warehouse> WarehousesBiggerThanAnExtensionList(int extension)
        {
            WarehouseRepository warehouseRepository = new WarehouseRepository(dbContext, exceptionController);

            List<Warehouse> ret = warehouseRepository.WarehousesBiggerThanAnExtensionList(extension);

            return ret;
        }      

        public bool InsertWarehouse(WarehouseSpecific warehouseSpecific)
        {
            bool ret;

            try
            {
                WarehouseRepository warehouseRepository = new WarehouseRepository(dbContext, exceptionController);

                Warehouse warehouseAdd = mapper.Map<WarehouseSpecific, Warehouse>(warehouseSpecific);

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

        public bool UpdateWarehouse(WarehouseSpecific update)
        {
            bool ret;

            try
            {
                WarehouseRepository warehouseRepository = new WarehouseRepository(dbContext, exceptionController);

                Warehouse current = warehouseRepository.Read(update.WarehouseId);

                current.WarehouseAddress = !String.IsNullOrEmpty(update.WarehouseAddress) ? update.WarehouseAddress : current.WarehouseAddress;
                current.Extension = update.Extension != 0 ? update.Extension : current.Extension;            

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
