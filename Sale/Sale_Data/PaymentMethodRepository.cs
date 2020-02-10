using Sale_Entities.EntityModel;
using Sale_Data.Context;
using System.Linq;
using System.Data.Entity;
using System;
using Sale_Data.Interfaces;
using Sale_Helper.ExceptionController;

namespace Sale_Data
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private SaleContext dbContext;

        private ISaleContextProvider saleContextProvider;

        private IExceptionController exceptionController;

        public PaymentMethodRepository(ISaleContextProvider saleContextProvider, IExceptionController exceptionController)
        {
            this.saleContextProvider = saleContextProvider;
            this.saleContextProvider.InitializeSaleContext();
            this.dbContext = this.saleContextProvider.GetSaleContext();
            this.exceptionController = exceptionController;

        }

        public bool Insert(PaymentMethod add)
        {
            bool ret = false;

            try
            {
                if (add.PaymentMethodDescription == null)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.NullPaymentMethodDescription);
                }

                if (add == null)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.NullObject);
                }

                this.dbContext.PaymentMethod.Add(add);
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

        public PaymentMethod Read(int PaymentMethodId)
        {
            PaymentMethod ret;

            try
            {
                ret = this.dbContext.PaymentMethod.Where(x => x.PaymentMethodId == PaymentMethodId).FirstOrDefault();

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


        public bool Update(PaymentMethod update)
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

        public bool Delete(PaymentMethod del)
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

        private bool Lookfor(PaymentMethod orig)
        {
            bool found;

            found = this.dbContext.PaymentMethod.Any(x => x.PaymentMethodId == orig.PaymentMethodId);

            return found;
        }

    }
}
