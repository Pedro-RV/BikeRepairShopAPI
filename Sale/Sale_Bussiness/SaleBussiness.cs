using AutoMapper;
using Sale_Bussiness.Interfaces;
using Sale_Data.Interfaces;
using Sale_Entities.EntityModel;
using Sale_Entities.Specific;
using Sale_Helper.ExceptionController;
using System;
using System.Configuration;
using InterconnectServicesLibrary;
using System.Collections.Generic;
using InterconnectServicesLibrary.Entities.SupplierSpecific;
using Newtonsoft.Json;
using Sale_Enums;

namespace Sale_Bussiness
{
    public class SaleBussiness : ISaleBussiness
    {
        private IExceptionController exceptionController;

        private ISaleRepository saleRepository;

        private IBillRepository billRepository;

        private IMapper mapper;

        public SaleBussiness(IExceptionController exceptionController,
            ISaleRepository saleRepository,
            IBillRepository billRepository)
        {
            this.exceptionController = exceptionController;
            this.saleRepository = saleRepository;
            this.billRepository = billRepository;


            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<SaleSpecific, Sale>();
            });

            mapper = config.CreateMapper();
        }

        public bool InsertSale(SaleSpecific saleSpecific, PaymentMethodEnum paymentMethodEnum)
        {
            bool ret = false;

            try
            {
                Sale saleAdd = mapper.Map<SaleSpecific, Sale>(saleSpecific);

                string urlGet = "https://localhost:44315/api/product/GetProduct/";
                Dictionary<string, string> queryParams = new Dictionary<string, string>();

                ProductSpecific productSpecific = JsonConvert.DeserializeObject<ProductSpecific>(
                    InterconnectServices.SendGet<object>(urlGet, queryParams, saleAdd.SupplierProductId).ToString());

                if (productSpecific.ActiveFlag == true)
                {
                    saleAdd.CuantityToPay = productSpecific.Prize * saleAdd.ProductCuantity;

                    productSpecific.Cuantity -= saleAdd.ProductCuantity;

                    if (productSpecific.Cuantity >= 0)
                    {
                        string urlPut = "https://localhost:44315/api/product/UpdateProduct";

                        InterconnectServices.SendPut(urlPut, queryParams, null, productSpecific);

                        Bill billAdd = new Bill()
                        {
                            PaymentMethodId = (int)paymentMethodEnum,
                            BillDate = DateTime.UtcNow
                        };

                        this.billRepository.Insert(billAdd);

                        saleAdd.BillId = billAdd.BillId;

                        ret = this.saleRepository.Insert(saleAdd);
                    }
                    else
                    {
                        throw this.exceptionController.CreateMyException(ExceptionEnum.ProductCuantityExceeded);
                    }
                }
                else
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.ProductNotActive);

                }
            }
            catch (SaleException)
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

        public Sale ReadSale(int SaleId)
        {
            Sale ret;

            try
            {
                ret = this.saleRepository.Read(SaleId);
            }
            catch (SaleException)
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

        public bool UpdateSale(SaleSpecific update)
        {
            bool ret;

            try
            {
                Sale current = this.saleRepository.Read(update.SaleId);

                current.CuantityToPay = update.CuantityToPay != 0 ? update.CuantityToPay : current.CuantityToPay;
                current.ProductCuantity = update.ProductCuantity != 0 ? update.ProductCuantity : current.ProductCuantity;
                current.SupplierProductId = update.SupplierProductId != 0 ? update.SupplierProductId : current.SupplierProductId;
                current.ClientId = update.ClientId != 0 ? update.ClientId : current.ClientId;
                current.BillId = update.BillId != 0 ? update.BillId : current.BillId;

                ret = this.saleRepository.Update(current);

            }
            catch (SaleException)
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

        public bool DeleteSale(int SaleId)
        {
            bool ret;

            try
            {
                Sale del = this.saleRepository.Read(SaleId);

                ret = this.saleRepository.Delete(del);

            }
            catch (SaleException)
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
