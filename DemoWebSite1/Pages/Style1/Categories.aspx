<%@ Page Title="商品分类管理" Language="C#" MasterPageFile="MasterPage.master" 
			Inherits="MyPageView<CategoriesPageModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<%= UiHelper.RefJsFileHtml("/js/MyPage/Categories.js")%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<p><a id="btnCreateItem" href="#" class="easyui-linkbutton" iconCls="icon-add">创建商品分类</a></p>

<table class="GridView" cellspacing="0" cellpadding="4" border="0" style="border-collapse:collapse;">
    <tr align="left">
		<th style="width:20px;">&nbsp;</th>
		<th style="width:530px;">分类名称</th>
	</tr>

<% foreach( Category category in Model.List ) { %>
    <tr>
        <td>
            <a href="/AjaxCategory/Delete.cspx?id=<%= category.CategoryID %>" 
						title="删除" class="easyui-linkbutton" plain="true">
			<img src="/Images/delete.gif" alt="删除" /></a>
        </td>

        <td><a href="#" class="easyui-linkbutton" rowId="<%= category.CategoryID %>" 
				plain="true" iconCls="icon-open"><%= category.CategoryName.HtmlEncode() %></a>
        </td>
    </tr>
<%} %>

</table>


<div id="divAddItem" title="商品分类" style="padding: 8px; display: none">

<table cellpadding="4" border="0px">
<tr><td style="width: 80px">分类名称</td>
	<td><input name="CategoryName" type="text" maxlength="20" id="txtCategoryName" class="myTextbox w300" /></td></tr>
</table>
	
</div>





</asp:Content>

