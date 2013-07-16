using System;
using MyMVC;
using WebSiteCommonLib;
using WebSiteModel;
using System.Collections.Generic;


namespace WebSiteController
{

	public class AjaxOrder
	{
		[Action]
		public void AddOrder(OrderSubmitForm form)
		{
			Order order = form.ConvertToOrderItem();
			BllFactory.GetOrderBLL().AddOrder(order);
		}

		[Action]
		public object Search(OrderSearchInfo info, int? page)
		{
			info.PageIndex = page.HasValue ? page.Value - 1 : 0;
			info.PageSize = AppHelper.DefaultPageSize;

			OrderListModel data = new OrderListModel();
			// 搜索数据库
			data.List = BllFactory.GetOrderBLL().Search(info);
			data.SearchInfo = info;

			return new UcResult("/Controls/Style1/OrderList.ascx", data);
		}

		[Action]
		public object Search2(OrderSearchInfo info)
		{
			info.CheckPagingInfoState();

			List<Order> list = BllFactory.GetOrderBLL().Search(info);

			var result = new GridResult<Order>(list, info.TotalRecords);

			return new JsonResult(result);
		}


		[Action]
		public void SetOrderStatus(int id, bool finished)
		{
			if( id <= 0 )
				throw new MyMessageException("没有指定OrderId");

			BllFactory.GetOrderBLL().SetOrderStatus(id, finished);
		}

		[Action]
		public object Show(int id)
		{
			if( id <= 0 )
				throw new MyMessageException("没有指定OrderId");

			Order item = BllFactory.GetOrderBLL().GetOrderById(id);
			if( item == null )
				throw new MyMessageException("指定的ID值无效。不能找到对应的记录。");

			return new UcResult("/Controls/Style1/OrderInfo.ascx", item);
		}

		[Action]
		public object GetById(int id)
		{
			Order item = BllFactory.GetOrderBLL().GetOrderById(id);
			if( item == null )
				throw new MyMessageException("指定的ID值无效。不能找到对应的记录。");

			return new JsonResult(item);
		}
	}
}
