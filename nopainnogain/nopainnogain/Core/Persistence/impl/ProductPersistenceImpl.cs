using Core.Productadministration;
using System.Collections.Generic;
using System.Linq;

namespace Core.Persistence.impl
{
	public class ProductPersistenceImpl : IProductPersistence
    {
        public Product CreateProduct(Product product)
        {
            using (CALContext db = new CALContext())
            {
                db.ProductsDB.Add(product);
                db.SaveChanges();
                return product;
            }

        }

        public void DeleteProduct(int id)
        {
            using (CALContext db = new CALContext())
            {
                Product productdelete = db.ProductsDB.Find(id);
                if (productdelete == null)
                    return;

                db.ProductsDB.Remove(productdelete);
                db.SaveChanges();
            }
        }

        public Product GetProduct(int id)
        {
            using (CALContext db = new CALContext())
            {
                Product product = db.ProductsDB.Find(id);
                if (product == null)
                    throw new KeyNotFoundException();
                
                return product;
            }
        }

        public List<Product> GetAllProducts()
        {
            using (CALContext db = new CALContext())
            {
                return db.ProductsDB.ToList();
            }
        }

        public bool UpdateProduct(int id, Product product)
        {
            using (CALContext db = new CALContext())
            {
                Product p = db.ProductsDB.Find(id);
                if (p == null)
                    return false;
                p.Name = product.Name;
                p.Kcal = product.Kcal;
                p.Protein = product.Protein;
                p.Carbs = product.Carbs;
                p.Fat = product.Fat;
                p.Amount = product.Amount;
                db.SaveChanges();

                p = db.ProductsDB.Find(id);
                return p.Equals(product);
            }

        }

        public void DeleteAllProducts()
        {
            using (CALContext db = new CALContext())
            {
                foreach (Product u in db.ProductsDB.ToList())
                {
                    db.ProductsDB.Remove(u);
                }
                db.SaveChanges();
            }
        }
    }
}




