using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int id);
        IResult Add(User user);
        IResult Update(User user);
        IResult UpdateWithPassword(User user, string password);
        IResult Delete(User user);
        IDataResult<List<OperationClaim>> GetClaims(User user);        
        IDataResult<User> GetByMail(string email);

        IDataResult<UserDetailDto> GetUserDetailByUserId(int id);

    }
}
