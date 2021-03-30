using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(b => b.FullName).NotEmpty();
            RuleFor(b => b.CardNumber).NotEmpty();
            RuleFor(b => b.Month).NotEmpty();
            RuleFor(b => b.Year).NotEmpty();
            RuleFor(b => b.Ccv).NotEmpty();
        }
    }
}
