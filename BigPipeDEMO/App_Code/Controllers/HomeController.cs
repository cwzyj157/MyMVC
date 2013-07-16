using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using MyMVC;

public class HomeController
{
	[Action]
	[PageUrl(Url = "/BigPipeDemo.aspx")]
	public static void ShowHomePage()
	{
		// 先输出页框架
		ResponseWriter.WritePage(null /* pageVirtualPath */, null /* model */, true /* flush */);


		BlogBLL bll = new BlogBLL();

		// 加载博客内容，第一个数据
		string blogFilePath = Path.Combine(HttpContextHelper.AppRootPath, "App_Data\\BlogBody.txt");
		ResponseWriter.WriteUserControl("~/UserControls/BlogBody.ascx", 
								bll.GetBlog(blogFilePath), "blog-body", true);

		// 加载左链接导航栏，第二个数据
		string linksFilePath = Path.Combine(HttpContextHelper.AppRootPath, "App_Data\\Links.txt");
		ResponseWriter.WriteUserControl("~/UserControls/TagLinks.ascx", 
								bll.GetLinks(linksFilePath),"right", true);

		// 加载评论，第三个数据
		string commentFilePath = Path.Combine(HttpContextHelper.AppRootPath, "App_Data\\Comments.txt");
		ResponseWriter.WriteUserControl("~/UserControls/CommentList.ascx", 
								bll.GetComments(commentFilePath),"blog-comments-placeholder", true);


		ResponseWriter.WriteUserControl("~/UserControls/PageEnd.ascx", null /* model */, true /* flush */);
	}
}
