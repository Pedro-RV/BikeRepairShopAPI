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
    public class ShippingBussiness : IShippingBussiness
    {
        private IExceptionController exceptionController;

        private IShippingRepository shippingRepository;

        private IMapper mapper;

        public ShippingBussiness(IExceptionController exceptionController,
            IShippingRepository shippingRepository)
        {
            this.exceptionController = exceptionController;
            this.shippingRepository = shippingRepository;


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
                Shipping shippingAdd = mapper.Map<ShippingSpecific, Shipping>(shippingSpecific);

                ret = this.shippingRepository.Insert(shippingAdd);
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
                ret = this.shippingRepository.Read(ShippingId);
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
                Shipping current = this.shippingRepository.Read(update.ShippingId);

                current.DepartureDate = update.DepartureDate.Year != 1 ? update.DepartureDate : current.DepartureDate;
                current.PackingTime = update.PackingTime.Year != 1 ? update.PackingTime : current.PackingTime;
                current.SaleId = update.SaleId != 0 ? update.SaleId : current.SaleId;
                current.TransportCompanyId = update.TransportCompanyId != 0 ? update.TransportCompanyId : current.TransportCompanyId;

                ret = this.shippingRepository.Update(current);

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
                Shipping del = this.shippingRepository.Read(ShippingId);

                ret = this.shippingRepository.Delete(del);

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
