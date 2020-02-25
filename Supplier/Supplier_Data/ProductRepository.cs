using Supplier_Entities.EntityModel;
using Supplier_Data.Context;
using System.Linq;
using System.Data.Entity;
using Supplier_Data.Interfaces;
using System;
using Supplier_Helper.ExceptionController;
using System.Collections.Generic;

namespace Supplier_Data
{
    public class ProductRepository : IProductRepository
    {
        private SupplierContext dbContext;

        private ISupplierContextProvider supplierContextProvider;

        private IExceptionController exceptionController;

        public ProductRepository(ISupplierContextProvider supplierContextProvider, IExceptionController exceptionController)
        {
            this.supplierContextProvider = supplierContextProvider;
            this.supplierContextProvider.InitializeSupplierContext();
            this.dbContext = this.supplierContextProvider.GetSupplierContext();
            this.exceptionController = exceptionController;
        }

        public List<Product> ProductsList()
        {
            List<Product> ret = this.dbContext.Product.ToList();

            return ret;
        }

        public bool Insert(Product add)
        {
            bool ret = false;

            try
            {
                if (add == null)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.NullObject);
                }

                if (add.Prize <= 0)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.MistakenPrize);
                }

                this.dbContext.Product.Add(add);
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

        public Product Read(int ProductId)
        {
            Product ret;

            try
            {
                ret = this.dbContext.Product.Where(x => x.ProductId == ProductId).FirstOrDefault();

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


        public bool Update(Product update)
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

        public bool Delete(Product del)
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

        private bool Lookfor(Product orig)
        {
            bool found;

            found = this.dbContext.Product.Any(x => x.ProductId == orig.ProductId);

            return found;
        }

    }
}
