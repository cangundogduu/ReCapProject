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
            {
                CarTest();
                BrandTest();
                UserAdd();
                CustomerAdd();
                RentalAdd();

            }

             void RentalAdd()
            {
                RentalManager rentalManager = new RentalManager(new EfRentalDal());
                var result = rentalManager.Add(new Rental { CarId = 1, CustomerId = 1, RentTime = DateTime.Now, Id = 1 });
                Console.WriteLine(result.Message);
            }

            void CustomerAdd()
            {
                CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
                var result = customerManager.Add(new Customer { UserId = 2, CompanyName = "Renault" });
                Console.WriteLine(result.Message);
            }

            void UserAdd()
            {
                UserManager userManager = new UserManager(new EfUserDal());
                var result = userManager.Add(new User { FirstName = "Can", LastName = "Gündoğdu", Email = "gundogdu.can@hotmail.com", Password = "cc11" });
                Console.WriteLine(result.Message);
            }

             void BrandTest()
            {
                BrandManager brandManager = new BrandManager(new EfBrandDal());
                var result = brandManager.GetAll();
                if (result.Success == true)
                {
                    foreach (var brand in result.Data)
                    {
                        Console.WriteLine(brand.BrandName);
                    }
                    Console.WriteLine(result.Message);
                }
                else
                {
                    Console.WriteLine(result.Message);
                }

            }

             void CarTest()
            {
                CarManager carManager = new CarManager(new EfCarDal());
                var result = carManager.GetCarDetails();
                if (result.Success == true)
                {
                    foreach (var car in result.Data)
                    {
                        Console.WriteLine(car.CarName + ":" + car.BrandName + ":" + car.ColorName );

                    }
                    Console.WriteLine(result.Message);
                }
                else
                {
                    Console.WriteLine(result.Message);

                }

                Console.ReadLine();
        }
    }
}
