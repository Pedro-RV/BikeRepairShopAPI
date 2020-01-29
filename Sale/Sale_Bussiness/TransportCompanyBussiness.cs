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
    public class TransportCompanyBussiness : ITransportCompanyBussiness
    {
        private SaleContext dbContext;

        private ExceptionController exceptionController;

        private IMapper mapper;

        public TransportCompanyBussiness()
        {
            SaleContextProvider.InitializeSaleContext();
            dbContext = SaleContextProvider.GetSaleContext();
            exceptionController = new ExceptionController();


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
                TransportCompanyRepository transportCompanyRepository = new TransportCompanyRepository(dbContext, exceptionController);

                TransportCompany transportCompanyAdd = mapper.Map<TransportCompanySpecific, TransportCompany>(transportCompanySpecific);

                ret = transportCompanyRepository.Insert(transportCompanyAdd);
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
                TransportCompanyRepository transportCompanyRepository = new TransportCompanyRepository(dbContext, exceptionController);

                ret = transportCompanyRepository.Read(TransportCompanyId);
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
                TransportCompanyRepository transportCompanyRepository = new TransportCompanyRepository(dbContext, exceptionController);

                TransportCompany current = transportCompanyRepository.Read(update.TransportCompanyId);

                current.TransportCompanyName = !String.IsNullOrEmpty(update.TransportCompanyName) ? update.TransportCompanyName : current.TransportCompanyName;
                current.TelephoneNum = !String.IsNullOrEmpty(update.TelephoneNum) ? update.TelephoneNum : current.TelephoneNum;

                ret = transportCompanyRepository.Update(current);

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
                TransportCompanyRepository transportCompanyRepository = new TransportCompanyRepository(dbContext, exceptionController);

                TransportCompany del = transportCompanyRepository.Read(TransportCompanyId);

                ret = transportCompanyRepository.Delete(del);

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
