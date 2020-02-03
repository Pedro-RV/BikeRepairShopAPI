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
    public class ProductStateBussiness : IProductStateBussiness
    {
        private IExceptionController exceptionController;

        private IProductStateRepository productStateRepository;

        private IMapper mapper;

        public ProductStateBussiness(IExceptionController exceptionController,
            IProductStateRepository productStateRepository)
        {
            this.exceptionController = exceptionController;
            this.productStateRepository = productStateRepository;

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProductStateSpecific, ProductState>();
            });

            mapper = config.CreateMapper();
        }

        public bool InsertProductState(ProductStateSpecific productStateSpecific)
        {
            bool ret;

            try
            {
                ProductState productStateAdd = mapper.Map<ProductStateSpecific, ProductState>(productStateSpecific);

                ret = this.productStateRepository.Insert(productStateAdd);

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
                ret = this.productStateRepository.Read(ProductStateId);

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

        public bool UpdateProductState(ProductStateSpecific update)
        {
            bool ret;

            try
            {
                ProductState current = this.productStateRepository.Read(update.ProductStateId);

                current.ProductStateDescription = !String.IsNullOrEmpty(update.ProductStateDescription) ? update.ProductStateDescription : current.ProductStateDescription;

                ret = this.productStateRepository.Update(current);

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
                ProductState del = this.productStateRepository.Read(ProductStateId);

                ret = this.productStateRepository.Delete(del);

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
