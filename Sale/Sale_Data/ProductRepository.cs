using Sale_Entities.EntityModel;
using Sale_Data.Context;
using System.Linq;
using System.Data.Entity;
using System;
using Sale_Data.Interfaces;
using Sale_Helper.ExceptionController;

namespace Sale_Data
{
    public class ProductRepository : IProductRepository
    {
        private SaleContext dbContext;

        private ISaleContextProvider saleContextProvider;

        private IExceptionController exceptionController;

        public ProductRepository(ISaleContextProvider saleContextProvider, IExceptionController exceptionController)
        {
            this.saleContextProvider = saleContextProvider;
            this.saleContextProvider.InitializeSaleContext();
            this.dbContext = this.saleContextProvider.GetSaleContext();
            this.exceptionController = exceptionController;

        }

        public bool Insert(Product add)
        {
            bool ret = false;

            try
            {
                if (add.Prize <= 0)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.MistakenPrize);
                }

                if (add.Cuantity < 0)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.MistakenCuantity);
                }

                if (add == null)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.NullObject);
                }


                this.dbContext.Product.Add(add);
                this.dbContext.SaveChanges();
                ret = true;

            }
            catch (SaleException)
            {
                throw;
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }

            return ret;
        }

        public Product Read(int ProductId)
        {
            Product ret;

            try
            {
                ret = this.dbContext.Product.Where(x => x.ProductId == ProductId).FirstOrDefault();

                if (ret == null)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.ObjectNotFound);
                }

            }
            catch (SaleException)
            {
                throw;
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }

            return ret;
        }


        public bool Update(Product update)
        {
            bool ret = false;
            bool exist = Lookfor(update);

            try
            {
                if (!exist)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.ObjectNotFound);
                }

                this.dbContext.Entry(update).State = EntityState.Modified;
                this.dbContext.SaveChanges();
                ret = true;

            }
            catch (SaleException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }

            return ret;
        }

        public bool Delete(Product del)
        {
            bool ret = false;
            bool exist = Lookfor(del);

            try
            {
                if (!exist)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.ObjectNotFound);
                }

                this.dbContext.Entry(del).State = EntityState.Deleted;
                this.dbContext.SaveChanges();
                ret = true;

            }
            catch (SaleException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }

            return ret;
        }

        private bool Lookfor(Product orig)
        {
            bool found;

            found = this.dbContext.Product.Any(x => x.ProductId == orig.ProductId);

            return found;
        }

    }
}
