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
    public class WarehouseProductBussiness : IWarehouseProductBussiness
    {
        private SupplierContext dbContext;

        private ExceptionController exceptionController;

        private IMapper mapper;

        public WarehouseProductBussiness()
        {
            SupplierContextProvider.InitializeSupplierContext();
            dbContext = SupplierContextProvider.GetSupplierContext();
            exceptionController = new ExceptionController();


            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<WarehouseProductSpecific, WarehouseProduct>();
            });

            mapper = config.CreateMapper();

        }

        public bool InsertWarehouseProduct(WarehouseProductSpecific WarehouseProductSpecific)
        {
            bool ret;

            try
            {
                WarehouseProductRepository WarehouseProductRepository = new WarehouseProductRepository(dbContext, exceptionController);
                ProductBussiness productBussiness = new ProductBussiness();
                ProductStateBussiness productStateBussiness = new ProductStateBussiness();
                WarehouseBussiness warehouseBussiness = new WarehouseBussiness();

                WarehouseProduct WarehouseProductAdd = mapper.Map<WarehouseProductSpecific, WarehouseProduct>(WarehouseProductSpecific);

                if (WarehouseProductAdd.ProductId != 0)
                {
                    Product productAttach = productBussiness.ReadProduct(WarehouseProductAdd.ProductId);
                    WarehouseProductAdd.Product = productAttach;
                }

                if (WarehouseProductAdd.ProductStateId != 0)
                {
                    ProductState productStateAttach = productStateBussiness.ReadProductState(WarehouseProductAdd.ProductStateId);
                    WarehouseProductAdd.ProductState = productStateAttach;
                }

                if (WarehouseProductAdd.WarehouseId != 0)
                {
                    Warehouse warehouseAttach = warehouseBussiness.ReadWarehouse(WarehouseProductAdd.WarehouseId);
                    WarehouseProductAdd.Warehouse = warehouseAttach;
                }

                ret = WarehouseProductRepository.Insert(WarehouseProductAdd);

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
                WarehouseProductRepository WarehouseProductRepository = new WarehouseProductRepository(dbContext, exceptionController);

                ret = WarehouseProductRepository.Read(WarehouseProductId);

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
                WarehouseProductRepository WarehouseProductRepository = new WarehouseProductRepository(dbContext, exceptionController);
                ProductBussiness productBussiness = new ProductBussiness();
                ProductStateBussiness productStateBussiness = new ProductStateBussiness();
                WarehouseBussiness warehouseBussiness = new WarehouseBussiness();

                WarehouseProduct current = WarehouseProductRepository.Read(update.WarehouseProductId);

                if (update.ProductId != 0)
                {
                    current.ProductId = update.ProductId;
                    Product productAttach = productBussiness.ReadProduct(current.ProductId);
                    current.Product = productAttach;
                }

                if (update.ProductStateId != 0)
                {
                    current.ProductStateId = update.ProductStateId;
                    ProductState productStateAttach = productStateBussiness.ReadProductState(current.ProductStateId);
                    current.ProductState = productStateAttach;
                }

                if (update.WarehouseId != 0)
                {
                    current.WarehouseId = update.WarehouseId;
                    Warehouse warehouseAttach = warehouseBussiness.ReadWarehouse(current.WarehouseId);
                    current.Warehouse = warehouseAttach;
                }

                ret = WarehouseProductRepository.Update(current);

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
                WarehouseProductRepository WarehouseProductRepository = new WarehouseProductRepository(dbContext, exceptionController);

                WarehouseProduct del = WarehouseProductRepository.Read(WarehouseProductId);

                ret = WarehouseProductRepository.Delete(del);

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
