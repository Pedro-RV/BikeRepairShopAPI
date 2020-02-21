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
    public class BillBussiness : IBillBussiness
    {
        private IExceptionController exceptionController;

        private IBillRepository billRepository;

        private IMapper mapper;

        public BillBussiness(IExceptionController exceptionController,
            IBillRepository billRepository)
        {
            this.exceptionController = exceptionController;
            this.billRepository = billRepository;

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<BillSpecific, Bill>();
            });

            mapper = config.CreateMapper();
        }

        public bool InsertBill(BillSpecific billSpecific)
        {
            bool ret;

            try
            {
                Bill billAdd = mapper.Map<BillSpecific, Bill>(billSpecific);

                ret = this.billRepository.Insert(billAdd);
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

        public Bill ReadBill(int BillId)
        {
            Bill ret;

            try
            {
                ret = this.billRepository.Read(BillId);
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

        public bool UpdateBill(BillSpecific update)
        {
            bool ret;

            try
            {
                Bill current = this.billRepository.Read(update.BillId);

                current.BillDate = update.BillDate.Year != 1 ? update.BillDate : current.BillDate;
                current.PaymentMethodId = update.PaymentMethodId != 0 ? update.PaymentMethodId : current.PaymentMethodId;

                ret = this.billRepository.Update(current);

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

        public bool DeleteBill(int BillId)
        {
            bool ret;

            try
            {
                Bill del = this.billRepository.Read(BillId);

                ret = this.billRepository.Delete(del);

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
