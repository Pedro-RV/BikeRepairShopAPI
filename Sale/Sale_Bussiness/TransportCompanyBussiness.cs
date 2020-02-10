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
    public class TransportCompanyBussiness : ITransportCompanyBussiness
    {
        private IExceptionController exceptionController;

        private ITransportCompanyRepository transportCompanyRepository;

        private IMapper mapper;

        public TransportCompanyBussiness(IExceptionController exceptionController,
            ITransportCompanyRepository transportCompanyRepository)
        {
            this.exceptionController = exceptionController;
            this.transportCompanyRepository = transportCompanyRepository;


            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<TransportCompanySpecific, TransportCompany>();
            });

            mapper = config.CreateMapper();
        }

        public bool InsertTransportCompany(TransportCompanySpecific transportCompanySpecific)
        {
            bool ret;

            try
            {
                TransportCompany transportCompanyAdd = mapper.Map<TransportCompanySpecific, TransportCompany>(transportCompanySpecific);

                ret = this.transportCompanyRepository.Insert(transportCompanyAdd);
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

        public TransportCompany ReadTransportCompany(int TransportCompanyId)
        {
            TransportCompany ret;

            try
            {
                ret = this.transportCompanyRepository.Read(TransportCompanyId);
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

        public bool UpdateTransportCompany(TransportCompanySpecific update)
        {
            bool ret;

            try
            {
                TransportCompany current = this.transportCompanyRepository.Read(update.TransportCompanyId);

                current.TransportCompanyName = !string.IsNullOrEmpty(update.TransportCompanyName) ? update.TransportCompanyName : current.TransportCompanyName;
                current.TelephoneNum = !string.IsNullOrEmpty(update.TelephoneNum) ? update.TelephoneNum : current.TelephoneNum;

                ret = this.transportCompanyRepository.Update(current);

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

        public bool DeleteTransportCompany(int TransportCompanyId)
        {
            bool ret;

            try
            {
                TransportCompany del = this.transportCompanyRepository.Read(TransportCompanyId);

                ret = this.transportCompanyRepository.Delete(del);

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
