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
    public class ProductBussiness : IProductBussiness
    {
        private SupplierContext dbContext;

        private ExceptionController exceptionController;

        private IMapper mapper;

        public ProductBussiness()
        {
            SupplierContextProvider.InitializeSupplierContext();
            dbContext = SupplierContextProvider.GetSupplierContext();
            exceptionController = new ExceptionController();


            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProductSpecific, Product>();
            });

            mapper = config.CreateMapper();

        }

        public List<Product> ProductsList()
        {
            ProductRepository productRepository = new ProductRepository(dbContext, exceptionController);

            List<Product> ret = productRepository.ProductsList();

            return ret;
        }

        public List<ProductData> ProductDataList()
        {
            ProductRepository productRepository = new ProductRepository(dbContext, exceptionController);

            List<ProductData> ret = productRepository.ProductDataList();

            return ret;
        }

        public bool InsertProduct(ProductSpecific productSpecific)
        {
            bool ret;

            try
            {
                ProductRepository productRepository = new ProductRepository(dbContext, exceptionController);
                ProductStateBussiness productStateBussiness = new ProductStateBussiness();
                WarehouseBussiness warehouseBussiness = new WarehouseBussiness();

                Product productAdd = mapper.Map<ProductSpecific, Product>(productSpecific);

                if (productAdd.ProductStateId != 0)
                {
                    ProductState productStateAttach = productStateBussiness.ReadProductState(productAdd.ProductStateId);
                    productAdd.ProductState = productStateAttach;
                }

                if (productAdd.WarehouseId != 0)
                {
                    Warehouse warehouseAttach = warehouseBussiness.ReadWarehouse(productAdd.WarehouseId);
                    productAdd.Warehouse = warehouseAttach;
                }

                ret = productRepository.Insert(productAdd);

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

        public Product ReadProduct(int ProductId)
        {
            Product ret;

            try
            {
                ProductRepository productRepository = new ProductRepository(dbContext, exceptionController);

                ret = productRepository.Read(ProductId);

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

        public bool UpdateProduct(ProductSpecific update)
        {
            bool ret;

            try
            {
                ProductRepository productRepository = new ProductRepository(dbContext, exceptionController);
                ProductStateBussiness productStateBussiness = new ProductStateBussiness();
                WarehouseBussiness warehouseBussiness = new WarehouseBussiness();

                Product current = productRepository.Read(update.ProductId);

                current.ProductDescription = !String.IsNullOrEmpty(update.ProductDescription) ? update.ProductDescription : current.ProductDescription;
                current.Prize = update.Prize != 0 ? update.Prize : current.Prize;
                current.Cuantity = update.Cuantity != 0 ? update.Cuantity : current.Cuantity;

                if(update.ProductStateId != 0)
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

                ret = productRepository.Update(current);

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

        public bool DeleteProduct(int ProductId)
        {
            bool ret;

            try
            {
                ProductRepository productRepository = new ProductRepository(dbContext, exceptionController);

                Product del = productRepository.Read(ProductId);

                ret = productRepository.Delete(del);

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
