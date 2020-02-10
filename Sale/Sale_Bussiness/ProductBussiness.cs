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
    public class ProductBussiness : IProductBussiness
    {
        private IExceptionController exceptionController;

        private IProductRepository productRepository;

        private IProductTypeBussiness productTypeBussiness;

        private IMapper mapper;

        public ProductBussiness(IExceptionController exceptionController,
            IProductRepository productRepository,
            IProductTypeBussiness productTypeBussiness)
        {
            this.exceptionController = exceptionController;
            this.productRepository = productRepository;
            this.productTypeBussiness = productTypeBussiness;


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
                Product productAdd = mapper.Map<ProductSpecific, Product>(productSpecific);

                ret = this.productRepository.Insert(productAdd);
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
                ret = this.productRepository.Read(ProductId);
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
                Product current = this.productRepository.Read(update.ProductId);

                current.ProductDescription = !string.IsNullOrEmpty(update.ProductDescription) ? update.ProductDescription : current.ProductDescription;
                current.Prize = update.Prize != 0 ? update.Prize : current.Prize;
                current.Cuantity = update.Cuantity != 0 ? update.Cuantity : current.Cuantity;

                if (update.ProductTypeId != 0)
                {
                    current.ProductTypeId = update.ProductTypeId;
                    ProductType productTypeAttach = this.productTypeBussiness.ReadProductType(current.ProductTypeId);
                    current.ProductType = productTypeAttach;
                }

                ret = this.productRepository.Update(current);

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
                Product del = this.productRepository.Read(ProductId);

                ret = this.productRepository.Delete(del);

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
