<%@ Control Language="C#" Inherits="MyUserControlView<ProductPickerModel>" %>

<table cellpadding="4" cellspacing="0" style="margin-bottom: 5px" >
<tr>
<td>商品类别：</td>
	<td><select id="ProductPicker_ddlCurrentCategory" 
	onchange="<%= HtmlExtension.DropDownListAutoRedir("ProductPicker_ddlCurrentCategory")%>"  
		combobox="not-editable" autoRedire="true" style="width:180px;">
	<%= Model.CategoryList.ToHtmlOptions(Model.SearchInfo.CategoryId, "categoryId", true, "searchWord", "page") %>
	</select>
	<input type="hidden" id="ProductPicker_CurrentCategoryId" value="<%= Model.SearchInfo.CategoryId %>" />
	</td>
<td>按名称查找：</td>
	<td><input type="text" id="txtProductFilterName" class="myTextbox" style="width: 270px" 
		value="<%= Model.SearchInfo.SearchWord.HtmlAttributeEncode() %>" /></td>
	<td><a id="btnProductPickerFilterByName">查找</a></td></tr>
</table>

<table class="GridView" cellspacing="0" cellpadding="4" border="0" style="border-collapse:collapse; width: 97%">
	<tr align="left">
		<th>商品名称</th>
		<th style="width:50px;">单位</th>
		<th style="width:90px; text-align: right;">单价</th>
		<th style="width:70px; text-align: right;">数量</th>
	</tr>
<% foreach( var item in Model.List ) { %>
<tr>
	<td><label class="handCursor"><input type="checkbox" name='itemId_<%= item.ProductID %>' />
		<span sid='itemName_<%= item.ProductID %>'><%= item.ProductName.HtmlEncode() %></span>
		</label></td>
	<td><%= item.Unit.HtmlEncode() %></td>
	<td style="text-align: right"><%= item.UnitPrice.ToString("F2") %></td>
	<td style="text-align: right"><%= item.Quantity %></td>
</tr>
<% } %>

<%= Model.SearchInfo.PaginationBar(5)%>
</table>

