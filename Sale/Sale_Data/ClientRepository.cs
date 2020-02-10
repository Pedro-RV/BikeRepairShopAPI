using Sale_Entities.EntityModel;
using Sale_Data.Context;
using System.Linq;
using System.Data.Entity;
using System;
using Sale_Data.Interfaces;
using Sale_Helper.ExceptionController;

namespace Sale_Data
{
    public class ClientRepository : IClientRepository
    {
        private SaleContext dbContext;

        private ISaleContextProvider saleContextProvider;

        private IExceptionController exceptionController;

        public ClientRepository(ISaleContextProvider saleContextProvider, IExceptionController exceptionController)
        {
            this.saleContextProvider = saleContextProvider;
            this.saleContextProvider.InitializeSaleContext();
            this.dbContext = this.saleContextProvider.GetSaleContext();
            this.exceptionController = exceptionController;

        }

        public bool Insert(Client add)
        {
            bool result;

            try
            {
                if (add == null)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.NullObject);
                }

                if (add.DNI == null)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.NullDNI);
                }

                this.dbContext.Client.Add(add);
                this.dbContext.SaveChanges();
                result = true;

            }
            catch (SaleException)
            {
                throw;
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }

            return result;
        }

        public Client Read(int ClientId)
        {
            Client ret;

            try
            {
                ret = this.dbContext.Client.Where(x => x.ClientId == ClientId).FirstOrDefault();

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


        public bool Update(Client update)
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

        public bool Delete(Client del)
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

        private bool Lookfor(Client orig)
        {
            bool found;

            found = this.dbContext.Client.Any(x => x.ClientId == orig.ClientId);

            return found;
        }

    }
}
