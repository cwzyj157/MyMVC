using System;

namespace WebSiteCommonLib
{
	[Serializable]
	public class MyMessageException : Exception
	{
		// Methods
		public MyMessageException(string message)
			: base(message)
		{
		}

	}
}