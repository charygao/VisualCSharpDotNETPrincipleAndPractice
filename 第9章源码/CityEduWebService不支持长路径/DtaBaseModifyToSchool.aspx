<%@ Page language="c#" Codebehind="DtaBaseModifyToSchool.aspx.cs" AutoEventWireup="false" Inherits="CityEduWebService.DtaBaseModifyToSchool" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DtaBaseModifyToSchool</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="forum.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<asp:Label id="Label" style="Z-INDEX: 103; LEFT: 112px; POSITION: absolute; TOP: 32px" runat="server"
					Width="440px" Font-Bold="True">下面为对各学校数据库的修改SQL语句,请确保能够执行！操作将会在各学校执行升级本机数据库的时候执行。</asp:Label>
				<asp:TextBox id="TextBox_MessageUpdateDB" style="Z-INDEX: 101; LEFT: 64px; POSITION: absolute; TOP: 80px"
					runat="server" Height="192px" TextMode="MultiLine" Width="528px"></asp:TextBox>
				<asp:Button id="Button1" style="Z-INDEX: 102; LEFT: 304px; POSITION: absolute; TOP: 304px" runat="server"
					Width="56px" Text="确定" Height="24px"></asp:Button>
				<asp:Label id="lbl_Error" style="Z-INDEX: 104; LEFT: 528px; POSITION: absolute; TOP: 312px"
					runat="server" Visible="False">Label</asp:Label></FONT>
		</form>
	</body>
</HTML>
