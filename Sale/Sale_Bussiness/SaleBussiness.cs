using AutoMapper;
using Sale_Bussiness.Interfaces;
using Sale_Data;
using Sale_Data.Context;
using Sale_Data.Interfaces;
using Sale_Entities.EntityModel;
using Sale_Entities.Specific;
using Sale_Helper.ExceptionController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Bussiness
{
    public class SaleBussiness : ISaleBussiness
    {
        private IExceptionController exceptionController;

        private ISaleRepository saleRepository;

        private IClientBussiness clientBussiness;

        private IBillBussiness billBussiness;

        private IMapper mapper;

        public SaleBussiness(IExceptionController exceptionController,
            ISaleRepository saleRepository,
            IClientBussiness clientBussiness,           
            IBillBussiness billBussiness)
        {
            this.exceptionController = exceptionController;
            this.saleRepository = saleRepository;
            this.clientBussiness = clientBussiness;
            this.billBussiness = billBussiness;


            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<SaleSpecific, Sale>();
            });

            mapper = config.CreateMapper();
        }

        public bool InsertSale(SaleSpecific saleSpecific)
        {
            bool ret;

            try
            {
                Sale saleAdd = mapper.Map<SaleSpecific, Sale>(saleSpecific);

                ret = this.saleRepository.Insert(saleAdd);
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

                current.Cuantity = update.Cuantity != 0 ? update.Cuantity : current.Cuantity;

                if (update.ClientId != 0)
                {
                    current.ClientId = update.ClientId;
                    Client clientAttach = this.clientBussiness.ReadClient(current.ClientId);
                    current.Client = clientAttach;
                }

                //if (update.ProductId != 0)
                //{
                //    current.ProductId = update.ProductId;
                //    Product productAttach = this.productBussiness.ReadProduct(current.ProductId);
                //    current.Product = productAttach;
                //}

                if (update.BillId != 0)
                {
                    current.BillId = update.BillId;
                    Bill billAttach = this.billBussiness.ReadBill(current.BillId);
                    current.Bill = billAttach;
                }

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
