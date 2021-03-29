using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BankManager : IBankService
    {
        public IResult Add(Payment payment)
        {
            return new SuccessResult("Ödeme işlemi gerçekleştirildi.");
        }
    }
}
