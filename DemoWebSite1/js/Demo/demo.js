

$(function(){
	$("#btnGetMd5").click(function(){
		$.ajax({
			// 以下二个URL地址都是有效的。
			//url: "/AjaxDemo/GetMd5.cspx",
			url: "/AjaxDemo.GetMd5.cspx",
			data: {input: $("#txtInput").val()},
			success: function(responseText){
				$("#spanReslt").text(responseText);
			}
		});
	});
});

