using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemory:ICarDal
    {
        List<Car> _Cars;
        public InMemory()
        {
             _Cars = new List<Car>
            {
                new Car{CarId=1,CarName="Mercedes",BrandId=1,ColorId=1,ModelYear=2010,DailyPrice=12500,Description="Otomatik- Full Paket"},
                 new Car{CarId=2,CarName="Audi",BrandId=1,ColorId=2,ModelYear=2015,DailyPrice=3000,Description="Manuel -Full Paket"},
                  new Car{CarId=3,CarName="Reanult",BrandId=1,ColorId=3,ModelYear=2009,DailyPrice=10000,Description="Benzinli- Manuel"},
                   new Car{CarId=4,CarName="Dacia",BrandId=2,ColorId=1,ModelYear=2020,DailyPrice=50000,Description="Otomatik- Full Paket"},
                    new Car{CarId=5,CarName="Volvo",BrandId=2,ColorId=2,ModelYear=2005,DailyPrice=8000,Description="Manuel- Dizel"},
            };
        }

        public void Add(Car car)
        {
            _Cars.Add(car);
        }

       
        public void Delete(Car car)
        {
            Car CarToDelete = _Cars.SingleOrDefault(p => p.CarId == car.CarId);
            _Cars.Remove(car);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _Cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllBrand(int BrandId)
        {
            return _Cars.Where(p => p.BrandId == BrandId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

       

        public void Update(Car car)
        {
            Car carToUpdate = _Cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

       
    }
}
