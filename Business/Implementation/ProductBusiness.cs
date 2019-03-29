using Business.Infrastructure;
using DataAccess.EntityModels;
using DataAccess.RepositoryBase;
using DataModels.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementation
{
    public class ProductBusiness : IproductBusiness
    {
       private IRepositoryBase<Products> _repositoryBase { get; set; }

        public ProductBusiness(IRepositoryBase<Products> repositoryBase)
        {
            this._repositoryBase = repositoryBase;
        }

        public async Task<List<Products>> GetAllProduct()
        {
            var productList = await _repositoryBase.FindAllAsync();
            return productList.ToList();
        
        }
    }
}
