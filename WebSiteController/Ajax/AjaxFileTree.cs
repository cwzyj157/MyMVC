using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MyMVC;
using WebSiteModel;

namespace WebSiteController
{

	public static class AjaxFileTree
	{
		/// <summary>
		/// 不显示的文件夹名称
		/// </summary>
		private static readonly string[] s_IgnoreFolders = new string[] { "Bin", "Images", "jquery", "syntaxhighlighter", "obj", "Properties", "Resources" };

		/// <summary>
		/// 允许显示的文件扩展名
		/// </summary>
		private static readonly string[] s_AllowExts = new string[] { ".cs", ".aspx", ".ascx", ".ashx", ".master", ".config", ".css", ".js", ".asax", ".asmx", ".sql", ".txt", ".htm", ".html" };

		/// <summary>
		/// 遍历所有文件夹，获取文件夹和文件的树型节点
		/// </summary>
		/// <returns></returns>
		[Action]
		public static object GetWebSiteFileNodes(string root)
		{
			string rootPath = null;

			if( string.IsNullOrEmpty(root) == false ) {
				string configFile = HttpContextHelper.AppRootPath + "CodeExplorer.config";
				if( File.Exists(configFile) ) {
					Dictionary<string, string> settings
						= (from line in File.ReadAllLines(configFile)
						   where line.Trim().StartsWith(";", StringComparison.Ordinal) == false
						   let p = line.IndexOf('=')
						   where p > 0
						   select new KeyValuePair<string, string>(
							   line.Substring(0, p).Trim(),
							   line.Substring(p + 1).Trim()))
							.ToDictionary(x => x.Key, y => y.Value, StringComparer.OrdinalIgnoreCase);

					settings.TryGetValue(root, out rootPath);
				}
			}


			if( string.IsNullOrEmpty(rootPath) ) 
				// 显示整个解决方案下的所有文件。
				rootPath = HttpContextHelper.AppRootPath + "..\\";
			

			JsTreeNode rootNode = new JsTreeNode();
			RecursiveDirectory(rootPath, rootNode);

			return new JsonResult(rootNode.children);
		}

		private static void RecursiveDirectory(string fullPath, JsTreeNode root)
		{
			DirectoryInfo dir = new DirectoryInfo(fullPath);
			DirectoryInfo[] subDirArray = dir.GetDirectories();
			FileInfo[] fileArray = dir.GetFiles();

			List<JsTreeNode> children = new List<JsTreeNode>(subDirArray.Length + fileArray.Length);

			foreach( DirectoryInfo dinfo in subDirArray ) {
				if( Array.Find<string>(s_IgnoreFolders, x => string.Compare(x, dinfo.Name, true) == 0) != null )
					continue;

				JsTreeNode node = new JsTreeNode();
				node.text = dinfo.Name;
				node.attributes = new JsTreeNodeCustAttr();

				RecursiveDirectory(dinfo.FullName, node);

				if( node.children != null && node.children.Count > 0 ) {
					children.Add(node);
				}
			}


			Dictionary<string, JsTreeNode> nestNodes = new Dictionary<string, JsTreeNode>(fileArray.Length, StringComparer.OrdinalIgnoreCase);

			foreach( FileInfo finfo in fileArray ) {
				//if( Array.Find<string>(s_IgnoreFiles, 
				//        x => (string.Compare(x, finfo.Extension, true) == 0 ||string.Compare(x, finfo.Name, true) == 0) ) != null )
				//    continue;
				if( Array.Find<string>(s_AllowExts,	x => (string.Compare(x, finfo.Extension, true) == 0)) == null )
					continue;

				JsTreeNode node = new JsTreeNode();
				node.text = finfo.Name;
				node.iconCls = GetIconByFileName(finfo.Name);
				node.attributes = new JsTreeNodeCustAttr(finfo.FullName, finfo.Extension.ToLower());

				if( node.iconCls == "icon-cs2" )
					nestNodes.Add(finfo.Name, node);
				else
					children.Add(node);
			}

			foreach( JsTreeNode node in children ) {
				if( node.iconCls == "icon-aspx" || node.iconCls == "icon-ascx" || node.iconCls == "icon-master" ) {
					JsTreeNode nestNode;
					if( nestNodes.TryGetValue(string.Concat(node.text, ".cs"), out nestNode) ) {
						node.children = new List<JsTreeNode>(1);
						node.children.Add(nestNode);
					}
				}
			}

			foreach( JsTreeNode child in children )
				if( child.children != null && child.children.Count > 0 )
					child.state = "closed";

			if( children.Count > 0 )
				root.children = children;
		}

		private static string GetIconByFileName(string filename)
		{
			if( filename.EndsWith(".aspx.cs", StringComparison.OrdinalIgnoreCase) ||
				filename.EndsWith(".ascx.cs", StringComparison.OrdinalIgnoreCase) ||
				filename.EndsWith(".master.cs", StringComparison.OrdinalIgnoreCase) )
				return "icon-cs2";

			if( filename.EndsWith(".cs", StringComparison.OrdinalIgnoreCase) )
				return "icon-cs";

			if( filename.EndsWith(".aspx", StringComparison.OrdinalIgnoreCase) )
				return "icon-aspx";

			if( filename.EndsWith(".ascx", StringComparison.OrdinalIgnoreCase) )
				return "icon-ascx";

			if( filename.EndsWith(".ashx", StringComparison.OrdinalIgnoreCase) )
				return "icon-ashx";

			if( filename.EndsWith(".master", StringComparison.OrdinalIgnoreCase) )
				return "icon-master";

			if( filename.EndsWith(".config", StringComparison.OrdinalIgnoreCase) )
				return "icon-config";

			if( filename.EndsWith(".css", StringComparison.OrdinalIgnoreCase) )
				return "icon-css";

			if( filename.EndsWith(".js", StringComparison.OrdinalIgnoreCase) )
				return "icon-js";

			if( filename.EndsWith(".asax", StringComparison.OrdinalIgnoreCase) )
				return "icon-asax";

			if( filename.EndsWith(".skin", StringComparison.OrdinalIgnoreCase) )
				return "icon-skin";

			if( filename.EndsWith(".sql", StringComparison.OrdinalIgnoreCase) )
				return "icon-sql";

			return null;
		}

		/// <summary>
		/// 读取指定的文件，将文件内容返回给客户端JS
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		[Action]
		public static string GetFileText(string path)
		{
			return File.ReadAllText(path, Encoding.UTF8);
		}

	}
}
