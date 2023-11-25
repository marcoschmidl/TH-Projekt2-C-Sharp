using Core.Persistence;
using Core.Persistence.impl;
using System.Collections.Generic;

namespace Core.Productadministration.impl
{
    public class ProductAdministrationImpl : IProductAdministration
    {
        private static IProductPersistence productPersistence = new ProductPersistenceImpl();
        
        public Product CreateProduct(Product product)
        {
            return productPersistence.CreateProduct(product);
        }

        public void DeleteProduct(int id)
        {
            productPersistence.DeleteProduct(id);
        }

        public ICollection<Product> GetAllProduct()
        {
            return productPersistence.GetAllProducts();
        }

        public Product GetProduct(int id)
        {
            return productPersistence.GetProduct(id);
        }

        public bool UpdateProduct(int id, Product product)
        {
           return productPersistence.UpdateProduct(id, product);
        }
    }
}
