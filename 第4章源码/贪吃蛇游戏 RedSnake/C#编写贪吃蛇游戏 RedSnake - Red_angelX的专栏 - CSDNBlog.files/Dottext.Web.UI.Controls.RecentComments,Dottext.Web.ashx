addNamespace("Dottext.Web.UI.Controls.RecentComments");
Dottext.Web.UI.Controls.RecentComments = {
	BuildComments:function(path)
			{return AjaxPro.invoke("BuildComments", {"path":path},[1,arguments,2], this.url);},
	url:"/ajaxpro/Dottext.Web.UI.Controls.RecentComments,Dottext.Web.ashx"
}
