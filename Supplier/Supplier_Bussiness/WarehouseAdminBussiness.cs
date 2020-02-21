using AutoMapper;
using Supplier_Bussiness.Interfaces;
using Supplier_Data;
using Supplier_Data.Context;
using Supplier_Data.Interfaces;
using Supplier_Entities.EntityModel;
using Supplier_Entities.Specific;
using Supplier_Helper.ExceptionController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Bussiness
{
    public class WarehouseAdminBussiness : IWarehouseAdminBussiness
    {
        private IExceptionController exceptionController;

        private IWarehouseAdminRepository warehouseAdminRepository;

        private IMapper mapper;

        public WarehouseAdminBussiness(IExceptionController exceptionController,
            IWarehouseAdminRepository warehouseAdminRepository)
        {
            this.exceptionController = exceptionController;
            this.warehouseAdminRepository = warehouseAdminRepository;


            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<WarehouseAdminSpecific, WarehouseAdmin>();
            });

            mapper = config.CreateMapper();

        }

        public List<WarehouseAdminData> WarehouseAdminDataList(string warehouseAddress)
        {
            //List<WarehouseAdminData> ret = warehouseAdminRepository.WarehouseAdminDataList();

            //Llamar a la de Dapper
            List<WarehouseAdminData> ret = this.warehouseAdminRepository.WarehouseAdminDataListWithDapper(warehouseAddress);

            return ret;
        }

        public bool InsertWarehouseAdmin(WarehouseAdminSpecific warehouseAdminSpecific)
        {
            bool ret;

            try
            {
                WarehouseAdmin warehouseAdminAdd = mapper.Map<WarehouseAdminSpecific, WarehouseAdmin>(warehouseAdminSpecific);

                ret = this.warehouseAdminRepository.Insert(warehouseAdminAdd);

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

        public WarehouseAdmin ReadWarehouseAdmin(int WarehouseAdminId)
        {
            WarehouseAdmin ret;

            try
            {
                ret = this.warehouseAdminRepository.Read(WarehouseAdminId);

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

        public bool UpdateWarehouseAdmin(WarehouseAdminSpecific update)
        {
            bool ret;

            try
            {
                WarehouseAdmin current = this.warehouseAdminRepository.Read(update.WarehouseAdminId);

                current.StartDate = update.StartDate.Year != 1 ? update.StartDate : current.StartDate;
                current.EmployeeId = update.EmployeeId != 0 ? update.EmployeeId : current.EmployeeId;
                current.WarehouseId = update.WarehouseId != 0 ? update.WarehouseId : current.WarehouseId;

                ret = this.warehouseAdminRepository.Update(current);

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

        public bool DeleteWarehouseAdmin(int WarehouseAdminId)
        {
            bool ret;

            try
            {
                WarehouseAdmin del = this.warehouseAdminRepository.Read(WarehouseAdminId);

                ret = this.warehouseAdminRepository.Delete(del);

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
