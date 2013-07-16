<%@ Page Title="查看源代码" Language="C#" MasterPageFile="MasterPage.master"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<link type="text/css" rel="Stylesheet" href="/js/syntaxhighlighter/shCore.css" />
	<link type="text/css" rel="Stylesheet" href="/js/syntaxhighlighter/shThemeDefault.css" />
	
	<script type="text/javascript" src="/js/syntaxhighlighter/shCore.js"></script>
	<script type="text/javascript" src="/js/syntaxhighlighter/shBrushCSharp.js"></script>
	<script type="text/javascript" src="/js/syntaxhighlighter/shBrushCss.js"></script>
	<script type="text/javascript" src="/js/syntaxhighlighter/shBrushJScript.js"></script>
	<script type="text/javascript" src="/js/syntaxhighlighter/shBrushSql.js"></script>
	<script type="text/javascript" src="/js/syntaxhighlighter/shBrushXml.js"></script>
	<%= UiHelper.RefJsFileHtml("/js/MyPage/CodeExplorer.js")%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divExplorerContainer" style="width: 100%; overflow: hidden;">
	<div class="easyui-layout" fit="true" id="divExplorer">
		<div region="west" id="divFolder" split="true" title="文件夹／文件" style="width:240px;">
			<ul id="fileFolderTree"></ul>
		</div>
		
		<div region="center" id="divFileBody" title="文件源代码">
		</div>
	</div>
</div>
</asp:Content>

