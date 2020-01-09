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

        private ExceptionController exceptionController;

        public SaleRepository()
        {
            SaleContextProvider.InitializeSaleContext();
            dbContext = SaleContextProvider.GetSaleContext();
            exceptionController = new ExceptionController();

        }

        public bool Insert(Sale add)
        {
            bool ret = false;

            try
            {
                if (add.Cuantity < 0)
                {
                    ArgumentException type = new ArgumentException();
                    throw this.exceptionController.CreateOwnException(6, type);
                }

                if (add == null)
                {
                    ArgumentNullException type = new ArgumentNullException();
                    throw this.exceptionController.CreateOwnException(2, type);
                }


                dbContext.Sale.Add(add);
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

        public Sale Read(int SaleId)
        {
            Sale ret;

            try
            {
                ret = dbContext.Sale.Where(x => x.SaleId == SaleId).FirstOrDefault();

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


        public bool Update(Sale original, Sale upda)
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

        public bool Delete(Sale del)
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

        private bool Lookfor(Sale orig)
        {
            bool found;

            found = dbContext.Sale.Any(x => x.SaleId == orig.SaleId);

            return found;
        }

    }
}
