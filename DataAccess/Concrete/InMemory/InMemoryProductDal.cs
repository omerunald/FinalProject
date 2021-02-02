using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
	public class InMemoryProductDal : IProductDal
	{
		List<Product> _products;

		public InMemoryProductDal()
		{
			_products = new List<Product>() {
				new Product(){ ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 26, UnitInStock = 15},
				new Product(){ ProductId = 2, CategoryId = 1, ProductName = "Kamera", UnitPrice = 500, UnitInStock = 3},
				new Product(){ ProductId = 3, CategoryId = 2, ProductName = "Telefon", UnitPrice = 1500, UnitInStock = 3},
				new Product(){ ProductId = 4, CategoryId = 2, ProductName = "Klavye", UnitPrice = 150, UnitInStock = 65},
				new Product(){ ProductId = 5, CategoryId = 2, ProductName = "Fare", UnitPrice = 85, UnitInStock = 1}



			};
		}
		public void Add(Product product)
		{
			_products.Add(product);
		}

		public void Delete(Product product)
		{
			//Product productdelete = null;

			//productdelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

			var productdelete = _products.Where(i => i.ProductId == product.ProductId).FirstOrDefault();
			_products.Remove(productdelete);
		}

		public List<Product> GetAll()
		{
			return _products;

		}

		public List<Product> GetAllByCategories(int CatId)
		{
			var list = _products.Where(i => i.CategoryId == CatId).ToList();
			return list;
		}

		public void Update(Product product)
		{
			var productToUpdate = _products.Where(i => i.ProductId == product.ProductId).FirstOrDefault();
			product.ProductName = productToUpdate.ProductName;
			product.CategoryId = productToUpdate.CategoryId;
			product.UnitPrice = product.UnitPrice;
			product.UnitInStock = productToUpdate.UnitInStock;
			
		}
	}
}
