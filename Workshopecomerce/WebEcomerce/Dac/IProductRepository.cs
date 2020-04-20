using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebEcomerce.Models;

namespace Demoecomerce.Reponsitories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProduct();
        Product Get(Expression<Func<Product, bool>> expression);
        void Create(Product document);
        void Update(Product documant);
        void Delete(Product document);
    }
}
