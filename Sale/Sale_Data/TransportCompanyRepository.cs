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

        public TransportCompanyRepository(SaleContext dbContext, ExceptionController exceptionController)
        {
            this.dbContext = dbContext;
            this.exceptionController = exceptionController;

        }

        public bool Insert(TransportCompany add)
        {
            bool ret = false;

            try
            {
                if (add.TelephoneNum == null)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.NullTelephoneNum);
                }

                if (add == null)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.NullObject);
                }

                dbContext.TransportCompany.Add(add);
                dbContext.SaveChanges();
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

        public TransportCompany Read(int TransportCompanyId)
        {
            TransportCompany ret;

            try
            {
                ret = dbContext.TransportCompany.Where(x => x.TransportCompanyId == TransportCompanyId).FirstOrDefault();

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


        public bool Update(TransportCompany update)
        {
            bool ret = false;
            bool exist = Lookfor(update);

            try
            {
                if (!exist)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.ObjectNotFound);
                }

                dbContext.Entry(update).State = EntityState.Modified;
                dbContext.SaveChanges();
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

        public bool Delete(TransportCompany del)
        {
            bool ret = false;
            bool exist = Lookfor(del);

            try
            {
                if (!exist)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.ObjectNotFound);
                }

                dbContext.Entry(del).State = EntityState.Deleted;
                dbContext.SaveChanges();
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

        private bool Lookfor(TransportCompany orig)
        {
            bool found;

            found = dbContext.TransportCompany.Any(x => x.TransportCompanyId == orig.TransportCompanyId);

            return found;
        }

    }
}
