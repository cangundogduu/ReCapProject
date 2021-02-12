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
        ICarDAl _carDal;
       

        public CarManager(ICarDAl carDal)
        {
            _carDal = carDal;
        }

        

        public IDataResult<List<Car>> GetAll()
        {
            return new DataResult<List<Car>>(_carDal.GetAll(),true,"Ürünler Listelendi.");
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=>p.BrandId==id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return  new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id),"Araçlar rengine göre listelendi.");
        }
        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice < min && p.DailyPrice > max),"Araçlar fiyat aralığına göre listelendi.");
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new DataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),true,"Araçlar detaylarına göre listelendi.");
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

            _carDal.GetAll(p => p.CarId == carId);
           return new SuccessDataResult<Car>("Araçlar Id'sine göre listelendi.");
            
        }

       
    }
}
