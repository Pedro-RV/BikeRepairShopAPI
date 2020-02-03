using AutoMapper;
using Supplier_Bussiness.Interfaces;
using Supplier_Data;
using Supplier_Data.Context;
using Supplier_Data.Interfaces;
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
        private IExceptionController exceptionController;

        private IWarehouseRepository warehouseRepository;

        private IMapper mapper;

        public WarehouseBussiness(IExceptionController exceptionController,
            IWarehouseRepository warehouseRepository)
        {
            this.exceptionController = exceptionController;
            this.warehouseRepository = warehouseRepository;


            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<WarehouseSpecific, Warehouse>();
            });

            mapper = config.CreateMapper();
        }

        public List<Warehouse> WarehousesBiggerThanAnExtensionList(int extension)
        {
            List<Warehouse> ret = this.warehouseRepository.WarehousesBiggerThanAnExtensionList(extension);

            return ret;
        }      

        public bool InsertWarehouse(WarehouseSpecific warehouseSpecific)
        {
            bool ret;

            try
            {
                Warehouse warehouseAdd = mapper.Map<WarehouseSpecific, Warehouse>(warehouseSpecific);

                ret = this.warehouseRepository.Insert(warehouseAdd);

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
                ret = this.warehouseRepository.Read(WarehouseId);

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
                Warehouse current = this.warehouseRepository.Read(update.WarehouseId);

                current.WarehouseAddress = !String.IsNullOrEmpty(update.WarehouseAddress) ? update.WarehouseAddress : current.WarehouseAddress;
                current.Extension = update.Extension != 0 ? update.Extension : current.Extension;            

                ret = this.warehouseRepository.Update(current);

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
                Warehouse del = this.warehouseRepository.Read(WarehouseId);

                ret = this.warehouseRepository.Delete(del);

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
