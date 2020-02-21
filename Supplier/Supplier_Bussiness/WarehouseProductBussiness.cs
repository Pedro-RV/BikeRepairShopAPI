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
    public class WarehouseProductBussiness : IWarehouseProductBussiness
    {
        private IExceptionController exceptionController;

        private IWarehouseProductRepository warehouseProductRepository;

        private IMapper mapper;

        public WarehouseProductBussiness(IExceptionController exceptionController,
            IWarehouseProductRepository warehouseProductRepository)
        {
            this.exceptionController = exceptionController;
            this.warehouseProductRepository = warehouseProductRepository;


            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<WarehouseProductSpecific, WarehouseProduct>();
            });

            mapper = config.CreateMapper();

        }

        public bool InsertWarehouseProduct(WarehouseProductSpecific warehouseProductSpecific)
        {
            bool ret;

            try
            {
                WarehouseProduct warehouseProductAdd = mapper.Map<WarehouseProductSpecific, WarehouseProduct>(warehouseProductSpecific);

                ret = this.warehouseProductRepository.Insert(warehouseProductAdd);

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

        public WarehouseProduct ReadWarehouseProduct(int WarehouseProductId)
        {
            WarehouseProduct ret;

            try
            {
                ret = this.warehouseProductRepository.Read(WarehouseProductId);

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

        public bool UpdateWarehouseProduct(WarehouseProductSpecific update)
        {
            bool ret;

            try
            {
                WarehouseProduct current = this.warehouseProductRepository.Read(update.WarehouseProductId);

                current.ProductId = update.ProductId != 0 ? update.ProductId : current.ProductId;
                current.ProductStateId = update.ProductStateId != 0 ? update.ProductStateId : current.ProductStateId;
                current.WarehouseId = update.WarehouseId != 0 ? update.WarehouseId : current.WarehouseId;

                ret = this.warehouseProductRepository.Update(current);

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

        public bool DeleteWarehouseProduct(int WarehouseProductId)
        {
            bool ret;

            try
            {
                WarehouseProduct del = this.warehouseProductRepository.Read(WarehouseProductId);

                ret = this.warehouseProductRepository.Delete(del);

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
