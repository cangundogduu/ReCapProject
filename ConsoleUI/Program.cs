using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());


            /*var result = carManager.GetCarDetails();
            if (result.Success)
            {
                 foreach (var car in result.Data)
                            {
                                Console.WriteLine(car.CarName+" / "+car.BrandName);
                            }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

           */
            foreach (var cars in carManager.GetAll().Data)
            {
                Console.WriteLine(cars.CarName);
            }
            
            Console.ReadLine();
        }
    }
}
