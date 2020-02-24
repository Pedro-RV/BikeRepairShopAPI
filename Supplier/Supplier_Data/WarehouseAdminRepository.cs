using Supplier_Entities.EntityModel;
using Supplier_Data.Context;
using System.Linq;
using System.Data.Entity;
using Supplier_Data.Interfaces;
using System;
using Supplier_Helper.ExceptionController;
using InterconnectServicesLibrary.Entities.SupplierSpecific;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Dapper;

namespace Supplier_Data
{
    public class WarehouseAdminRepository : IWarehouseAdminRepository
    {
        private SupplierContext dbContext;

        private ISupplierContextProvider supplierContextProvider;

        private IExceptionController exceptionController;

        public WarehouseAdminRepository(ISupplierContextProvider supplierContextProvider, IExceptionController exceptionController)
        {
            this.supplierContextProvider = supplierContextProvider;
            this.supplierContextProvider.InitializeSupplierContext();
            this.dbContext = this.supplierContextProvider.GetSupplierContext();
            this.exceptionController = exceptionController;
        }

        public List<WarehouseAdminData> WarehouseAdminDataList()
        {
            List<WarehouseAdminData> ret = this.dbContext.WarehouseAdmin
                .Join(this.dbContext.Warehouse,
                    warehouseAdmin => warehouseAdmin.WarehouseId,
                    warehouse => warehouse.WarehouseId,
                    (warehouseAdmin, warehouse) => new
                    {
                        WarehouseAdmin = warehouseAdmin,
                        Warehouse = warehouse
                    })
                .Join(
                    this.dbContext.Employee,
                    combined => combined.WarehouseAdmin.EmployeeId,
                    employee => employee.EmployeeId,
                    (combined, employee) => new WarehouseAdminData()
                    {
                        WarehouseAdminId = combined.WarehouseAdmin.WarehouseAdminId,
                        StartDate = combined.WarehouseAdmin.StartDate,
                        EmployeeId = employee.EmployeeId,
                        EmployeeName = employee.EmployeeName,
                        DNI = employee.DNI,
                        WarehouseId = combined.Warehouse.WarehouseId,
                        WarehouseAddress = combined.Warehouse.WarehouseAddress
                    }).ToList();

            return ret;
        }

        public List<WarehouseAdminData> WarehouseAdminDataListWithDapper(string warehouseAddress)
        {
            List<WarehouseAdminData> ret = new List<WarehouseAdminData>();

            //SqlConnection connection = new SqlConnection(ConfigurationManager.Connectionstrings["SupplierContext"].Connectionstring);

            //if (connection.State == ConnectionState.Closed)
            //    connection.Open();

            //string query = "SELECT A.WarehouseAdminId, A.StartDate, C.EmployeeId, C.EmployeeName, C.DNI, B.WarehouseId, " +
            //    "B.WarehouseAddress FROM WarehouseAdmin A " +
            //    "JOIN Warehouse B ON A.WarehouseId = B.WarehouseId " +
            //    "JOIN Employee C ON A.EmployeeId = C.EmployeeId " +
            //    "WHERE B.WarehouseAddress = @WarehouseAddress";

            //ret = connection.Query<WarehouseAdminData>(query, new { WarehouseAddress = warehouseAddress }).ToList();

            return ret;
        }

        public bool Insert(WarehouseAdmin add)
        {
            bool ret = false;

            try
            {

                if (add == null)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.NullObject);
                }

                this.dbContext.WarehouseAdmin.Add(add);
                this.dbContext.SaveChanges();
                ret = true;

            }
            catch (SupplierException)
            {
                throw;
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }

            return ret;
        }

        public WarehouseAdmin Read(int WarehouseAdminId)
        {
            WarehouseAdmin ret = new WarehouseAdmin();

            try
            {
                ret = this.dbContext.WarehouseAdmin.Where(x => x.WarehouseAdminId == WarehouseAdminId).FirstOrDefault();

                if (ret == null)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.ObjectNotFound);
                }

            }
            catch (SupplierException)
            {
                throw;
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }

            return ret;
        }


        public bool Update(WarehouseAdmin update)
        {
            bool ret = false;
            bool exist = Lookfor(update);

            try
            {
                if (!exist)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.ObjectNotFound);
                }

                this.dbContext.Entry(update).State = EntityState.Modified;
                this.dbContext.SaveChanges();
                ret = true;

            }
            catch (SupplierException)
            {
                throw;
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }

            return ret;
        }

        public bool Delete(WarehouseAdmin del)
        {
            bool ret = false;
            bool exist = Lookfor(del);

            try
            {
                if (!exist)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.ObjectNotFound);
                }

                this.dbContext.Entry(del).State = EntityState.Deleted;
                this.dbContext.SaveChanges();
                ret = true;

            }
            catch (SupplierException)
            {
                throw;
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }

            return ret;
        }

        private bool Lookfor(WarehouseAdmin orig)
        {
            bool found;

            found = this.dbContext.WarehouseAdmin.Any(x => x.WarehouseAdminId == orig.WarehouseAdminId);

            return found;
        }

    }
}
