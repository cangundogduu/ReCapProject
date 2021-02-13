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
            //CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

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
            
            
                Console.WriteLine(colorManager.GetAll().Data);
            
            
            Console.ReadLine();
        }
    }
}
