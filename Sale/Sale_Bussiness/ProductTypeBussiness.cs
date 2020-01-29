using AutoMapper;
using Sale_Bussiness.Interfaces;
using Sale_Data;
using Sale_Data.Context;
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
        private SaleContext dbContext;

        private ExceptionController exceptionController;

        private IMapper mapper;

        public ProductTypeBussiness()
        {
            SaleContextProvider.InitializeSaleContext();
            dbContext = SaleContextProvider.GetSaleContext();
            exceptionController = new ExceptionController();


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
                ProductTypeRepository productTypeRepository = new ProductTypeRepository(dbContext, exceptionController);

                ProductType productTypeAdd = mapper.Map<ProductTypeSpecific, ProductType>(productTypeSpecific);

                ret = productTypeRepository.Insert(productTypeAdd);
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
                ProductTypeRepository productTypeRepository = new ProductTypeRepository(dbContext, exceptionController);

                ret = productTypeRepository.Read(ProductTypeId);
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
                ProductTypeRepository productTypeRepository = new ProductTypeRepository(dbContext, exceptionController);

                ProductType current = productTypeRepository.Read(update.ProductTypeId);

                current.ProductTypeDescription = !String.IsNullOrEmpty(update.ProductTypeDescription) ? update.ProductTypeDescription : current.ProductTypeDescription;

                ret = productTypeRepository.Update(current);

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
                ProductTypeRepository productTypeRepository = new ProductTypeRepository(dbContext, exceptionController);

                ProductType del = productTypeRepository.Read(ProductTypeId);

                ret = productTypeRepository.Delete(del);

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
