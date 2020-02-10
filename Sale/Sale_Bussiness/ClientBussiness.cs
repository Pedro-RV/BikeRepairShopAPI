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
    public class ClientBussiness : IClientBussiness
    {
        private IExceptionController exceptionController;

        private IClientRepository clientRepository;

        private IMapper mapper;

        public ClientBussiness(IExceptionController exceptionController,
            IClientRepository clientRepository)
        {
            this.exceptionController = exceptionController;
            this.clientRepository = clientRepository;


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
                Client clientAdd = mapper.Map<ClientSpecific, Client>(clientSpecific);

                ret = this.clientRepository.Insert(clientAdd);
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
                ret = this.clientRepository.Read(ClientId);
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
                Client current = this.clientRepository.Read(update.ClientId);

                current.ClientName = !string.IsNullOrEmpty(update.ClientName) ? update.ClientName : current.ClientName;
                current.Surname = !string.IsNullOrEmpty(update.Surname) ? update.Surname : current.Surname;
                current.Email = !string.IsNullOrEmpty(update.Email) ? update.Email : current.Email;
                current.DNI = !string.IsNullOrEmpty(update.DNI) ? update.DNI : current.DNI;
                current.ClientAddress = !string.IsNullOrEmpty(update.ClientAddress) ? update.ClientAddress : current.ClientAddress;
                current.CP = !string.IsNullOrEmpty(update.CP) ? update.CP : current.CP;
                current.MobileNum = !string.IsNullOrEmpty(update.MobileNum) ? update.MobileNum : current.MobileNum;

                ret = this.clientRepository.Update(current);

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
                Client del = this.clientRepository.Read(ClientId);

                ret = this.clientRepository.Delete(del);

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
