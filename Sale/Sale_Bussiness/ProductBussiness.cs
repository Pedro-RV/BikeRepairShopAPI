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
    public class ProductBussiness : IProductBussiness
    {
        private SaleContext dbContext;

        private ExceptionController exceptionController;

        private IMapper mapper;

        public ProductBussiness()
        {
            SaleContextProvider.InitializeSaleContext();
            dbContext = SaleContextProvider.GetSaleContext();
            exceptionController = new ExceptionController();


            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProductSpecific, Product>();
            });

            mapper = config.CreateMapper();
        }

        public bool InsertProduct(ProductSpecific productSpecific)
        {
            bool ret;

            try
            {
                ProductRepository productRepository = new ProductRepository(dbContext, exceptionController);

                Product productAdd = mapper.Map<ProductSpecific, Product>(productSpecific);

                ret = productRepository.Insert(productAdd);
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

        public Product ReadProduct(int ProductId)
        {
            Product ret;

            try
            {
                ProductRepository productRepository = new ProductRepository(dbContext, exceptionController);

                ret = productRepository.Read(ProductId);
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

        public bool UpdateProduct(ProductSpecific update)
        {
            bool ret;

            try
            {
                ProductRepository productRepository = new ProductRepository(dbContext, exceptionController);
                ProductTypeBussiness productTypeBussiness = new ProductTypeBussiness();

                Product current = productRepository.Read(update.ProductId);

                current.ProductDescription = !String.IsNullOrEmpty(update.ProductDescription) ? update.ProductDescription : current.ProductDescription;
                current.Prize = update.Prize != 0 ? update.Prize : current.Prize;
                current.Cuantity = update.Cuantity != 0 ? update.Cuantity : current.Cuantity;

                if (update.ProductTypeId != 0)
                {
                    current.ProductTypeId = update.ProductTypeId;
                    ProductType productTypeAttach = productTypeBussiness.ReadProductType(current.ProductTypeId);
                    current.ProductType = productTypeAttach;
                }

                ret = productRepository.Update(current);

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

        public bool DeleteProduct(int ProductId)
        {
            bool ret;

            try
            {
                ProductRepository productRepository = new ProductRepository(dbContext, exceptionController);

                Product del = productRepository.Read(ProductId);

                ret = productRepository.Delete(del);

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
