using System;
namespace WebSiteController
{
	public interface ICategoryBLL
	{
		void Delete(int categoryId);
		System.Collections.Generic.List<WebSiteModel.Category> GetList();
		void Insert(WebSiteModel.Category category);
		void Update(WebSiteModel.Category category);
	}
}
