using AutoMapper;
using Supplier_Bussiness.Interfaces;
using Supplier_Data;
using Supplier_Data.Context;
using Supplier_Entities.EntityModel;
using Supplier_Entities.Specific;
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

        private IMapper mapper;

        public PurchaseBussiness()
        {
            SupplierContextProvider.InitializeSupplierContext();
            dbContext = SupplierContextProvider.GetSupplierContext();
            exceptionController = new ExceptionController();


            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<PurchaseSpecific, Purchase>();
            });

            mapper = config.CreateMapper();

        }

        public List<Purchase> PurchasesBiggerThanAPrizeList(double prize)
        {
            PurchaseRepository purchaseRepository = new PurchaseRepository(dbContext, exceptionController);

            List<Purchase> ret = purchaseRepository.PurchasesBiggerThanAPrizeList(prize);

            return ret;
        }

        public List<PurchaseData> PurchaseDataList()
        {
            PurchaseRepository purchaseRepository = new PurchaseRepository(dbContext, exceptionController);

            List<PurchaseData> ret = purchaseRepository.PurchaseDataList();

            return ret;
        }

        public bool InsertPurchase(PurchaseSpecific purchaseSpecific)
        {
            bool ret;

            try
            {
                PurchaseRepository purchaseRepository = new PurchaseRepository(dbContext, exceptionController);
                ProductBussiness productBussiness = new ProductBussiness();
                SupplyCompanyBussiness supplyCompanyBussiness = new SupplyCompanyBussiness();

                Purchase purchaseAdd = mapper.Map<PurchaseSpecific, Purchase>(purchaseSpecific);

                if (purchaseAdd.SupplyCompanyId != 0)
                {
                    SupplyCompany supplyCompanyAttach = supplyCompanyBussiness.ReadSupplyCompany(purchaseAdd.SupplyCompanyId);
                    purchaseAdd.SupplyCompany = supplyCompanyAttach;
                }

                if (purchaseAdd.ProductId != 0)
                {
                    Product productAttach = productBussiness.ReadProduct(purchaseAdd.ProductId);
                    purchaseAdd.Product = productAttach;
                }

                ret = purchaseRepository.Insert(purchaseAdd);

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

        public bool UpdatePurchase(PurchaseSpecific update)
        {
            bool ret;

            try
            {
                PurchaseRepository purchaseRepository = new PurchaseRepository(dbContext, exceptionController);
                ProductBussiness productBussiness = new ProductBussiness();
                SupplyCompanyBussiness supplyCompanyBussiness = new SupplyCompanyBussiness();

                Purchase current = purchaseRepository.Read(update.PurchaseId);

                current.PurchaseDate = update.PurchaseDate.Year != 1 ? update.PurchaseDate : current.PurchaseDate;
                current.Cuantity = update.Cuantity != 0 ? update.Cuantity : current.Cuantity;
                current.Prize = update.Prize != 0 ? update.Prize : current.Prize;

                if (update.SupplyCompanyId != 0)
                {
                    current.SupplyCompanyId = update.SupplyCompanyId;
                    SupplyCompany supplyCompanyAttach = supplyCompanyBussiness.ReadSupplyCompany(current.SupplyCompanyId);
                    current.SupplyCompany = supplyCompanyAttach;
                }

                if (update.ProductId != 0)
                {
                    current.ProductId = update.ProductId;
                    Product productAttach = productBussiness.ReadProduct(current.ProductId);
                    current.Product = productAttach;
                }

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
