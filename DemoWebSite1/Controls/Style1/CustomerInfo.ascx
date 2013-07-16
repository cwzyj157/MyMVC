<%@ Control Language="C#" Inherits="MyUserControlView<Customer>" %>

<table cellpadding="4" border="0px">
<tr><td style="width: 80px">客户名称</td><td>
	<input name="CustomerName" type="text" maxlength="50" id="txtCustomerName" 
		class="myTextbox w400" value="<%= Model.CustomerName.HtmlAttributeEncode() %>" />
	</td></tr>
<tr><td>联系人</td><td>
	<input name="ContactName" type="text" maxlength="50" id="txtContactName" 
		class="myTextbox w400"	value="<%= Model.ContactName.HtmlAttributeEncode() %>" />
	</td></tr>
<tr><td>地址</td><td>
	<input name="Address" type="text" maxlength="50" id="txtAddress" 
		class="myTextbox w400"	value="<%= Model.Address.HtmlAttributeEncode() %>" />
	</td></tr>

<tr><td>邮编</td><td>
	<input name="PostalCode" type="text" maxlength="10" id="txtPostalCode" 
		class="myTextbox w400" value="<%= Model.PostalCode.HtmlAttributeEncode() %>" />
	</td></tr>
<tr><td>电话</td><td>
	<input name="Tel" type="text" maxlength="50" id="txtTel" 
		class="myTextbox w400"	value="<%= Model.Tel.HtmlAttributeEncode() %>" />
	</td></tr>
</table>
