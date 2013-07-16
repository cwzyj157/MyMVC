using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MyMVC;
using WebSiteController;
using WebSiteModel;


namespace TestContextEnvironment
{
	class Program
	{
		static void Main(string[] args)
		{
			InitDB();

			Test_AjaxStyle_SetStyle();
			Test_AjaxCustomer_GetById();
			Test_TestEnvironment();

			Console.ReadLine();
		}

		static void InitDB()
		{
			string xmlPath = "..\\..\\DemoWebSite1\\App_Data\\MyNorthwindDataBase.xml";
			WebSiteDB.LoadDbFromXml(xmlPath);
		}

		static void Test_AjaxStyle_SetStyle()
		{
			AjaxStyle ajax = new AjaxStyle();
			ajax.SetStyle(StyleHelper.StyleArray[0]);

			if( CookieHelper.GetCookieValue(StyleHelper.STR_PageStyle) == StyleHelper.StyleArray[0] )
				Console.WriteLine("AjaxStyle.SetStyle(\"{0}\") OK", StyleHelper.StyleArray[0]);
			else
				Console.WriteLine("AjaxStyle.SetStyle(\"{0}\") faild.", StyleHelper.StyleArray[0]);

			CookieHelper.ClearCookie();

			ajax.SetStyle("abc");		// 一个无效的值。
			if( CookieHelper.GetCookieValue(StyleHelper.STR_PageStyle) == null  )
				Console.WriteLine("AjaxStyle.SetStyle(\"abc\") OK");
			else
				Console.WriteLine("AjaxStyle.SetStyle(\"abc\") faild.");
		}
		
		static void Test_AjaxCustomer_GetById()
		{
			AjaxCustomer ajax = new AjaxCustomer();
			object result = ajax.GetById(1);
			if( result is JsonResult )
				Console.WriteLine("AjaxCustomer.GetById(1) OK");
			else
				Console.WriteLine("AjaxCustomer.GetById(1) faild");
		}

		static void Test_TestEnvironment()
		{
			TestEnvironment.SetValue("key1", 123);
			TestEnvironment.SetValue("key2", "abc");

			if( (int)TestEnvironment.GetValue("key1") == 123 )
				Console.WriteLine("TestEnvironment.SetValue(123) OK.");

			if( (string)TestEnvironment.GetValue("key2") == "abc" )
				Console.WriteLine("TestEnvironment.SetValue(\"abc\") OK.");
		}




	}
}
