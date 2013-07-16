using System;
using MyMVC;
using WebSiteModel;
using System.Collections.Generic;

namespace WebSiteController
{

	public class AjaxCategory
	{
		[Action]
		public void Insert(Category category)
		{
			category.EnsureItemIsOK();

			BllFactory.GetCategoryBLL().Insert(category);
		}

		[Action]
		public object Delete(int id)
		{
			BllFactory.GetCategoryBLL().Delete(id);

			return new RedirectResult("/Pages/Categories.aspx");
		}

		[Action]
		public void Update(Category category)
		{
			category.EnsureItemIsOK();

			BllFactory.GetCategoryBLL().Update(category);
		}
		[Action]
		public object List()
		{
			List<Category> List = BllFactory.GetCategoryBLL().GetList();
			var result = new GridResult<Category>(List);
			return new JsonResult(result);
		}

		[Action]
		public object GetList()
		{
			List<Category> List = BllFactory.GetCategoryBLL().GetList();
			return new JsonResult(List);
		}

	}

}