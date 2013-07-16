using System;
namespace WebSiteController
{
	public interface IOrderBLL
	{
		int AddOrder(WebSiteModel.Order order);
		WebSiteModel.Order GetOrderById(int orderId);
		System.Collections.Generic.List<WebSiteModel.Order> Search(WebSiteModel.OrderSearchInfo option);
		void SetOrderStatus(int orderId, bool finished);
	}
}
