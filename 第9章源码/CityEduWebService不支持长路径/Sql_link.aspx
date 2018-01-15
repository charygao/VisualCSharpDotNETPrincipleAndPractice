<%@ Page language="c#" Codebehind="Sql_link.aspx.cs" AutoEventWireup="false" Inherits="CityEduWebService.Sql_link" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Sql_link</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="forum.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<asp:Label id="Label1" style="Z-INDEX: 101; LEFT: 192px; POSITION: absolute; TOP: 88px" runat="server">数据库名</asp:Label>
				<asp:TextBox id="textBox_DbPassWord" style="Z-INDEX: 111; LEFT: 264px; POSITION: absolute; TOP: 208px"
					runat="server"></asp:TextBox>
				<asp:TextBox id="textBox_DbUser" style="Z-INDEX: 110; LEFT: 264px; POSITION: absolute; TOP: 168px"
					runat="server"></asp:TextBox>
				<asp:TextBox id="textBox_DBServer" style="Z-INDEX: 109; LEFT: 264px; POSITION: absolute; TOP: 128px"
					runat="server"></asp:TextBox>
				<asp:Label id="Label4" style="Z-INDEX: 108; LEFT: 192px; POSITION: absolute; TOP: 208px" runat="server">密码</asp:Label>
				<asp:TextBox id="TextBox4" style="Z-INDEX: 102; LEFT: 264px; POSITION: absolute; TOP: 88px" runat="server"></asp:TextBox>
				<asp:Label id="Label3" style="Z-INDEX: 107; LEFT: 192px; POSITION: absolute; TOP: 168px" runat="server">用户名</asp:Label>
				<asp:TextBox id="TextBox3" style="Z-INDEX: 103; LEFT: 264px; POSITION: absolute; TOP: 88px" runat="server"></asp:TextBox>
				<asp:Label id="Label2" style="Z-INDEX: 106; LEFT: 192px; POSITION: absolute; TOP: 128px" runat="server">服务器名</asp:Label>
				<asp:TextBox id="TextBox2" style="Z-INDEX: 104; LEFT: 264px; POSITION: absolute; TOP: 88px" runat="server"></asp:TextBox>
				<asp:TextBox id="textBox_Database" style="Z-INDEX: 105; LEFT: 264px; POSITION: absolute; TOP: 88px"
					runat="server"></asp:TextBox>
				<asp:Button id="Button1" style="Z-INDEX: 112; LEFT: 272px; POSITION: absolute; TOP: 296px" runat="server"
					Text="确定" Width="64px"></asp:Button>
				<asp:Label id="lbl_Error" style="Z-INDEX: 113; LEFT: 480px; POSITION: absolute; TOP: 296px"
					runat="server" Visible="False">Label</asp:Label></FONT>
		</form>
	</body>
</HTML>
