using AutoMapper;
using Supplier_Bussiness.Interfaces;
using Supplier_Data;
using Supplier_Data.Context;
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
        private SupplierContext dbContext;

        private ExceptionController exceptionController;

        private IMapper mapper;

        public WarehouseAdminBussiness()
        {
            SupplierContextProvider.InitializeSupplierContext();
            dbContext = SupplierContextProvider.GetSupplierContext();
            exceptionController = new ExceptionController();



            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<WarehouseAdminSpecific, WarehouseAdmin>();
            });

            mapper = config.CreateMapper();

        }

        public List<WarehouseAdminData> WarehouseAdminDataList(string warehouseAddress)
        {
            WarehouseAdminRepository warehouseAdminRepository = new WarehouseAdminRepository(dbContext, exceptionController);

            //List<WarehouseAdminData> ret = warehouseAdminRepository.WarehouseAdminDataList();

            //Llamar a la de Dapper
            List<WarehouseAdminData> ret = warehouseAdminRepository.WarehouseAdminDataListWithDapper(warehouseAddress);

            return ret;
        }

        public bool InsertWarehouseAdmin(WarehouseAdminSpecific warehouseAdminSpecific)
        {
            bool ret;

            try
            {
                WarehouseAdminRepository warehouseAdminRepository = new WarehouseAdminRepository(dbContext, exceptionController);
                EmployeeBussiness employeeBussiness = new EmployeeBussiness();
                WarehouseBussiness warehouseBussiness = new WarehouseBussiness();

                WarehouseAdmin warehouseAdminAdd = mapper.Map<WarehouseAdminSpecific, WarehouseAdmin>(warehouseAdminSpecific);                

                if (warehouseAdminAdd.EmployeeId != 0)
                {
                    Employee employeeAttach = employeeBussiness.ReadEmployee(warehouseAdminAdd.EmployeeId);
                    warehouseAdminAdd.Employee = employeeAttach;
                }

                if (warehouseAdminAdd.WarehouseId != 0)
                {
                    Warehouse warehouseAttach = warehouseBussiness.ReadWarehouse(warehouseAdminAdd.WarehouseId);
                    warehouseAdminAdd.Warehouse = warehouseAttach;
                }

                ret = warehouseAdminRepository.Insert(warehouseAdminAdd);

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
                WarehouseAdminRepository warehouseAdminRepository = new WarehouseAdminRepository(dbContext, exceptionController);

                ret = warehouseAdminRepository.Read(WarehouseAdminId);

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
                WarehouseAdminRepository warehouseAdminRepository = new WarehouseAdminRepository(dbContext, exceptionController);
                EmployeeBussiness employeeBussiness = new EmployeeBussiness();
                WarehouseBussiness warehouseBussiness = new WarehouseBussiness();

                WarehouseAdmin current = warehouseAdminRepository.Read(update.WarehouseAdminId);

                current.StartDate = update.StartDate.Year != 1 ? update.StartDate : current.StartDate;               

                if (update.EmployeeId != 0){
                    current.EmployeeId = update.EmployeeId;
                    Employee employeeAttach = employeeBussiness.ReadEmployee(current.EmployeeId);
                    current.Employee = employeeAttach;
                }

                if (update.WarehouseId != 0)
                {
                    current.WarehouseId = update.WarehouseId;
                    Warehouse warehouseAttach = warehouseBussiness.ReadWarehouse(current.WarehouseId);
                    current.Warehouse = warehouseAttach;
                }

                ret = warehouseAdminRepository.Update(current);

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
                WarehouseAdminRepository warehouseAdminRepository = new WarehouseAdminRepository(dbContext, exceptionController);

                WarehouseAdmin del = warehouseAdminRepository.Read(WarehouseAdminId);

                ret = warehouseAdminRepository.Delete(del);

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
