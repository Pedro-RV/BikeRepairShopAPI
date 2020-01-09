﻿using Supplier_Bussiness.Interfaces;
using Supplier_Data;
using Supplier_Data.Context;
using Supplier_Entities.EntityModel;
using Supplier_Helper.ExceptionController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Bussiness
{
    public class ProductStateBussiness : IProductStateBussiness
    {

        private SupplierContext dbContext;

        private ExceptionController exceptionController;

        public ProductStateBussiness()
        {
            SupplierContextProvider.InitializeSupplierContext();
            dbContext = SupplierContextProvider.GetSupplierContext();
            exceptionController = new ExceptionController();
        }

        public bool InsertProductState(string ProductStateDescription)
        {
            bool ret;

            try
            {
                ProductState add = new ProductState(ProductStateDescription);

                ProductStateRepository productStateRepository = new ProductStateRepository(dbContext, exceptionController);

                ret = productStateRepository.Insert(add);

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

        public ProductState ReadProductState(int ProductStateId)
        {
            ProductState ret;

            try
            {
                ProductStateRepository productStateRepository = new ProductStateRepository(dbContext, exceptionController);

                ret = productStateRepository.Read(ProductStateId);

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

        public bool UpdateProductState(int ProductStateId, string ProductStateDescription)
        {
            bool ret;

            try
            {
                ProductStateRepository productStateRepository = new ProductStateRepository(dbContext, exceptionController);

                ProductState update = productStateRepository.Read(ProductStateId);

                if (ProductStateDescription != null)
                {
                    update.ProductStateDescription = ProductStateDescription;
                }

                ret = productStateRepository.Update(update);

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

        public bool DeleteProductState(int ProductStateId)
        {
            bool ret;

            try
            {
                ProductStateRepository productStateRepository = new ProductStateRepository(dbContext, exceptionController);

                ProductState del = productStateRepository.Read(ProductStateId);

                ret = productStateRepository.Delete(del);

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
