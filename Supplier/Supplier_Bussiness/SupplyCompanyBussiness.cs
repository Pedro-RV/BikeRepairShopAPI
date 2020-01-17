using Supplier_Bussiness.Interfaces;
using Supplier_Data;
using Supplier_Data.Context;
using Supplier_Entities.EntityModel;
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

        private SupplierContext dbContext;

        private ExceptionController exceptionController;

        public SupplyCompanyBussiness()
        {
            SupplierContextProvider.InitializeSupplierContext();
            dbContext = SupplierContextProvider.GetSupplierContext();
            exceptionController = new ExceptionController();
        }

        public bool InsertSupplyCompany(SupplyCompany supplyCompanyAdd)
        {
            bool ret;

            try
            {
                SupplyCompanyRepository supplyCompanyRepository = new SupplyCompanyRepository(dbContext, exceptionController);

                ret = supplyCompanyRepository.Insert(supplyCompanyAdd);

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
                SupplyCompanyRepository supplyCompanyRepository = new SupplyCompanyRepository(dbContext, exceptionController);

                ret = supplyCompanyRepository.Read(SupplyCompanyId);

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

        public bool UpdateSupplyCompany(SupplyCompany update)
        {
            bool ret;

            try
            {
                SupplyCompanyRepository supplyCompanyRepository = new SupplyCompanyRepository(dbContext, exceptionController);

                SupplyCompany current = supplyCompanyRepository.Read(update.SupplyCompanyId);

                current.SupplyCompanyName = !String.IsNullOrEmpty(update.SupplyCompanyName) ? update.SupplyCompanyName : current.SupplyCompanyName;
                current.TelephoneNum = !String.IsNullOrEmpty(update.TelephoneNum) ? update.TelephoneNum : current.TelephoneNum;

                ret = supplyCompanyRepository.Update(current);

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
                SupplyCompanyRepository supplyCompanyRepository = new SupplyCompanyRepository(dbContext, exceptionController);

                SupplyCompany del = supplyCompanyRepository.Read(SupplyCompanyId);

                ret = supplyCompanyRepository.Delete(del);

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
