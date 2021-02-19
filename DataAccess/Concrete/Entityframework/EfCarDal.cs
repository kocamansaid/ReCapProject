using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace DataAccess.Concrete.Entityframework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectdbcontext>, ICarDal
    {
        public List<CarDetailDto> getCarDetail()
        {
            using (ReCapProjectdbcontext context= new ReCapProjectdbcontext())
            {
                var result = from c in context.Cars
                        join b in context.Brands
                        on c.BrandId equals b.BrandId
                        
                        join co in context.Colors
                        on c.ColorId equals co.ColorId
                   
                    
                    
                    
                    select new CarDetailDto
                    {
                        BrandId = c.BrandId, BrandName = b.BrandName,
                        CarId = c.CarId, Descriptions = c.Descriptions, ColorName = co.ColorName,
                        
                    };
                return result.ToList();

            }
        }
    }
}
