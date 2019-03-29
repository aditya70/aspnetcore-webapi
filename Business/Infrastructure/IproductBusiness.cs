using DataAccess.EntityModels;
using DataModels.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Infrastructure
{
   public interface IproductBusiness
    {
        Task<List<Products>> GetAllProduct();
    }
}
