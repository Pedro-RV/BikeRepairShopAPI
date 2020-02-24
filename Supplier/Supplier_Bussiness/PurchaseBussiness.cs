using AutoMapper;
using Supplier_Bussiness.Interfaces;
using Supplier_Data;
using Supplier_Data.Context;
using Supplier_Data.Interfaces;
using Supplier_Entities.EntityModel;
using InterconnectServicesLibrary.Entities.SupplierSpecific;
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
        private IExceptionController exceptionController;

        private IPurchaseRepository purchaseRepository;

        private IProductBussiness productBussiness;

        private IMapper mapper;

        public PurchaseBussiness(IExceptionController exceptionController,
            IPurchaseRepository purchaseRepository,
            IProductBussiness productBussiness)
        {
            this.exceptionController = exceptionController;
            this.purchaseRepository = purchaseRepository;
            this.productBussiness = productBussiness;


            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<PurchaseSpecific, Purchase>();
            });

            mapper = config.CreateMapper();

        }

        public List<Purchase> PurchasesBiggerThanAPrizeList(double prize)
        {
            List<Purchase> ret = this.purchaseRepository.PurchasesBiggerThanAPrizeList(prize);

            return ret;
        }

        public List<PurchaseData> PurchaseDataList()
        {
            List<PurchaseData> ret = this.purchaseRepository.PurchaseDataList();

            return ret;
        }

        public bool InsertPurchase(PurchaseSpecific purchaseSpecific)
        {
            bool ret;

            try
            {
                Purchase purchaseAdd = mapper.Map<PurchaseSpecific, Purchase>(purchaseSpecific);

                ret = this.purchaseRepository.Insert(purchaseAdd);

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
                ret = this.purchaseRepository.Read(PurchaseId);

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
                Purchase current = this.purchaseRepository.Read(update.PurchaseId);

                current.PurchaseDate = update.PurchaseDate.Year != 1 ? update.PurchaseDate : current.PurchaseDate;
                current.Cuantity = update.Cuantity != 0 ? update.Cuantity : current.Cuantity;
                current.Prize = update.Prize != 0 ? update.Prize : current.Prize;
                current.SupplyCompanyId = update.SupplyCompanyId != 0 ? update.SupplyCompanyId : current.SupplyCompanyId;
                current.ProductId = update.ProductId != 0 ? update.ProductId : current.ProductId;

                ret = this.purchaseRepository.Update(current);

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
                Purchase del = this.purchaseRepository.Read(PurchaseId);

                ret = this.purchaseRepository.Delete(del);

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
                Purchase del = this.purchaseRepository.Read(PurchaseId);

                Product update = this.productBussiness.ReadProduct(del.Product.ProductId);
                update.Cuantity -= del.Cuantity;

                ProductSpecific upda = new ProductSpecific();
                upda.ProductId = update.ProductId;
                upda.ProductDescription = update.ProductDescription;
                upda.Prize = update.Prize;
                upda.Cuantity = update.Cuantity;
                upda.ActiveFlag = update.ActiveFlag;

                bool ret2 = this.productBussiness.UpdateProduct(upda);

                bool ret3 = this.purchaseRepository.Delete(del);

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
