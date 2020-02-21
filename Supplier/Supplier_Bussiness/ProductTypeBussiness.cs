using AutoMapper;
using Supplier_Bussiness.Interfaces;
using Supplier_Data.Interfaces;
using Supplier_Entities.EntityModel;
using Supplier_Entities.Specific;
using Supplier_Helper.ExceptionController;
using System;

namespace Supplier_Bussiness
{
    public class ProductTypeBussiness : IProductTypeBussiness
    {
        private IExceptionController exceptionController;

        private IProductTypeRepository productTypeRepository;

        private IMapper mapper;

        public ProductTypeBussiness(IExceptionController exceptionController,
            IProductTypeRepository productTypeRepository)
        {
            this.exceptionController = exceptionController;
            this.productTypeRepository = productTypeRepository;


            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProductTypeSpecific, ProductType>();
            });

            mapper = config.CreateMapper();
        }

        public bool InsertProductType(ProductTypeSpecific productTypeSpecific)
        {
            bool ret;

            try
            {
                ProductType productTypeAdd = mapper.Map<ProductTypeSpecific, ProductType>(productTypeSpecific);

                ret = this.productTypeRepository.Insert(productTypeAdd);
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

        public ProductType ReadProductType(int ProductTypeId)
        {
            ProductType ret;

            try
            {
                ret = this.productTypeRepository.Read(ProductTypeId);
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

        public bool UpdateProductType(ProductTypeSpecific update)
        {
            bool ret;

            try
            {
                ProductType current = this.productTypeRepository.Read(update.ProductTypeId);

                current.ProductTypeDescription = !string.IsNullOrEmpty(update.ProductTypeDescription) ? update.ProductTypeDescription : current.ProductTypeDescription;

                ret = this.productTypeRepository.Update(current);

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

        public bool DeleteProductType(int ProductTypeId)
        {
            bool ret;

            try
            {
                ProductType del = this.productTypeRepository.Read(ProductTypeId);

                ret = this.productTypeRepository.Delete(del);

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
