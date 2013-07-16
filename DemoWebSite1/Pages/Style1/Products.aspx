<%@ Page Title="商品管理" Language="C#" MasterPageFile="MasterPage.master" 
			Inherits="MyPageView<ProductsPageModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<%= UiHelper.RefJsFileHtml("/js/MyPage/Products.js")%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table cellpadding="4" border="0">
<tr><td>当前分类</td><td>
		<select id="ddlCurrentCategory" onchange="<%= HtmlExtension.DropDownListAutoRedir("ddlCurrentCategory")%>"  
			combobox="not-editable" style="width:300px;">
<%= Model.Categories.ToHtmlOptions(Model.CurrentCategoryId, "categoryId", false, "searchWord", "page")%>
</select>
	</td><td>
		<a id="btnCreateItem" href="#" class="easyui-linkbutton" iconCls="icon-add">添加商品</a>
	</td></tr>
</table>
<div style="height: 10px"></div>


<table class="GridView" cellspacing="0" cellpadding="4" border="0" style="border-collapse:collapse;">
	<tr align="left">
		<th style="width:20px;">&nbsp;</th>
		<th style="width:550px;">商品名称</th>
		<th style="width:120px;">单位</th>
		<th style="width:120px;">单价</th>
		<th style="width:50px;">数量</th>
	</tr>
<% foreach( Product product in  Model.Products ) { %>
    <tr>
        <td><a href="/AjaxProduct/Delete.cspx?id=<%= product.ProductID %>&returnUrl=<%= this.RequestUrlEncodeRawUrl %>" 
				title="删除" class="easyui-linkbutton" plain="true">
			<img src="/Images/delete.gif" alt="删除" /></a>
        </td>
        <td style="white-space:nowrap;">
			<a href="#" rowId="<%= product.ProductID %>" class="easyui-linkbutton" plain="true" iconCls="icon-open" >
				<%= product.ProductName.HtmlEncode()%></a>
		</td><td>
			<span name="Unit"><%= product.Unit.HtmlEncode() %></span>
		</td><td>
			<span name="UnitPrice"><%= product.UnitPrice.ToText() %></span>
		</td><td>
			<input type="text" pid="<%= product.ProductID %>" value="<%= product.Quantity %>" class="quantityTextbox" />
		</td>
    </tr>
<% } %>

<%= Model.PagingInfo.PaginationBar(5)%>
</table>

<input type="hidden" id="hfCurrentCategoryId" value="<%= Model.CurrentCategoryId %>" />


<div id="divProductInfo" title="商品" style="padding: 8px; display: none">
<%= UcExecutor.Render("/Controls/Style1/ProductInfo.ascx", Model.ProductInfo)%>
</div>

</asp:Content>

