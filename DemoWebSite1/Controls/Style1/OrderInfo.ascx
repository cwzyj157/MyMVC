<%@ Control Language="C#" Inherits="MyUserControlView<Order>" %>

<table cellpadding="4" cellspacing="0" style="width: 99%">
<tr><td style="width: 60px">订单日期</td><td>
	<input type="text" class="myTextbox" readonly="readonly" style="width: 200px" value="<%= Model.OrderDate.ToString("yyyy-MM-dd HH:mm:ss") %>" />
	</td></tr>
<tr><td>客户</td><td>
	<input type="text" class="myTextbox" readonly="readonly" style="width: 400px" value="<%= Model.CustomerName.HtmlAttributeEncode() %>" />
	</td></tr>
<tr><td class="vertical">订单明细</td><td>
	<table cellpadding="4" cellspacing="0"  id="tblOrderDetail" class="GridView">
		<tr>
			<td style="width: 450px">商品名称</td>
			<td style="width: 60px">单位</td>
			<td style="width: 60px">数量</td>
			<td style="width: 60px">单价</td>
		</tr>		
<% foreach( var item in Model.Details ) { %>
<tr>
	<td><a href="#" ProductId="<%= item.ProductID %>" class="easyui-linkbutton" plain="true"><%= item.ProductName.HtmlEncode() %></a></td>
	<td><%= item.Unit.HtmlEncode()%></td>
	<td><%= item.Quantity %></td>
	<td><%= item.UnitPrice.ToString("F2") %></td>
</tr>
<% } %>
		<tr><td colspan="4" style="text-align: right; padding-right: 10px;">
			订单总金额：<b><%= Model.SumMoney.ToText() %></b>
		</td></tr>		
	</table>
</td></tr>

<tr><td class="vertical">备注</td><td>
	<textarea class="myTextbox" style="width: 660px; height: 70px" readonly="readonly" ><%= Model.Comment.HtmlEncode()%></textarea>
	</td></tr>
<tr><td></td><td>
	<label><%= Model.Finished.ToCheckBox("chkFinished", null, false) %>订单已处理</label>	&nbsp;&nbsp;&nbsp;
		<a id="btnSetOrderStatus" href="#" class="easyui-linkbutton" iconCls="icon-ok">修改订单状态</a>		
	</td></tr>
</table>
