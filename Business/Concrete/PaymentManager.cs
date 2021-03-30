using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        [ValidationAspect(typeof(PaymentValidator))]
        public IResult Add(Payment payment)
        {
            return new SuccessResult("Ödeme işlemi gerçekleştirildi.");
        }
    }
}
