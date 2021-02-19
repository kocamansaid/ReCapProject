using System;
using System.Threading.Channels;
using Business.Concrete;
using DataAccess.Concrete.Entityframework;
using DataAccess.Concrete.Inmemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental
            { CarId = 2, CustomerId = 3,RentDate = new DateTime(2021,02, 19), ReturnDate = new DateTime(2021, 2, 21) };
            
            Console.WriteLine(rentalManager.Add(rental).Message);


            //customerMethod();
            //carMethod();

            //brandMethod();

            //colorMethod();
        }

        private static void customerMethod()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetAll();
            Console.WriteLine(result.Message);
            foreach (var color in customerManager.GetAll().Data)
            {
                Console.WriteLine(color.CompanyName);
            }
        }

        private static void colorMethod()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }

            Console.WriteLine("-------------");
            Console.WriteLine(colorManager.GetById(3).Data.ColorName);
        }

        private static void brandMethod()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName + "-");
            }

            Console.WriteLine("-------------");
            Console.WriteLine(brandManager.GetById(3).Data.BrandName);
        }

        private static void carMethod()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.getCarDetails().Data)
            {
                Console.WriteLine("  "+car.Descriptions+ "  " + car.ColorName);
            }

            Console.WriteLine("Hello World!");
            Console.WriteLine("-------------");
            
        }
    }
}
