using Sale_Entities.EntityModel;
using Sale_Data.Context;
using System.Linq;
using System.Data.Entity;
using System;
using Sale_Data.Interfaces;
using Sale_Helper.ExceptionController;

namespace Sale_Data
{
    public class SaleRepository : ISaleRepository
    {
        private SaleContext dbContext;

        private ISaleContextProvider saleContextProvider;

        private IExceptionController exceptionController;

        public SaleRepository(ISaleContextProvider saleContextProvider, IExceptionController exceptionController)
        {
            this.saleContextProvider = saleContextProvider;
            this.saleContextProvider.InitializeSaleContext();
            this.dbContext = this.saleContextProvider.GetSaleContext();
            this.exceptionController = exceptionController;

        }

        public bool Insert(Sale add)
        {
            bool ret = false;

            try
            {
                if (add.ProductCuantity < 0)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.MistakenCuantity);

                }

                if (add == null)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.NullObject);

                }

                this.dbContext.Sale.Add(add);
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

        public Sale Read(int SaleId)
        {
            Sale ret;

            try
            {
                ret = this.dbContext.Sale.Where(x => x.SaleId == SaleId).FirstOrDefault();

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


        public bool Update(Sale update)
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
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }

            return ret;
        }

        public bool Delete(Sale del)
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
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }

            return ret;
        }

        private bool Lookfor(Sale orig)
        {
            bool found;

            found = this.dbContext.Sale.Any(x => x.SaleId == orig.SaleId);

            return found;
        }

    }
}
