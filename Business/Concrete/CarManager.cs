using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

using System.Text;

namespace Business.Concrete
{
   public class CarManager : ICarService
    {
        ICarDal _carDal;
       

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }

        
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),"Araçlar detaylarına göre listelendi.");
        }

        public IResult Add(Car car)
        {
            if (car.CarName.Length < 2)
            {
                return new ErrorDataResult<Car>(Messages.CarNameInvalid);
            }
            _carDal.Add(car);
            return new SuccessDataResult<Car>(Messages.CarAdded);
        }

        public IResult Update(Car car)
        {
           _carDal.Update(car);
            return new SuccessDataResult<Car>(Messages.CarUpdated);
        }

        public IResult Delete(Car car)
        {
            
            _carDal.Delete(car);
            return new SuccessDataResult<Car>(Messages.CarDeleted);
        }

       

        public IDataResult<Car> GetById(int carId)
        {

            _carDal.Get(p => p.CarId == carId);
           return new SuccessDataResult<Car>(Messages.CarsListed);
            
        }

        public IDataResult<Car> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.BrandId == id),Messages.CarsListed);
        }

        public IDataResult<Car> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.ColorId == id), Messages.CarsListed);
        }
    }
}
