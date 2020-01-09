using Sale_Entities.EntityModel;
using Sale_Data.Context;
using System.Linq;
using System.Data.Entity;
using System;
using Sale_Data.Interfaces;
using Sale_Helper.ExceptionController;

namespace Sale_Data
{
    public class TransportCompanyRepository : ITransportCompanyRepository
    {
        private SaleContext dbContext;

        private ExceptionController exceptionController;

        public TransportCompanyRepository()
        {
            SaleContextProvider.InitializeSaleContext();
            dbContext = SaleContextProvider.GetSaleContext();
            exceptionController = new ExceptionController();

        }

        public bool Insert(TransportCompany add)
        {
            bool ret = false;

            try
            {
                if (add.TelephoneNum == null)
                {
                    ArgumentNullException type = new ArgumentNullException();
                    throw this.exceptionController.CreateOwnException(9, type);
                }

                if (add == null)
                {
                    ArgumentNullException type = new ArgumentNullException();
                    throw this.exceptionController.CreateOwnException(2, type);
                }


                dbContext.TransportCompany.Add(add);
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

        public TransportCompany Read(int TransportCompanyId)
        {
            TransportCompany ret;

            try
            {
                ret = dbContext.TransportCompany.Where(x => x.TransportCompanyId == TransportCompanyId).FirstOrDefault();

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


        public bool Update(TransportCompany original, TransportCompany upda)
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

        public bool Delete(TransportCompany del)
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

        private bool Lookfor(TransportCompany orig)
        {
            bool found;

            found = dbContext.TransportCompany.Any(x => x.TransportCompanyId == orig.TransportCompanyId);

            return found;
        }

    }
}
