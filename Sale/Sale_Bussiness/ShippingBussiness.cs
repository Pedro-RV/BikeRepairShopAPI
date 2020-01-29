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
    public class ShippingBussiness : IShippingBussiness
    {
        private SaleContext dbContext;

        private ExceptionController exceptionController;

        private IMapper mapper;

        public ShippingBussiness()
        {
            SaleContextProvider.InitializeSaleContext();
            dbContext = SaleContextProvider.GetSaleContext();
            exceptionController = new ExceptionController();


            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ShippingSpecific, Shipping>();
            });

            mapper = config.CreateMapper();
        }

        public bool InsertShipping(ShippingSpecific shippingSpecific)
        {
            bool ret;

            try
            {
                ShippingRepository shippingRepository = new ShippingRepository(dbContext, exceptionController);

                Shipping shippingAdd = mapper.Map<ShippingSpecific, Shipping>(shippingSpecific);

                ret = shippingRepository.Insert(shippingAdd);
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

        public Shipping ReadShipping(int ShippingId)
        {
            Shipping ret;

            try
            {
                ShippingRepository shippingRepository = new ShippingRepository(dbContext, exceptionController);

                ret = shippingRepository.Read(ShippingId);
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

        public bool UpdateShipping(ShippingSpecific update)
        {
            bool ret;

            try
            {
                ShippingRepository shippingRepository = new ShippingRepository(dbContext, exceptionController);
                SaleBussiness saleBussiness = new SaleBussiness();
                TransportCompanyBussiness transportCompanyBussiness = new TransportCompanyBussiness();

                Shipping current = shippingRepository.Read(update.ShippingId);

                current.DepartureDate = update.DepartureDate.Year != 1 ? update.DepartureDate : current.DepartureDate;
                current.PackingTime = update.PackingTime.Year != 1 ? update.PackingTime : current.PackingTime;

                if (update.SaleId != 0)
                {
                    current.SaleId = update.SaleId;
                    Sale saleAttach = saleBussiness.ReadSale(current.SaleId);
                    current.Sale = saleAttach;
                }

                if (update.TransportCompanyId != 0)
                {
                    current.TransportCompanyId = update.TransportCompanyId;
                    TransportCompany transportCompanyAttach = transportCompanyBussiness.ReadTransportCompany(current.TransportCompanyId);
                    current.TransportCompany = transportCompanyAttach;
                }

                ret = shippingRepository.Update(current);

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

        public bool DeleteShipping(int ShippingId)
        {
            bool ret;

            try
            {
                ShippingRepository shippingRepository = new ShippingRepository(dbContext, exceptionController);

                Shipping del = shippingRepository.Read(ShippingId);

                ret = shippingRepository.Delete(del);

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
