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

        public ProductBussiness()
        {
            SupplierContextProvider.InitializeSupplierContext();
            dbContext = SupplierContextProvider.GetSupplierContext();
            exceptionController = new ExceptionController();
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

        public bool InsertProduct(String ProductDescription, double Prize, int Cuantity, int WarehouseId, int ProductStateId)
        {
            bool ret;

            try
            {
                WarehouseRepository warehouseRepository = new WarehouseRepository(dbContext, exceptionController);
                Warehouse attach = warehouseRepository.Read(WarehouseId);
                ProductStateRepository productStateRepository = new ProductStateRepository(dbContext, exceptionController);
                ProductState attach2 = productStateRepository.Read(ProductStateId);
                Product add = new Product(ProductDescription, Prize, Cuantity, attach, attach2);

                ProductRepository productRepository = new ProductRepository(dbContext, exceptionController);

                ret = productRepository.Insert(add);

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

        public bool UpdateProduct(int ProductId, String ProductDescription, double Prize, int Cuantity, int WarehouseId, int ProductStateId)
        {
            bool ret;

            try
            {
                ProductRepository productRepository = new ProductRepository(dbContext, exceptionController);

                Product update = productRepository.Read(ProductId);

                if (ProductDescription != null)
                {
                    update.ProductDescription = ProductDescription;
                }

                if (Prize != 0)
                {
                    update.Prize = Prize;
                }

                if (Cuantity != 0)
                {
                    update.Cuantity = Cuantity;
                }

                if (WarehouseId != 0)
                {
                    WarehouseRepository warehouseRepository = new WarehouseRepository(dbContext, exceptionController);
                    Warehouse change = warehouseRepository.Read(WarehouseId);
                    update.Warehouse = change;
                }

                if (ProductStateId != 0)
                {
                    ProductStateRepository productStateRepository = new ProductStateRepository(dbContext, exceptionController);
                    ProductState change = productStateRepository.Read(ProductStateId);
                    update.ProductState = change;
                }

                ret = productRepository.Update(update);

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
