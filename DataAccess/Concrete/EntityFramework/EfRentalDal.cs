using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental,CarProjectContext> , IEntityRepository<Rental>
    {
        public List<RentalDetailsDto> GetRentalDetails(Expression<Func<Rental,bool>> filter = null)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var result = from r in filter is null ? context.Rentals : context.Rentals.Where(filter)
                             join ca in context.Cars
                             on r.CarId equals ca.Id
                             join cu in context.Customers
                             on r.CustomerId equals cu.UserId
                             join u in context.Users
                             on cu.UserId equals u.Id
                             select new RentalDetailsDto
                             {
                                 Id = r.Id,
                                 CarId = ca.Id,
                                 CarName = ca.Description,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 UserName = u.FirstName + " " + u.LastName
                             };

                return result.ToList();
            }
        }
    }
}
