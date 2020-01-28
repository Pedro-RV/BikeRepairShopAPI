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

        private ExceptionController exceptionController;

        public ClientRepository(SaleContext dbContext, ExceptionController exceptionController)
        {
            this.dbContext = dbContext;
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

                dbContext.Client.Add(add);
                dbContext.SaveChanges();
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
                ret = dbContext.Client.Where(x => x.ClientId == ClientId).FirstOrDefault();

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

        private bool Lookfor(Client orig)
        {
            bool found;

            found = dbContext.Client.Any(x => x.ClientId == orig.ClientId);

            return found;
        }

    }
}
