using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.Win32.SafeHandles;

namespace DataAccess.Concrete.Inmemory
{
    public class InMemoryCarDal:ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId =1, ColorId=1, BrandId=1, DailyPrice =70000, ModelYear =1996, Descriptions= "Benzinli"},
                new Car{CarId =2, ColorId=1, BrandId=1, DailyPrice =85000, ModelYear =2000, Descriptions="Benzinli"},
                new Car{CarId =3, ColorId=4, BrandId=2, DailyPrice =780000, ModelYear =2002, Descriptions="Dizel"},
                new Car{CarId =4, ColorId=2, BrandId=2, DailyPrice =650000, ModelYear =2010, Descriptions="Benzinli"},
                new Car{CarId =5, ColorId=3, BrandId=1, DailyPrice =170000, ModelYear =2020, Descriptions="Elektrikli"},
            };
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.CarId == Id).ToList();
        }


        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car carOfDelete;
            carOfDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carOfDelete);
        }

        public void Delete(Car car)
        {
            Car carOfUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carOfUpdate.BrandId = car.BrandId;
            carOfUpdate.ColorId = car.ColorId;
            carOfUpdate.DailyPrice = car.DailyPrice;
            carOfUpdate.Descriptions = car.Descriptions;
            carOfUpdate.ModelYear = car.ModelYear;
        }

        public List<CarDetailDto> getCarDetail()
        {
            throw new NotImplementedException();
        }
    }
}
