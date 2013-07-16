<%@ Page Title="客户管理" Language="C#" MasterPageFile="MasterPage.master" 
		Inherits="MyPageView<CustomersPageModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<%= UiHelper.RefJsFileHtml("/js/MyPage/Customers.js")%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<p><a id="btnCreateItem" href="#" class="easyui-linkbutton" iconCls="icon-add">创建客户</a></p>

<table class="GridView" cellspacing="0" cellpadding="4" border="0" style="border-collapse:collapse;">
    <tr align="left">
		<th style="width:20px;">&nbsp;</th>
		<th style="width:260px;">客户名称</th>
		<th style="width:80px;">联系人</th>
		<th>地址</th>
		<th style="width:80px;">邮编</th>
		<th style="width:160px;">电话</th>
	</tr>
<% foreach( Customer customer in Model.List ) { %>
    <tr>
		<td><a href="/AjaxCustomer/Delete.cspx?id=<%= customer.CustomerID %>&returnUrl=<%= RequestUrlEncodeRawUrl %>" 
					title="删除" class="easyui-linkbutton" plain="true">
			<img src="/Images/delete.gif" alt="删除" /></a>				
        </td>
        <td><a href="#" class="easyui-linkbutton" rowId="<%= customer.CustomerID %>" plain="true" iconCls="icon-open">
				<%= customer.CustomerName.HtmlEncode()%></a>
        </td>
        <td><span name="ContactName"><%= customer.ContactName.HtmlEncode() %></span>
        </td>
        <td><span name="Address"><%= customer.Address.HtmlEncode() %></span>
        </td>
        <td><span name="PostalCode"><%= customer.PostalCode.HtmlEncode() %></span>
        </td>
        <td><span name="Tel"><%= customer.Tel.HtmlEncode() %></span>
        </td>
    </tr>
<% } %>

<%= Model.PagingInfo.PaginationBar(6)%>
</table>

<div id="divCustomerInfo" title="客户" style="padding: 8px; display: none">
<%= UcExecutor.Render("/Controls/Style1/CustomerInfo.ascx", Model.Customer)%>
</div>

</asp:Content>

