using System;
using MyMVC;
using WebSiteModel;


namespace WebSiteController
{

	public class CategoryController
	{
		[Action]
		[PageUrl(Url = "/Pages/Categories.aspx")]
		public object LoadModel()
		{
			// 根据用户选择的界面风格，计算实现要呈现的页面路径。
			string papeUrl = StyleHelper.GetTargetPageUrl("Categories.aspx");

			if( StyleHelper.PageStyle == StyleHelper.StyleArray[1] )
				// Style2 风格下，页面不需要绑定数据。数据由JS通过AJAX方式获取
				return new PageResult(papeUrl, null);

			// 为Style1 风格获取数据。
			CategoriesPageModel result = new CategoriesPageModel();
			result.List = BllFactory.GetCategoryBLL().GetList();

			return new PageResult(papeUrl, result);
		}

	}
}
