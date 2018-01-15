<%@ Page language="c#" Codebehind="login.aspx.cs" AutoEventWireup="false" Inherits="CityEduWebService.login" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>login</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="forum.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="Label1" style="Z-INDEX: 101; LEFT: 184px; POSITION: absolute; TOP: 104px" runat="server">用户名</asp:Label>
			<asp:Button id="Button1" style="Z-INDEX: 102; LEFT: 232px; POSITION: absolute; TOP: 192px" runat="server"
				Text="确定" Width="56px"></asp:Button>
			<asp:TextBox id="TextBox_PageUser" style="Z-INDEX: 103; LEFT: 240px; POSITION: absolute; TOP: 104px"
				runat="server"></asp:TextBox>
			<asp:Label id="Label2" style="Z-INDEX: 104; LEFT: 184px; POSITION: absolute; TOP: 144px" runat="server">密码</asp:Label>
			<asp:TextBox id="TextBox_PagePassword" style="Z-INDEX: 105; LEFT: 240px; POSITION: absolute; TOP: 144px"
				runat="server"></asp:TextBox>
		</form>
	</body>
</HTML>
