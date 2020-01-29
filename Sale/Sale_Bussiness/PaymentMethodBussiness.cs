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
    public class PaymentMethodBussiness : IPaymentMethodBussiness
    {
        private SaleContext dbContext;

        private ExceptionController exceptionController;

        private IMapper mapper;

        public PaymentMethodBussiness()
        {
            SaleContextProvider.InitializeSaleContext();
            dbContext = SaleContextProvider.GetSaleContext();
            exceptionController = new ExceptionController();


            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<PaymentMethodSpecific, PaymentMethod>();
            });

            mapper = config.CreateMapper();
        }

        public bool InsertPaymentMethod(PaymentMethodSpecific paymentMethodSpecific)
        {
            bool ret;

            try
            {
                PaymentMethodRepository paymentMethodRepository = new PaymentMethodRepository(dbContext, exceptionController);

                PaymentMethod paymentMethodAdd = mapper.Map<PaymentMethodSpecific, PaymentMethod>(paymentMethodSpecific);

                ret = paymentMethodRepository.Insert(paymentMethodAdd);
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

        public PaymentMethod ReadPaymentMethod(int PaymentMethodId)
        {
            PaymentMethod ret;

            try
            {
                PaymentMethodRepository paymentMethodRepository = new PaymentMethodRepository(dbContext, exceptionController);

                ret = paymentMethodRepository.Read(PaymentMethodId);
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

        public bool UpdatePaymentMethod(PaymentMethodSpecific update)
        {
            bool ret;

            try
            {
                PaymentMethodRepository paymentMethodRepository = new PaymentMethodRepository(dbContext, exceptionController);

                PaymentMethod current = paymentMethodRepository.Read(update.PaymentMethodId);

                current.PaymentMethodDescription = !String.IsNullOrEmpty(update.PaymentMethodDescription) ? update.PaymentMethodDescription : current.PaymentMethodDescription;

                ret = paymentMethodRepository.Update(current);

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

        public bool DeletePaymentMethod(int PaymentMethodId)
        {
            bool ret;

            try
            {
                PaymentMethodRepository paymentMethodRepository = new PaymentMethodRepository(dbContext, exceptionController);

                PaymentMethod del = paymentMethodRepository.Read(PaymentMethodId);

                ret = paymentMethodRepository.Delete(del);

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
