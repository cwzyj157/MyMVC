<%@ Page Language="C#" %>
<%@ OutputCache Duration="10" VaryByParam="None" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>http://www.cnblogs.com/fish-li/</title>
</head>
<body>
	<p>页面生成时间：<%= DateTime.Now.ToString() %></p>
	<p>
		<a href="<%= Request.RawUrl %>">刷新本页</a>
	</p>
</body>
</html>