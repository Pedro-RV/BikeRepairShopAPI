using Sale_Entities.EntityModel;
using Sale_Data.Context;
using System.Linq;
using System.Data.Entity;
using System;
using Sale_Data.Interfaces;
using Sale_Helper.ExceptionController;

namespace Sale_Data
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private SaleContext dbContext;

        private ExceptionController exceptionController;

        public ProductTypeRepository()
        {
            SaleContextProvider.InitializeSaleContext();
            dbContext = SaleContextProvider.GetSaleContext();
            exceptionController = new ExceptionController();

        }

        public bool Insert(ProductType add)
        {
            bool ret = false;

            try
            {
                if (add.ProductTypeDescription == null)
                {
                    ArgumentNullException type = new ArgumentNullException();
                    throw this.exceptionController.CreateOwnException(8, type);
                }

                if (add == null)
                {
                    ArgumentNullException type = new ArgumentNullException();
                    throw this.exceptionController.CreateOwnException(2, type);
                }


                dbContext.ProductType.Add(add);
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

        public ProductType Read(int ProductTypeId)
        {
            ProductType ret;

            try
            {
                ret = dbContext.ProductType.Where(x => x.ProductTypeId == ProductTypeId).FirstOrDefault();

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


        public bool Update(ProductType original, ProductType upda)
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

        public bool Delete(ProductType del)
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

        private bool Lookfor(ProductType orig)
        {
            bool found;

            found = dbContext.ProductType.Any(x => x.ProductTypeId == orig.ProductTypeId);

            return found;
        }

    }
}
