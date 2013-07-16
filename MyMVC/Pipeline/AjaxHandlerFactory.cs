using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;

namespace MyMVC
{
	public sealed class AjaxHandlerFactory : BaseActionHandlerFactory
	{
		private static readonly Regex s_urlRegex
			= new Regex(@"/(?<name>(\w[\./\w]*)?(?=Ajax)\w+)[/\.](?<method>\w+)\.[a-zA-Z]+", RegexOptions.Compiled);

		/*
			可以解析以下格式的URL：（前三个表示包含命名空间的格式）
		    注意：类名必须Ajax做为前缀

			/Fish.AA.AjaxTest/Add.cspx
			/Fish.BB.AjaxTest.Add.cspx
			/Fish/BB/AjaxTest/Add.cspx
			/AjaxDemo/GetMd5.cspx
			/AjaxDemo.GetMd5.cspx
		*/

		public override ControllerActionPair ParseUrl(HttpContext context, string path)
		{
			if( string.IsNullOrEmpty(path) )
				throw new ArgumentNullException("path");

			Match match = s_urlRegex.Match(path);
			if( match.Success == false )
				return null;

			return new ControllerActionPair {
				Controller = match.Groups["name"].Value.Replace("/", "."),
				Action = match.Groups["method"].Value
			};
		}


		public override bool TypeIsService(Type type)
		{
			return type.Name.StartsWith("Ajax");
		}
	}

}
