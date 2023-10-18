using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.Northwind.DataAcesss.Abstract;
using DevFramework.Northwind.Entities.ComplexTypes;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAcesss.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetail> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {

                var result = from Product in context.Products
                             join Category in context.Categories
                             on Product.CategoryId
                             equals Category.CategoryID
                             select new ProductDetail
                             {
                                 ProductID = Product.ProductID,
                                 ProductName = Product.ProductName,
                                 CategoryName = Category.CategoryName
                             };
                return result.ToList();
            }           
        }
    }
}
