﻿using Sale_Entities.EntityModel;
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

        private ExceptionController exceptionController;

        public PaymentMethodRepository()
        {
            SaleContextProvider.InitializeSaleContext();
            dbContext = SaleContextProvider.GetSaleContext();
            exceptionController = new ExceptionController();

        }

        public bool Insert(PaymentMethod add)
        {
            bool ret = false;

            try
            {
                if (add.PaymentMethodDescription == null)
                {
                    ArgumentNullException type = new ArgumentNullException();
                    throw this.exceptionController.CreateOwnException(7, type);
                }

                if (add == null)
                {
                    ArgumentNullException type = new ArgumentNullException();
                    throw this.exceptionController.CreateOwnException(2, type);
                }


                dbContext.PaymentMethod.Add(add);
                dbContext.SaveChanges();
                ret = true;

            }
            catch (SaleException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw this.exceptionController.CreateGeneralException(ex);
            }

            return ret;
        }

        public PaymentMethod Read(int PaymentMethodId)
        {
            PaymentMethod ret;

            try
            {
                ret = dbContext.PaymentMethod.Where(x => x.PaymentMethodId == PaymentMethodId).FirstOrDefault();

                if (ret == null)
                {
                    ArgumentException type = new ArgumentException();
                    throw this.exceptionController.CreateOwnException(3, type);
                }

            }
            catch (SaleException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw this.exceptionController.CreateGeneralException(ex);
            }

            return ret;
        }


        public bool Update(PaymentMethod original, PaymentMethod upda)
        {
            bool ret = false;
            bool exist = Lookfor(original);

            original = upda;

            try
            {
                if (upda == null)
                {
                    ArgumentNullException type = new ArgumentNullException();
                    throw this.exceptionController.CreateOwnException(2, type);
                }

                original = upda;

                if (!exist)
                {
                    ArgumentException type = new ArgumentException();
                    throw this.exceptionController.CreateOwnException(3, type);
                }

                dbContext.Entry(original).State = EntityState.Modified;
                dbContext.SaveChanges();
                ret = true;

            }
            catch (SaleException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw this.exceptionController.CreateGeneralException(ex);
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
                    ArgumentException type = new ArgumentException();
                    throw this.exceptionController.CreateOwnException(3, type);
                }

                dbContext.Entry(del).State = EntityState.Deleted;
                dbContext.SaveChanges();
                ret = true;

            }
            catch (SaleException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw this.exceptionController.CreateGeneralException(ex);
            }

            return ret;
        }

        private bool Lookfor(PaymentMethod orig)
        {
            bool found;

            found = dbContext.PaymentMethod.Any(x => x.PaymentMethodId == orig.PaymentMethodId);

            return found;
        }

    }
}