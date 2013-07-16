using System;
using System.Collections.Generic;
using System.Web;

namespace WebSiteCommonLib
{
	/// <summary>
	/// 一些扩展方法
	/// </summary>
	public static class MyExtension
	{
		public static string ToText(this int num)
		{
			if( num == 0 )
				return string.Empty;
			else
				return num.ToString();
		}

		public static string ToText(this decimal num)
		{
			if( num == 0M )
				return string.Empty;
			else
				return num.ToString("F2");
		}

		/// <summary>
		/// <para>拆分一个字符串行。如：a=1;b=2;c=3;d=4;</para>
		/// <para>此时可以调用: SplitString("a=1;b=2;c=3;d=4;", ';', '=');</para>
		/// <para>说明：对于空字符串，方法也会返回一个空的列表。</para>
		/// </summary>
		/// <param name="line">包含所有项目组成的字符串行</param>
		/// <param name="separator1">每个项目之间的分隔符</param>
		/// <param name="separator2">每个项目内的分隔符</param>
		/// <returns>拆分后的结果列表</returns>
		public static List<KeyValuePair<string, string>> SplitString(this string line, char separator1, char separator2)
		{
			if( string.IsNullOrEmpty(line) )
				return new List<KeyValuePair<string, string>>();

			string[] itemArray = line.Split(new char[] { separator1 }, StringSplitOptions.RemoveEmptyEntries);
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>(itemArray.Length);

			char[] separator2Array = new char[] { separator2 };

			foreach( string item in itemArray ) {
				string[] parts = item.Split(separator2Array, StringSplitOptions.RemoveEmptyEntries);
				if( parts.Length != 2 )
					throw new ArgumentException("要拆分的字符串的格式无效。");

				list.Add(new KeyValuePair<string, string>(parts[0], parts[1]));
			}
			return list;
		}


	}
}