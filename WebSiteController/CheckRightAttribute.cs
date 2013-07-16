using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using MyMVC;

namespace WebSiteController
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
	public class CheckRightAttribute : AuthorizeAttribute
	{
		public string RightNo { get; set; }

		public override bool AuthenticateRequest(HttpContext context)
		{
			if( context.Request.IsAuthenticated == false )
				return false;

			// 假设权限编号放在用户名后面。
			int p = context.User.Identity.Name.IndexOf(',');
			if( p > 0 ) {
				string currentUserRight = context.User.Identity.Name.Substring(p + 1);
				return (RightNo == currentUserRight);
			}

			return false;
		}
	}
}
