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

        public ClientRepository()
        {
            SaleContextProvider.InitializeSaleContext();
            dbContext = SaleContextProvider.GetSaleContext();
            exceptionController = new ExceptionController();

        }

        public bool Insert(Client add)
        {
            bool ret = false;

            try
            {
                if (add.DNI == null)
                {
                    ArgumentNullException type = new ArgumentNullException();
                    throw this.exceptionController.CreateOwnException(4, type);
                }

                if (add == null)
                {
                    ArgumentNullException type = new ArgumentNullException();
                    throw this.exceptionController.CreateOwnException(2, type);
                }


                dbContext.Client.Add(add);
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

        public Client Read(int ClientId)
        {
            Client ret;

            try
            {
                ret = dbContext.Client.Where(x => x.ClientId == ClientId).FirstOrDefault();

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


        public bool Update(Client original, Client upda)
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

        public bool Delete(Client del)
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

        private bool Lookfor(Client orig)
        {
            bool found;

            found = dbContext.Client.Any(x => x.ClientId == orig.ClientId);

            return found;
        }

    }
}
