using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CardManager : ICardService
    {
        ICardDal _cardDal;

        public CardManager(ICardDal cardDal)
        {
            _cardDal = cardDal;
        }

        public IResult Add(Card card)
        {
            _cardDal.Add(card);
            return new SuccessResult("Kart eklendi.");
        }

        public IResult Delete(Card card)
        {
            _cardDal.Delete(card);
            return new SuccessResult("Kart silindi.");
        }

        public IDataResult<List<Card>> GetAll()
        {
            return new SuccessDataResult<List<Card>>(_cardDal.GetAll(), "Kartlar listelendi");
        }

        public IDataResult<Card> GetById(int id)
        {
            return new SuccessDataResult<Card>(_cardDal.Get(c => c.Id == id), "Kart görüntülendi");
        }

        public IDataResult<Card> GetByUserId(int id)
        {
            return new SuccessDataResult<Card>(_cardDal.Get(c => c.UserId == id), "Kart görüntülendi");
        }

        public IResult Update(Card card)
        {
            _cardDal.Update(card);
            return new SuccessResult("Kart güncellendi.");
        }
    }
}
