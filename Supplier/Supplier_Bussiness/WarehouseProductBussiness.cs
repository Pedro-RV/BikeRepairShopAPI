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

        private IProductBussiness productBussiness;

        private IProductStateBussiness productStateBussiness;

        private IWarehouseBussiness warehouseBussiness;

        private IMapper mapper;

        public WarehouseProductBussiness(IExceptionController exceptionController,
            IWarehouseProductRepository warehouseProductRepository,
            IProductBussiness productBussiness,
            IProductStateBussiness productStateBussiness,
            IWarehouseBussiness warehouseBussiness)
        {
            this.exceptionController = exceptionController;
            this.warehouseProductRepository = warehouseProductRepository;
            this.productBussiness = productBussiness;
            this.productStateBussiness = productStateBussiness;
            this.warehouseBussiness = warehouseBussiness;


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

                if (warehouseProductAdd.ProductId != 0)
                {
                    Product productAttach = this.productBussiness.ReadProduct(warehouseProductAdd.ProductId);
                    warehouseProductAdd.Product = productAttach;
                }

                if (warehouseProductAdd.ProductStateId != 0)
                {
                    ProductState productStateAttach = this.productStateBussiness.ReadProductState(warehouseProductAdd.ProductStateId);
                    warehouseProductAdd.ProductState = productStateAttach;
                }

                if (warehouseProductAdd.WarehouseId != 0)
                {
                    Warehouse warehouseAttach = this.warehouseBussiness.ReadWarehouse(warehouseProductAdd.WarehouseId);
                    warehouseProductAdd.Warehouse = warehouseAttach;
                }

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

                if (update.ProductId != 0)
                {
                    current.ProductId = update.ProductId;
                    Product productAttach = this.productBussiness.ReadProduct(current.ProductId);
                    current.Product = productAttach;
                }

                if (update.ProductStateId != 0)
                {
                    current.ProductStateId = update.ProductStateId;
                    ProductState productStateAttach = this.productStateBussiness.ReadProductState(current.ProductStateId);
                    current.ProductState = productStateAttach;
                }

                if (update.WarehouseId != 0)
                {
                    current.WarehouseId = update.WarehouseId;
                    Warehouse warehouseAttach = this.warehouseBussiness.ReadWarehouse(current.WarehouseId);
                    current.Warehouse = warehouseAttach;
                }

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
