using AutoMapper;
using Supplier_Bussiness.Interfaces;
using Supplier_Data;
using Supplier_Data.Context;
using Supplier_Data.Interfaces;
using Supplier_Entities.EntityModel;
using InterconnectServicesLibrary.Entities.SupplierSpecific;
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
        private IExceptionController exceptionController;

        private IProductRepository productRepository;

        private IMapper mapper;

        public ProductBussiness(IExceptionController exceptionController,
            IProductRepository productRepository)
        {
            this.exceptionController = exceptionController;
            this.productRepository = productRepository;

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProductSpecific, Product>();
            });

            mapper = config.CreateMapper();

        }

        public List<Product> ProductsList()
        {
            List<Product> ret = this.productRepository.ProductsList();

            return ret;
        }

        public bool InsertProduct(ProductSpecific productSpecific)
        {
            bool ret;

            try
            {
                Product productAdd = mapper.Map<ProductSpecific, Product>(productSpecific);

                ret = this.productRepository.Insert(productAdd);

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
                ret = this.productRepository.Read(ProductId);

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
                Product current = this.productRepository.Read(update.ProductId);

                current.ProductDescription = !string.IsNullOrEmpty(update.ProductDescription) ? update.ProductDescription : current.ProductDescription;
                current.Prize = update.Prize != 0 ? update.Prize : current.Prize;
                current.Cuantity = update.Cuantity != 0 ? update.Cuantity : current.Cuantity;
                current.ActiveFlag = update.ActiveFlag == true ? update.ActiveFlag : current.ActiveFlag;
                current.ProductTypeId = update.ProductTypeId != 0 ? update.ProductTypeId : current.ProductTypeId;

                ret = this.productRepository.Update(current);

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
                Product del = this.productRepository.Read(ProductId);

                ret = this.productRepository.Delete(del);

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
