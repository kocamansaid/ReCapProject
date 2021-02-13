using System;
using Business.Concrete;
using DataAccess.Concrete.Entityframework;
using DataAccess.Concrete.Inmemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByColorId(3))
            {
                Console.WriteLine(car.DailyPrice);
            }
            Console.WriteLine("Hello World!");
        }
    }
}
