using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using MyMVC;


namespace WebSiteController
{
	public class AjaxTestAutoAction
	{
		[Action]
		public string Base64(string input)
		{
			return Convert.ToBase64String(Encoding.Default.GetBytes(input));
		}

		[Action]
		public string Md5(string input)
		{
			byte[] bb = Encoding.Default.GetBytes(input);
			byte[] md5 = (new MD5CryptoServiceProvider()).ComputeHash(bb);
			return BitConverter.ToString(md5).Replace("-", string.Empty);
		}


		[Action]
		public string Sha1(string input)
		{
			byte[] bb = Encoding.Default.GetBytes(input);
			byte[] sha1 = (new SHA1CryptoServiceProvider()).ComputeHash(bb);
			return BitConverter.ToString(sha1).Replace("-", string.Empty);
		}
	}
}
