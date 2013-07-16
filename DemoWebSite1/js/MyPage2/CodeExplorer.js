

$(function(){
	if( window.SyntaxHighlighter )  
		SyntaxHighlighter.defaults['toolbar'] = false;

	
	$('#fileFolderTree').tree({
		url: '/Ajax/FileTree/GetWebSiteFileNodes.aspx',
		onClick:function(node){
			if( node.attributes.FilePath == "###" )
				return;

			$.ajax({
				url: "/Ajax/FileTree/GetFileText.aspx",  type: "GET", dataType: "text",
				data: {path: node.attributes.FilePath },
				success: function(responseText) {
					var pre = "";
					switch(node.attributes.FileType){
						case ".cs":
						case ".ashx":
						case ".asax":
							pre = "<pre class='brush: c#;' name='code'>"; break;
						case ".css":
							pre = "<pre class='brush: css;' name='code'>"; break;
						case ".js":
							pre = "<pre class='brush: js;' name='code'>"; break;
						case ".sql":
							pre = "<pre class='brush: sql;' name='code'>"; break;
						case ".aspx":
						case ".ascx":
						case ".master":
						case ".config":
						case ".skin":
							pre = "<pre class='brush: xml;' name='code'>"; break;
						default:
							pre = "<pre>";
					}
						
					var html = pre + responseText.replace(/</g, "&lt;") + "</pre>";
					$("#divFileBody").html(html).scrollTop(0).scrollLeft(0);
					SyntaxHighlighter.highlight();
					$("#divFileBody").panel({title: node.text});
				}
			});
		}
	});
});

