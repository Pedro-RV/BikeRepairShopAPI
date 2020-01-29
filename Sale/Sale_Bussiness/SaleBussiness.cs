using AutoMapper;
using Sale_Bussiness.Interfaces;
using Sale_Data;
using Sale_Data.Context;
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
        private SaleContext dbContext;

        private ExceptionController exceptionController;

        private IMapper mapper;

        public SaleBussiness()
        {
            SaleContextProvider.InitializeSaleContext();
            dbContext = SaleContextProvider.GetSaleContext();
            exceptionController = new ExceptionController();


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
                SaleRepository saleRepository = new SaleRepository(dbContext, exceptionController);

                Sale saleAdd = mapper.Map<SaleSpecific, Sale>(saleSpecific);

                ret = saleRepository.Insert(saleAdd);
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
                SaleRepository saleRepository = new SaleRepository(dbContext, exceptionController);

                ret = saleRepository.Read(SaleId);
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
                SaleRepository saleRepository = new SaleRepository(dbContext, exceptionController);
                ClientBussiness clientBussiness = new ClientBussiness();
                ProductBussiness productBussiness = new ProductBussiness();
                BillBussiness billBussiness = new BillBussiness();

                Sale current = saleRepository.Read(update.SaleId);

                current.Cuantity = update.Cuantity != 0 ? update.Cuantity : current.Cuantity;

                if (update.ClientId != 0)
                {
                    current.ClientId = update.ClientId;
                    Client clientAttach = clientBussiness.ReadClient(current.ClientId);
                    current.Client = clientAttach;
                }

                if (update.ProductId != 0)
                {
                    current.ProductId = update.ProductId;
                    Product productAttach = productBussiness.ReadProduct(current.ProductId);
                    current.Product = productAttach;
                }

                if (update.BillId != 0)
                {
                    current.BillId = update.BillId;
                    Bill billAttach = billBussiness.ReadBill(current.BillId);
                    current.Bill = billAttach;
                }

                ret = saleRepository.Update(current);

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
                SaleRepository saleRepository = new SaleRepository(dbContext, exceptionController);

                Sale del = saleRepository.Read(SaleId);

                ret = saleRepository.Delete(del);

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
