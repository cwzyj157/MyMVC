using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyMVC;

// AjaxServiceHandlerFactory演示了如何实现自定义的Action命名规则。
// 所有的Action以Ajax开头，
// 响应的URL格式：/Ajax/namespace1.Product/GetById.aspx?id=53
//           或者：/Ajax/Product/GetById.aspx?id=53

public class AjaxServiceHandlerFactory : MyMVC.ServiceHandlerFactory
{
	/// <summary>
	/// 当MyMVC初始化时，判断指定的类型是否为要加载的服务类型，返回TRUE表示要加载
	/// </summary>
	/// <param name="type"></param>
	/// <returns></returns>
	public override bool TypeIsService(Type type)
	{
		return type.Name.StartsWith("Ajax");
	}

	/// <summary>
	/// 根据URL的解析结果，获取Controller的名称。
	/// 例如：/Ajax/namespace1.Product/GetById.aspx?id=53
	/// </summary>
	/// <param name="serviceType">服务类型：Ajax</param>
	/// <param name="nspace">命名空间：namespace1</param>
	/// <param name="className">类型名称：Product</param>
	/// <param name="extname">扩展名：aspx</param>
	/// <returns></returns>
	public override string GetControllerName(string serviceType, string nspace, string className, string extname)
	{
		return nspace
				+ (nspace.Length > 0 ? "." : string.Empty)
				+ "Ajax" + className;

		// 返回结果：namespace1.AjaxProduct
	}

}
