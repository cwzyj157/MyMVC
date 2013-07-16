<%@ Control Language="C#" Inherits="MyUserControlView<OrderListModel>" %>

<table class="GridView" cellspacing="0" cellpadding="4" border="0" style="border-collapse:collapse; width: 99%">
	<tr align="left">
		<th style="width:100px;">订单编号</th>
		<th style="width:160px;">时间</th>
		<th style="width:300px;">客户</th>
		<th style="width:100px;">订单金额</th>
		<th style="width:60px;">已处理</th>
	</tr>
<% foreach( var item in Model.List ) { %>
<tr>
	<td>
		<a href="#" OrderNo="<%= item.OrderID %>" class="easyui-linkbutton" plain="true" iconCls="icon-open"><%= item.OrderNo %></a>
	</td>
	<td><%= string.Format("{0:yyyy-MM-dd HH:mm:ss}", item.OrderDate) %></td>
	<td>
		<a href="#" Customer='<%= item.ValidCustomerId %>' class="easyui-linkbutton" plain="true" iconCls="icon-open"><%= item.CustomerName.HtmlEncode() %></a>
	</td>
	<td><%= item.SumMoney.ToText() %></td>
	<td>
		<%= item.Finished.ToCheckBox(null, "chk_Finished", true) %>
	</td>
</tr>
<% } %>

<%= Model.SearchInfo.PaginationBar(5) %>
</table>

