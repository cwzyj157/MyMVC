<%@ Control Language="C#" Inherits="MyUserControlView<CustomerPickerModel>" %>

<table cellpadding="4" cellspacing="0" style="margin-bottom: 5px" >
<tr><td>按名称查找：</td>
	<td><input type="text" id="txtCustomerFilterName" class="myTextbox" style="width: 400px" 
		value="<%= Model.SearchInfo.SearchWord.HtmlAttributeEncode() %>" maxlength="50" /></td>
	<td><a id="btnCustomerPickerFilterByName">查找</a></td></tr>
</table>

<table class="GridView" cellspacing="0" cellpadding="4" border="0" style="border-collapse:collapse; width: 97%">
	<tr align="left">
		<th>客户名称</th>
		<th style="width:300px;">地址</th>
		<th style="width:100px;">电话</th>
	</tr>

<% foreach( var item in Model.List ) { %>
<tr>
	<td><label class="handCursor"><input type="radio" sid='itemId_<%= item.CustomerID %>' name="bbbbbbbbbbbbbb" />
		<span sid='itemName_<%= item.CustomerID %>'><%= item.CustomerName.HtmlEncode() %></span>
		</label></td>
	<td><%= item.Address.HtmlEncode() %></td>
	<td><%= item.Tel.HtmlEncode() %></td>
</tr>
<% } %>

<%= Model.SearchInfo.PaginationBar(4)%>
</table>
