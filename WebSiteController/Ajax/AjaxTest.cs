using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using MyMVC;
using System.Collections.Specialized;

namespace WebSiteController
{
	public class AjaxDemo
	{
		[Action]
		public string GetMd5(string input)
		{
			if( input == null )
				input = string.Empty;

			byte[] bb = (new MD5CryptoServiceProvider()).ComputeHash(Encoding.Default.GetBytes(input));
			return BitConverter.ToString(bb).Replace("-", "").ToLower();
		}

		[Action]
		public string TestNameValueCollection(NameValueCollection queryString, NameValueCollection form, 
			NameValueCollection headers, NameValueCollection serverVariables)
		{
			StringBuilder sb = new StringBuilder();

			foreach( string key in queryString.AllKeys )
				sb.AppendFormat("queryString, {0} = {1}\r\n", key, queryString[key]);
			foreach( string key in form.AllKeys )
				sb.AppendFormat("form, {0} = {1}\r\n", key, form[key]);
			foreach( string key in headers.AllKeys )
				sb.AppendFormat("headers, {0} = {1}\r\n", key, headers[key]);
			foreach( string key in serverVariables.AllKeys )
				sb.AppendFormat("serverVariables, {0} = {1}\r\n", key, serverVariables[key]);
			return sb.ToString();
		}


		[OutputCache(Duration=10, VaryByParam="none")]
		[Action]
		public string TestOutputCache()
		{
			return DateTime.Now.ToString();
		}


		[SessionMode(SessionMode.Support)]
		[Action]
		public int TestSessionMode(int a)
		{
			// 一个累加的方法，检验是否可以访问Session
			// 警告：示例代码的这样做法会影响Action的单元测试。

			if( System.Web.HttpContext.Current.Session == null )
				throw new InvalidOperationException("Session没有开启。");

			object obj = System.Web.HttpContext.Current.Session["counter"];
			int counter = (obj == null ? 0 : (int)obj);
			counter += a;
			System.Web.HttpContext.Current.Session["counter"] = counter;
			return counter;
		}

		[Action]
		public string TestGuid(Guid guid)
		{
			return guid.ToString("N");
		}


		[Action]
		public string TestEnum(DayOfWeek week)
		{
			return week.ToString();
		}
	}


	



}



namespace aaaaaaaaaaaaaaa
{
	public class Customer
	{
		public string Name;
		public string Tel;
	}
	public class Salesman
	{
		public string Name { get; set; }
		public string Tel { get; set; }
	}


	public class AjaxDemo2
	{
		[Action]
		public string TestCustomerType(Customer customer, Salesman salesman)
		{
			return "customer.Name = " + customer.Name + "\r\n" +
				"customer.Tel = " + customer.Tel + "\r\n" +
				"salesman.Name = " + salesman.Name + "\r\n" +
				"salesman.Name = " + salesman.Tel;
		}
	}
}





namespace Fish.AA
{
	public class AjaxTest
	{
		[Action]
		public int Add(int a, int b)
		{
			return a + b;
		}
	}
}

namespace Fish.BB
{
	public class AddInfo
	{
		public int A;
		public int B;
	}

	public class AjaxTest
	{
		[Action]
		public int Add(AddInfo info)
		{
			return info.A + info.B + 10;	// 故意写错。
		}
	}
}