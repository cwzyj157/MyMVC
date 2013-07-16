using System;
using MyMVC;
using WebSiteModel;
using WebSiteCommonLib;

namespace WebSiteController
{

	public class CustomerController
	{
		[Action]
		[PageUrl(Url = "/mvc/Customers")]
		[PageUrl(Url = "/mvc/Customers.html")]
		[PageUrl(Url = "/mvc/test/Customers.html")]
		[PageUrl(Url = "/mvc/test/aa/bb/cc/Customers.html")]
		[PageUrl(Url = "/mvc/CustomerList.aspx")]
		[PageUrl(Url = "/Pages/Customers.aspx")]
		public static object LoadModel(int? page)
		{
			// 说明：参数page表示分页数，方法名LoadModel其实可以【随便取】。

			// 根据用户选择的界面风格，计算实现要呈现的页面路径。
			string papeUrl = StyleHelper.GetTargetPageUrl("Customers.aspx");

			if( StyleHelper.PageStyle == StyleHelper.StyleArray[1] )
				// Style2 风格下，页面不需要绑定数据。数据由JS通过AJAX方式获取
				return new PageResult(papeUrl, null);


			// 为Style1 风格获取数据。
			CustomerSearchInfo info = new CustomerSearchInfo();
			info.SearchWord = string.Empty;
			info.PageIndex = page.HasValue ? page.Value - 1 : 0;
			info.PageSize = AppHelper.DefaultPageSize;

			CustomersPageModel result = new CustomersPageModel();
			result.PagingInfo = info;
			result.List = BllFactory.GetCustomerBLL().GetList(info);

			return new PageResult(papeUrl, result);
		}
	}
}
