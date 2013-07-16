

$(function(){
	$("#btnAdd1").click(function(){
		$.ajax({
			url: "/Fish.AA.AjaxTest/Add.cspx",
			data: {a: $("#txtA1").val(), b: $("#txtB1").val()},
			success: function(responseText){
				$("#spanResult1").text(responseText);
			}
		});
	});
	
	$("#btnAdd2").click(function(){
		$.ajax({
			// 以下二个URL地址都是有效的。
			//url: "/Fish.BB.AjaxTest.Add.cspx",
			url: "/Fish/BB/AjaxTest/Add.cspx",
			data: {a: $("#txtA2").val(), b: $("#txtB2").val()},
			success: function(responseText){
				$("#spanResult2").text(responseText);
			}
		});
	});
});

