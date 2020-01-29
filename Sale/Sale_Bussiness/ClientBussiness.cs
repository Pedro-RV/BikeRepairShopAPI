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
    public class ClientBussiness : IClientBussiness
    {
        private SaleContext dbContext;

        private ExceptionController exceptionController;

        private IMapper mapper;

        public ClientBussiness()
        {
            SaleContextProvider.InitializeSaleContext();
            dbContext = SaleContextProvider.GetSaleContext();
            exceptionController = new ExceptionController();


            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ClientSpecific, Client>();
            });

            mapper = config.CreateMapper();
        }

        public bool InsertClient(ClientSpecific clientSpecific)
        {
            bool ret;

            try
            {
                ClientRepository clientRepository = new ClientRepository(dbContext, exceptionController);

                Client clientAdd = mapper.Map<ClientSpecific, Client>(clientSpecific);

                ret = clientRepository.Insert(clientAdd);
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

        public Client ReadClient(int ClientId)
        {
            Client ret;

            try
            {
                ClientRepository clientRepository = new ClientRepository(dbContext, exceptionController);

                ret = clientRepository.Read(ClientId);
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

        public bool UpdateClient(ClientSpecific update)
        {
            bool ret;

            try
            {
                ClientRepository clientRepository = new ClientRepository(dbContext, exceptionController);

                Client current = clientRepository.Read(update.ClientId);

                current.ClientName = !String.IsNullOrEmpty(update.ClientName) ? update.ClientName : current.ClientName;
                current.Surname = !String.IsNullOrEmpty(update.Surname) ? update.Surname : current.Surname;
                current.Email = !String.IsNullOrEmpty(update.Email) ? update.Email : current.Email;
                current.DNI = !String.IsNullOrEmpty(update.DNI) ? update.DNI : current.DNI;
                current.ClientAddress = !String.IsNullOrEmpty(update.ClientAddress) ? update.ClientAddress : current.ClientAddress;
                current.CP = !String.IsNullOrEmpty(update.CP) ? update.CP : current.CP;
                current.MobileNum = !String.IsNullOrEmpty(update.MobileNum) ? update.MobileNum : current.MobileNum;

                ret = clientRepository.Update(current);

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

        public bool DeleteClient(int ClientId)
        {
            bool ret;

            try
            {
                ClientRepository clientRepository = new ClientRepository(dbContext, exceptionController);

                Client del = clientRepository.Read(ClientId);

                ret = clientRepository.Delete(del);

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
