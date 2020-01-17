using Supplier_Bussiness.Interfaces;
using Supplier_Data;
using Supplier_Data.Context;
using Supplier_Entities.EntityModel;
using Supplier_Helper.ExceptionController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Bussiness
{
    public class PurchaseBussiness : IPurchaseBussiness
    {

        private SupplierContext dbContext;

        private ExceptionController exceptionController;

        public PurchaseBussiness()
        {
            SupplierContextProvider.InitializeSupplierContext();
            dbContext = SupplierContextProvider.GetSupplierContext();
            exceptionController = new ExceptionController();
        }

        public List<Purchase> PurchasesBiggerThanAPrizeList(double prize)
        {
            PurchaseRepository purchaseRepository = new PurchaseRepository(dbContext, exceptionController);

            List<Purchase> ret = purchaseRepository.PurchasesBiggerThanAPrizeList(prize);

            return ret;
        }

        public bool InsertPurchase(Purchase add)
        {
            bool ret;

            try
            {
                PurchaseRepository purchaseRepository = new PurchaseRepository(dbContext, exceptionController);

                ret = purchaseRepository.Insert(add);

            }
            catch (SupplierException)
            {
                throw;
            }
            catch (MissingMethodException)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.MethodNotExist);
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }

            return ret;
        }

        public bool InsertPurchaseAndProduct(Product add1, Purchase add2)
        {
            bool ret;

            try
            {
                ProductRepository productRepository = new ProductRepository(dbContext, exceptionController);

                bool ret2 = productRepository.Insert(add1);

                add2.ProductId = add1.ProductId;
                add2.Product = add1;

                PurchaseRepository purchaseRepository = new PurchaseRepository(dbContext, exceptionController);

                bool ret3 = purchaseRepository.Insert(add2);

                ret = (ret2 && ret3);

            }
            catch (SupplierException)
            {
                throw;
            }
            catch (MissingMethodException)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.MethodNotExist);
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }

            return ret;
        }

        public Purchase ReadPurchase(int PurchaseId)
        {
            Purchase ret;

            try
            {
                PurchaseRepository purchaseRepository = new PurchaseRepository(dbContext, exceptionController);

                ret = purchaseRepository.Read(PurchaseId);

            }
            catch (SupplierException)
            {
                throw;
            }
            catch (MissingMethodException)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.MethodNotExist);
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }

            return ret;
        }

        public bool UpdatePurchase(Purchase update)
        {
            bool ret;

            try
            {
                PurchaseRepository purchaseRepository = new PurchaseRepository(dbContext, exceptionController);

                Purchase current = purchaseRepository.Read(update.PurchaseId);

                current.PurchaseDate = update.PurchaseDate.Year != 1 ? update.PurchaseDate : current.PurchaseDate;
                current.Cuantity = update.Cuantity != 0 ? update.Cuantity : current.Cuantity;
                current.Prize = update.Prize != 0 ? update.Prize : current.Prize;
                current.Product = update.Product != null ? update.Product : current.Product;
                current.ProductId = update.Product != null ? update.ProductId : current.ProductId;
                current.SupplyCompany = update.SupplyCompany != null ? update.SupplyCompany : current.SupplyCompany;
                current.SupplyCompanyId = update.SupplyCompany != null ? update.SupplyCompanyId : current.SupplyCompanyId;

                ret = purchaseRepository.Update(current);

            }
            catch (SupplierException)
            {
                throw;
            }
            catch (MissingMethodException)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.MethodNotExist);
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }

            return ret;
        }

        public bool DeletePurchase(int PurchaseId)
        {
            bool ret;

            try
            {
                PurchaseRepository purchaseRepository = new PurchaseRepository(dbContext, exceptionController);

                Purchase del = purchaseRepository.Read(PurchaseId);

                ret = purchaseRepository.Delete(del);

            }
            catch (SupplierException)
            {
                throw;
            }
            catch (MissingMethodException)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.MethodNotExist);
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }

            return ret;
        }

        public bool DeletePurchaseAndChangeProduct(int PurchaseId)
        {
            bool ret;

            try
            {
                PurchaseRepository purchaseRepository = new PurchaseRepository(dbContext, exceptionController);
                Purchase del = purchaseRepository.Read(PurchaseId);

                ProductRepository productRepository = new ProductRepository(dbContext, exceptionController);
                Product update = productRepository.Read(del.Product.ProductId);
                update.Cuantity -= del.Cuantity;
                bool ret2 = productRepository.Update(update);

                bool ret3 = purchaseRepository.Delete(del);

                ret = (ret2 && ret3);

            }
            catch (SupplierException)
            {
                throw;
            }
            catch (MissingMethodException)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.MethodNotExist);
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }

            return ret;
        }

    }
}
