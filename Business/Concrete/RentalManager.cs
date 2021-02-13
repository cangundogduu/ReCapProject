using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        private EfRentalDal efRentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public RentalManager(EfRentalDal efRentalDal)
        {
            this.efRentalDal = efRentalDal;
        }

        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate == null)
            {
                return new ErrorResult(Messages.RentalNotAdded);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetRentalsByCarId(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetRentalsByCustomerId(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Rental rental)
        {
            throw new NotImplementedException();
        }
    }
}
