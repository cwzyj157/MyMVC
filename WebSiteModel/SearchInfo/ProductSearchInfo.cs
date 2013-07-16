using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebSiteCommonLib;
using ClownFish;

namespace WebSiteModel
{
	public class ProductSearchInfo : PagingInfo
	{
		public string SearchWord;
		public int CategoryId;
	}
}
