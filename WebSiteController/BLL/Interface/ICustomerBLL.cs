using System;
namespace WebSiteController
{
	public interface ICustomerBLL
	{
		void Delete(int customerId);
		WebSiteModel.Customer GetById(int customerId);
		System.Collections.Generic.List<WebSiteModel.Customer> GetList(WebSiteModel.CustomerSearchInfo info);
		void Insert(WebSiteModel.Customer customer);
		void Update(WebSiteModel.Customer customer);
	}
}
