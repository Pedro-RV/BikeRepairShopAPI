using Supplier_Entities.EntityModel;
using Supplier_Data.Context;
using System.Linq;
using System.Data.Entity;
using Supplier_Data.Interfaces;
using System;
using Supplier_Helper.ExceptionController;
using System.Collections.Generic;
using Supplier_Entities.Specific;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Supplier_Data
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private SupplierContext dbContext;

        private ExceptionController exceptionController;

        public WarehouseRepository(SupplierContext dbContext, ExceptionController exceptionController)
        {
            this.dbContext = dbContext;
            this.exceptionController = exceptionController;
        }

        public List<Warehouse> WarehousesBiggerThanAnExtensionList(int extension)
        {
            List<Warehouse> ret = dbContext.Warehouse.Where(x => x.Extension > extension).ToList();

            return ret;
        }       

        public bool Insert(Warehouse add)
        {
            bool ret = false;

            try
            {
                if (add == null)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.NullObject);
                }

                if (add.WarehouseAddress == null)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.NullWarehouseAddress);
                }

                dbContext.Warehouse.Add(add);
                dbContext.SaveChanges();
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

        public Warehouse Read(int WarehouseId)
        {
            Warehouse ret = new Warehouse();

            try
            {
                ret = dbContext.Warehouse.Where(x => x.WarehouseId == WarehouseId).FirstOrDefault();

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


        public bool Update(Warehouse update)
        {
            bool ret = false;
            bool exist = Lookfor(update);

            try
            {
                if (!exist)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.ObjectNotFound);
                }

                dbContext.Entry(update).State = EntityState.Modified;
                dbContext.SaveChanges();
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

        public bool Delete(Warehouse del)
        {
            bool ret = false;
            bool exist = Lookfor(del);

            try
            {
                if (!exist)
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.ObjectNotFound); 
                }

                dbContext.Entry(del).State = EntityState.Deleted;
                dbContext.SaveChanges();
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

        private bool Lookfor(Warehouse orig)
        {
            bool found;

            found = dbContext.Warehouse.Any(x => x.WarehouseId == orig.WarehouseId);

            return found;
        }

    }
}
