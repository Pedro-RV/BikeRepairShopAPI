using AutoMapper;
using Sale_Bussiness.Interfaces;
using Sale_Data;
using Sale_Data.Context;
using Sale_Data.Interfaces;
using Sale_Entities.EntityModel;
using Sale_Entities.Specific;
using Sale_Helper.ExceptionController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Bussiness
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
            catch (SaleException)
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
            catch (SaleException)
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
            catch (SaleException)
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
            catch (SaleException)
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
