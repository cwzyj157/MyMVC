using System;
using MyMVC;
using WebSiteModel;
using WebSiteCommonLib;

namespace WebSiteController
{

	public class ProductController
	{
		[Action]
		[PageUrl(Url = "/mvc/Products")]
		[PageUrl(Url = "/mvc/Products.html")]
		[PageUrl(Url = "/mvc/ProductList.aspx")]
		[PageUrl(Url = "/Pages/Products.aspx")]
		public static object LoadModel(int? categoryId, int? page)
		{
			string papeUrl = StyleHelper.GetTargetPageUrl("Products.aspx");

			if( StyleHelper.PageStyle == StyleHelper.StyleArray[1] )
				// Style2 风格下，页面不需要绑定数据。数据由JS通过AJAX方式获取
				return new PageResult(papeUrl, null);


			ProductsPageModel result = new ProductsPageModel();
			result.Categories = BllFactory.GetCategoryBLL().GetList();

			if( result.Categories.Count == 0 ) {
				return new RedirectResult("/Pages/Categories.aspx");
			}

			// 获取当前用户选择的商品分类ID
			ProductSearchInfo info = new ProductSearchInfo();
			info.CategoryId = categoryId.HasValue ? categoryId.Value : 0;
			if( info.CategoryId == 0 )
				info.CategoryId = result.Categories[0].CategoryID;
			info.PageIndex = page.HasValue ? page.Value - 1 : 0;
			info.PageSize = AppHelper.DefaultPageSize;


			result.ProductInfo = new ProductInfoModel(
						result.Categories, new Product { CategoryID = info.CategoryId });
			result.PagingInfo = info;
			result.CurrentCategoryId = info.CategoryId;


			// 加载商品列表
			result.Products = BllFactory.GetProductBLL().SearchProduct(info);

			return new PageResult(papeUrl, result);
		}


	}
}
