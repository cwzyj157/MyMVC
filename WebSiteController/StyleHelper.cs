using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyMVC;

namespace WebSiteController
{
	public static class StyleHelper
	{
		public static readonly string STR_PageStyle = "PageStyle";
		public static readonly string[] StyleArray = new string[] { "Style1", "Style2", "Style3" };


		public static string PageStyle
		{
			get { return CookieHelper.GetCookieValue(STR_PageStyle) ?? StyleArray[1]; }
		}

		public static string GetTargetPageUrl(string pageName)
		{
			return string.Format("/Pages/{0}/" + pageName, PageStyle);
		}

	}
}
