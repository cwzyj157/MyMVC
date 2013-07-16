using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using MyMVC;


namespace WebSiteController
{
	public class AjaxStyle
	{
		[Action]
		public void SetStyle(string style)
		{
			if( Array.IndexOf(StyleHelper.StyleArray, style) >= 0 ) {
				HttpCookie cookie = new HttpCookie(StyleHelper.STR_PageStyle, style);
				cookie.Expires = DateTime.Now.AddYears(1);
				CookieHelper.AddCookie(cookie);
			}
		}
	}
}
