using Supplier_Entities.EntityModel;
using Supplier_Data.Context;
using System.Linq;
using System.Data.Entity;
using Supplier_Data.Interfaces;
using System;
using Supplier_Helper.ExceptionController;
using System.Collections.Generic;
using Supplier_Entities.Specific;

namespace Supplier_Data
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private SupplierContext dbContext;

        private ISupplierContextProvider supplierContextProvider;

        private IExceptionController exceptionController;

        public PurchaseRepository(ISupplierContextProvider supplierContextProvider, IExceptionController exceptionController)
        {
            this.supplierContextProvider = supplierContextProvider;
            this.supplierContextProvider.InitializeSupplierContext();
            this.dbContext = this.supplierContextProvider.GetSupplierContext();
            this.exceptionController = exceptionController;
        }

        public List<Purchase> PurchasesBiggerThanAPrizeList(double prize)
        {
            List<Purchase> ret = dbContext.Purchase.Where(x => x.Prize > prize).ToList();

            return ret;
        }

        public List<PurchaseData> PurchaseDataList()
        {
            var ret = dbContext.Purchase
                .Join(dbContext.Product,
                    purchase => purchase.ProductId,
                    product => product.ProductId,
                    (purchase, product) => new
                    {
                        Purchase = purchase,
                        Product = product
                    })
                .Join(
                    dbContext.SupplyCompany,
                    combined => combined.Purchase.SupplyCompanyId,
                    supplyCompany => supplyCompany.SupplyCompanyId,
                    (combined, supplyCompany) => new PurchaseData()
                    {
                        PurchaseId = combined.Purchase.PurchaseId,
                        PurchaseDate = combined.Purchase.PurchaseDate,
                        Cuantity = combined.Purchase.Cuantity,
                        Prize = combined.Purchase.Prize,
                        ProductId = combined.Product.ProductId,
                        ProductDescription = combined.Product.ProductDescription,
                        SupplyCompanyId = supplyCompany.SupplyCompanyId,
                        SupplyCompanyName = supplyCompany.SupplyCompanyName
                    }).ToList();

            return ret;
        }

        public bool Insert(Purchase add)
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

                if (add.Cuantity < 0)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.MistakenCuantity);
                }             

                dbContext.Purchase.Add(add);
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

        public Purchase Read(int PurchaseId)
        {
            Purchase ret;

            try
            {
                ret = dbContext.Purchase.Where(x => x.PurchaseId == PurchaseId).FirstOrDefault();

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


        public bool Update(Purchase update)
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

        public bool Delete(Purchase del)
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

        private bool Lookfor(Purchase orig)
        {
            bool found;

            found = dbContext.Purchase.Any(x => x.PurchaseId == orig.PurchaseId);

            return found;
        }

    }
}
