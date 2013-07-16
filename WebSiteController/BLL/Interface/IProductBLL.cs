using System;
namespace WebSiteController
{
	public interface IProductBLL
	{
		void ChangeProductQuantity(int productId, int quantity);
		void Delete(int productId);
		WebSiteModel.Product GetProductById(int productId);
		void Insert(WebSiteModel.Product product);
		System.Collections.Generic.List<WebSiteModel.Product> SearchProduct(WebSiteModel.ProductSearchInfo info);
		void Update(WebSiteModel.Product product);
	}
}
