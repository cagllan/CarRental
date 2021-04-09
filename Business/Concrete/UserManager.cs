using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
           
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.UsersListed);
        }

        public IDataResult<User> GetById(int id)
        {
            
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id), Messages.UserView);
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }



        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IDataResult<UserDetailDto> GetUserDetailByUserId(int id)
        {
            return new SuccessDataResult<UserDetailDto>(_userDal.GetUserDetail(id));
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(UserUpdateDto userUpdateDto)
        {
            var user = new User
            {
                Id = userUpdateDto.UserId,
                Email = userUpdateDto.Email,
                FirstName = userUpdateDto.FirstName,
                LastName = userUpdateDto.LastName,
                FindexScore = userUpdateDto.FindexScore,
                Status = true
            };

            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IResult UpdateWithPassword(UserUpdateDto userUpdateDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var user = new User
            {
                Id = userUpdateDto.UserId,
                Email = userUpdateDto.Email,
                FirstName = userUpdateDto.FirstName,
                LastName = userUpdateDto.LastName,
                FindexScore = userUpdateDto.FindexScore,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
