using DevFramework.Core.CrossCuttingCorners.Validation.FluentValidation;
using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.DataAcesss.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using DevFramework.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.CrossCuttingCorners.Caching.Microsoft;
using DevFramework.Core.Aspects.Postsharp;
using DevFramework.Core.Aspects.Postsharp.CacheAspects;
using DevFramework.Core.Aspects.Postsharp.TransactionAspects;
using DevFramework.Core.CrossCuttingCorners.Logging.Log4Net.Loggers;
using DevFramework.Core.Aspects.Postsharp.LogAspects;
//using System.Transactions;
//using DevFramework.Aspects.Postsharp;

namespace DevFramework.Northwind.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private IQueryableRepository<Product> _queryable;
        public ProductManager(IProductDal productDal,IQueryableRepository<Product> queryable)
        {
            _productDal = productDal;
        }
        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product product)
        {           
            return _productDal.Add(product);
        }
        [FluentValidationAspect(typeof(ProductValidator))]
       // postsharp manageNuGet packages'den business ve businesstest'e de eklenir.
       // postharp 4.2.17 kurulması gerekir.versiyonunu kontrol et.vs'nin bagı

        [CacheAspect(typeof(MemoryCacheManager), 120)]
        [LogAspect(typeof(DatabaseLogger))]
        public List<Product> GetAll()
        {
            return _productDal.GetList(null);
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductID == id);
        }
        [TransactionScopeAspect]
        public void TransactionalOperation(Product product1,Product product2)
        {          
              _productDal.Add(product1);
              //business codes
             _productDal.Update(product2);                    
        }
        
        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }
    }
}
