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
    public class BillBussiness : IBillBussiness
    {
        private SaleContext dbContext;

        private ExceptionController exceptionController;

        private IMapper mapper;

        public BillBussiness()
        {
            SaleContextProvider.InitializeSaleContext();
            dbContext = SaleContextProvider.GetSaleContext();
            exceptionController = new ExceptionController();


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
                BillRepository billRepository = new BillRepository(dbContext, exceptionController);

                Bill billAdd = mapper.Map<BillSpecific, Bill>(billSpecific);

                ret = billRepository.Insert(billAdd);
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
                BillRepository billRepository = new BillRepository(dbContext, exceptionController);

                ret = billRepository.Read(BillId);
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
                BillRepository billRepository = new BillRepository(dbContext, exceptionController);
                PaymentMethodBussiness paymentMethodBussiness = new PaymentMethodBussiness();

                Bill current = billRepository.Read(update.BillId);

                current.BillDate = update.BillDate.Year != 1 ? update.BillDate : current.BillDate;

                if (update.PaymentMethodId != 0)
                {
                    current.PaymentMethodId = update.PaymentMethodId;
                    PaymentMethod paymentMethodAttach = paymentMethodBussiness.ReadPaymentMethod(current.PaymentMethodId);
                    current.PaymentMethod = paymentMethodAttach;
                }

                ret = billRepository.Update(current);

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
                BillRepository billRepository = new BillRepository(dbContext, exceptionController);

                Bill del = billRepository.Read(BillId);

                ret = billRepository.Delete(del);

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
