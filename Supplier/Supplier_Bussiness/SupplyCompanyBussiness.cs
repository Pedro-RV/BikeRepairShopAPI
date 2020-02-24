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
    public class SupplyCompanyBussiness : ISupplyCompanyBussiness
    {
        private IExceptionController exceptionController;

        private ISupplyCompanyRepository supplyCompanyRepository;

        private IMapper mapper;

        public SupplyCompanyBussiness(IExceptionController exceptionController,
            ISupplyCompanyRepository supplyCompanyRepository)
        {
            this.exceptionController = exceptionController;
            this.supplyCompanyRepository = supplyCompanyRepository;


            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<SupplyCompanySpecific, SupplyCompany>();
            });

            mapper = config.CreateMapper();
        }

        public bool InsertSupplyCompany(SupplyCompanySpecific supplyCompanySpecific)
        {
            bool ret;

            try
            {
                SupplyCompany supplyCompanyAdd = mapper.Map<SupplyCompanySpecific, SupplyCompany>(supplyCompanySpecific);

                ret = this.supplyCompanyRepository.Insert(supplyCompanyAdd);

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

        public SupplyCompany ReadSupplyCompany(int SupplyCompanyId)
        {
            SupplyCompany ret;

            try
            {
                ret = this.supplyCompanyRepository.Read(SupplyCompanyId);

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

        public bool UpdateSupplyCompany(SupplyCompanySpecific update)
        {
            bool ret;

            try
            {
                SupplyCompany current = this.supplyCompanyRepository.Read(update.SupplyCompanyId);

                current.SupplyCompanyName = !string.IsNullOrEmpty(update.SupplyCompanyName) ? update.SupplyCompanyName : current.SupplyCompanyName;
                current.TelephoneNum = !string.IsNullOrEmpty(update.TelephoneNum) ? update.TelephoneNum : current.TelephoneNum;

                ret = this.supplyCompanyRepository.Update(current);

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

        public bool DeleteSupplyCompany(int SupplyCompanyId)
        {
            bool ret;

            try
            {
                SupplyCompany del = this.supplyCompanyRepository.Read(SupplyCompanyId);

                ret = this.supplyCompanyRepository.Delete(del);

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
