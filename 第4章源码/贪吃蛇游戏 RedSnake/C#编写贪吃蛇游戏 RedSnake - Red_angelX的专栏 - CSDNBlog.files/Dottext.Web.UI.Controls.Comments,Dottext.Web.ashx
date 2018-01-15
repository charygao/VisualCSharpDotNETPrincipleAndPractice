addNamespace("Dottext.Web.UI.Controls.Comments");
Dottext.Web.UI.Controls.Comments = {
	BuildComments:function(path)
			{return AjaxPro.invoke("BuildComments", {"path":path},[1,arguments,2], this.url);},
	url:"/ajaxpro/Dottext.Web.UI.Controls.Comments,Dottext.Web.ashx"
}
