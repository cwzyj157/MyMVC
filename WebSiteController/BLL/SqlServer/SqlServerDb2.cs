using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;
using ClownFish;
using WebSiteModel;


namespace WebSiteController
{
	public class SqlServerDb2 : IDatabase
	{
		public void AppStart()
		{
			Profiler.ApplicationName = "MyMVC DEMO - XmlCommand";
			DbHelper.DefaultCommandKind = CommandKind.XmlCommand;

			SqlServerDb.ConfigClownFish();

			string path = System.IO.Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\XmlCommand");
			XmlCommandManager.LoadCommnads(path);
		}

		public void AppEnd()
		{
		}

		


	}
}
