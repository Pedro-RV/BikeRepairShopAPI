using Supplier_Data.Context;
using Supplier_Data.Interfaces;
using Supplier_Entities.EntityModel;
using Supplier_Helper.ExceptionController;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Data
{
    public class ProductInfoRepository : IProductInfoRepository
    {
        private SupplierContext dbContext;

        private ExceptionController exceptionController;

        public ProductInfoRepository(SupplierContext dbContext, ExceptionController exceptionController)
        {
            this.dbContext = dbContext;
            this.exceptionController = exceptionController;
        }

        public bool Insert(ProductInfo add)
        {
            bool ret = false;

            try
            {
                if (add == null)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.NullObject);
                }

                dbContext.ProductInfo.Add(add);
                dbContext.SaveChanges();
                ret = true;

            }
            catch (SupplierException)
            {
                throw;
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }

            return ret;
        }

        public ProductInfo Read(int ProductInfoId)
        {
            ProductInfo ret;

            try
            {
                ret = dbContext.ProductInfo.Where(x => x.ProductInfoId == ProductInfoId).FirstOrDefault();

                if (ret == null)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.ObjectNotFound);
                }

            }
            catch (SupplierException)
            {
                throw;
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }

            return ret;
        }


        public bool Update(ProductInfo update)
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
            catch (SupplierException)
            {
                throw;
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }

            return ret;
        }

        public bool Delete(ProductInfo del)
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
            catch (SupplierException)
            {
                throw;
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }

            return ret;
        }

        private bool Lookfor(ProductInfo orig)
        {
            bool found;

            found = dbContext.ProductInfo.Any(x => x.ProductInfoId == orig.ProductInfoId);

            return found;
        }

    }
}
