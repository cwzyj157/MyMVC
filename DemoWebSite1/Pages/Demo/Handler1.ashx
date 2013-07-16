<%@ WebHandler Language="C#" Class="Handler1" %>
using System;
using System.Web;

public class Handler1 : IHttpHandler {

	public void ProcessRequest(HttpContext context)
	{
		// 【1】. 从context.Request中读取输入参数
		string param1 = context.Request.QueryString["param1"];
		string param2 = context.Request.QueryString["param2"];
		
		// 【2】. 根据上面所获取的参数，调用服务层或者BLL层获取结果
		// var result = CallXxxxMethod(param1, param2);

		// 【3】. 将结果写入context.Response
        context.Response.ContentType = "text/plain";
		context.Response.Write(" result ...... ");
    }

	public bool IsReusable { get { return false; } }
}