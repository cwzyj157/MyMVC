using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebSiteController
{
	public interface IDatabase
	{
		void AppStart();

		void AppEnd();
	}
}
