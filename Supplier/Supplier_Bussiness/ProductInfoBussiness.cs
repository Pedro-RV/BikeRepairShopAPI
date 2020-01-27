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
    public class ProductInfoBussiness : IProductInfoBussiness
    {
        private SupplierContext dbContext;

        private ExceptionController exceptionController;

        private IMapper mapper;

        public ProductInfoBussiness()
        {
            SupplierContextProvider.InitializeSupplierContext();
            dbContext = SupplierContextProvider.GetSupplierContext();
            exceptionController = new ExceptionController();


            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProductInfoSpecific, ProductInfo>();
            });

            mapper = config.CreateMapper();

        }

        public bool InsertProductInfo(ProductInfoSpecific productInfoSpecific)
        {
            bool ret;

            try
            {
                ProductInfoRepository productInfoRepository = new ProductInfoRepository(dbContext, exceptionController);
                ProductBussiness productBussiness = new ProductBussiness();
                ProductStateBussiness productStateBussiness = new ProductStateBussiness();
                WarehouseBussiness warehouseBussiness = new WarehouseBussiness();

                ProductInfo productInfoAdd = mapper.Map<ProductInfoSpecific, ProductInfo>(productInfoSpecific);

                if (productInfoAdd.ProductId != 0)
                {
                    Product productAttach = productBussiness.ReadProduct(productInfoAdd.ProductId);
                    productInfoAdd.Product = productAttach;
                }

                if (productInfoAdd.ProductStateId != 0)
                {
                    ProductState productStateAttach = productStateBussiness.ReadProductState(productInfoAdd.ProductStateId);
                    productInfoAdd.ProductState = productStateAttach;
                }

                if (productInfoAdd.WarehouseId != 0)
                {
                    Warehouse warehouseAttach = warehouseBussiness.ReadWarehouse(productInfoAdd.WarehouseId);
                    productInfoAdd.Warehouse = warehouseAttach;
                }

                ret = productInfoRepository.Insert(productInfoAdd);

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

        public ProductInfo ReadProductInfo(int ProductInfoId)
        {
            ProductInfo ret;

            try
            {
                ProductInfoRepository productInfoRepository = new ProductInfoRepository(dbContext, exceptionController);

                ret = productInfoRepository.Read(ProductInfoId);

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

        public bool UpdateProductInfo(ProductInfoSpecific update)
        {
            bool ret;

            try
            {
                ProductInfoRepository productInfoRepository = new ProductInfoRepository(dbContext, exceptionController);
                ProductBussiness productBussiness = new ProductBussiness();
                ProductStateBussiness productStateBussiness = new ProductStateBussiness();
                WarehouseBussiness warehouseBussiness = new WarehouseBussiness();

                ProductInfo current = productInfoRepository.Read(update.ProductInfoId);

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

                ret = productInfoRepository.Update(current);

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

        public bool DeleteProductInfo(int ProductInfoId)
        {
            bool ret;

            try
            {
                ProductInfoRepository productInfoRepository = new ProductInfoRepository(dbContext, exceptionController);

                ProductInfo del = productInfoRepository.Read(ProductInfoId);

                ret = productInfoRepository.Delete(del);

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
