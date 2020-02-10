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
    public class PaymentMethodBussiness : IPaymentMethodBussiness
    {
        private IExceptionController exceptionController;

        private IPaymentMethodRepository paymentMethodRepository;

        private IMapper mapper;

        public PaymentMethodBussiness(IExceptionController exceptionController,
            IPaymentMethodRepository paymentMethodRepository)
        {
            this.exceptionController = exceptionController;
            this.paymentMethodRepository = paymentMethodRepository;


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
                PaymentMethod paymentMethodAdd = mapper.Map<PaymentMethodSpecific, PaymentMethod>(paymentMethodSpecific);

                ret = this.paymentMethodRepository.Insert(paymentMethodAdd);
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
                ret = this.paymentMethodRepository.Read(PaymentMethodId);
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
                PaymentMethod current = this.paymentMethodRepository.Read(update.PaymentMethodId);

                current.PaymentMethodDescription = !string.IsNullOrEmpty(update.PaymentMethodDescription) ? update.PaymentMethodDescription : current.PaymentMethodDescription;

                ret = this.paymentMethodRepository.Update(current);

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
                PaymentMethod del = this.paymentMethodRepository.Read(PaymentMethodId);

                ret = this.paymentMethodRepository.Delete(del);

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
