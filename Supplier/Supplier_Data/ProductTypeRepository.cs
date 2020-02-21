using System.Linq;
using System.Data.Entity;
using System;
using Supplier_Data.Context;
using Supplier_Data.Interfaces;
using Supplier_Helper.ExceptionController;
using Supplier_Entities.EntityModel;

namespace Supplier_Data
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private SupplierContext dbContext;

        private ISupplierContextProvider supplierContextProvider;

        private IExceptionController exceptionController;

        public ProductTypeRepository(ISupplierContextProvider supplierContextProvider, IExceptionController exceptionController)
        {
            this.supplierContextProvider = supplierContextProvider;
            this.supplierContextProvider.InitializeSupplierContext();
            this.dbContext = this.supplierContextProvider.GetSupplierContext();
            this.exceptionController = exceptionController;

        }

        public bool Insert(ProductType add)
        {
            bool ret = false;

            try
            {
                if (add.ProductTypeDescription == null)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.NullProductTypeDescription);
                }

                if (add == null)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.NullObject);
                }


                this.dbContext.ProductType.Add(add);
                this.dbContext.SaveChanges();
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

        public ProductType Read(int ProductTypeId)
        {
            ProductType ret;

            try
            {
                ret = this.dbContext.ProductType.Where(x => x.ProductTypeId == ProductTypeId).FirstOrDefault();

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


        public bool Update(ProductType update)
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

        public bool Delete(ProductType del)
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

        private bool Lookfor(ProductType orig)
        {
            bool found;

            found = this.dbContext.ProductType.Any(x => x.ProductTypeId == orig.ProductTypeId);

            return found;
        }

    }
}
