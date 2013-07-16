using System;
using MyMVC;
using WebSiteModel;
using WebSiteCommonLib;
using System.Collections.Generic;

namespace WebSiteController
{

	public class AjaxCustomer
	{
		[Action]
		public void Insert(Customer customer)
		{
			customer.EnsureItemIsOK();

			BllFactory.GetCustomerBLL().Insert(customer);
		}

		[Action]
		public object Delete(int id, string returnUrl)
		{
			BllFactory.GetCustomerBLL().Delete(id);

			if( string.IsNullOrEmpty(returnUrl) )
				return null;
			else
				return new RedirectResult(returnUrl);
		}

		[Action]
		public void Update(Customer customer)
		{
			customer.EnsureItemIsOK();

			BllFactory.GetCustomerBLL().Update(customer);
		}

		[Action]
		public object GetById(int id)
		{
			Customer customer = BllFactory.GetCustomerBLL().GetById(id);
			if( customer == null )
				throw new MyMessageException("指定的ID值无效。不能找到对应的记录。");

			return new JsonResult(customer);
		}

		[Action]
		public object Show(int id)
		{
			Customer customer = BllFactory.GetCustomerBLL().GetById(id);
			if( customer == null )
				throw new MyMessageException("指定的ID值无效。不能找到对应的记录。");

			return new UcResult("/Controls/Style1/CustomerInfo.ascx", customer);
		}

		[Action]
		public object ShowCustomerPicker(string searchWord, int? page)
		{
			CustomerSearchInfo info = new CustomerSearchInfo();
			info.SearchWord = searchWord ?? string.Empty;
			info.PageIndex = page.HasValue ? page.Value - 1 : 0;
			info.PageSize = AppHelper.DefaultPageSize;


			CustomerPickerModel data = new CustomerPickerModel();
			data.SearchInfo = info;
			data.List = BllFactory.GetCustomerBLL().GetList(info);

			return new UcResult("/Controls/Style1/CustomerPicker.ascx", data);
		}

		[Action]
		public object List(CustomerSearchInfo pagingInfo)
		{
			pagingInfo.CheckPagingInfoState();

			List<Customer> List = BllFactory.GetCustomerBLL().GetList(pagingInfo);
			var result = new GridResult<Customer>(List, pagingInfo.TotalRecords);
			return new JsonResult(result);
		}

	}
}
