<%@ Page language="c#" Codebehind="WebForm1.aspx.cs" AutoEventWireup="false" Inherits="例8_2.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<asp:Label id="Label1" style="Z-INDEX: 101; LEFT: 72px; POSITION: absolute; TOP: 48px" runat="server"
					Width="256px" Height="24px">DropDownList控件示例</asp:Label>
				<asp:Label id="Label2" style="Z-INDEX: 102; LEFT: 72px; POSITION: absolute; TOP: 168px" runat="server"
					Width="280px" Height="24px">Label</asp:Label>
				<asp:DropDownList id="DropDownList1" style="Z-INDEX: 103; LEFT: 72px; POSITION: absolute; TOP: 104px"
					runat="server" Width="152px" Height="32px">
					<asp:ListItem Value="橘子">橘子</asp:ListItem>
					<asp:ListItem Value="菊花">菊花</asp:ListItem>
					<asp:ListItem Value="苹果">苹果</asp:ListItem>
					<asp:ListItem Value="瓜子">瓜子</asp:ListItem>
				</asp:DropDownList>
				<asp:Button id="Button1" style="Z-INDEX: 104; LEFT: 264px; POSITION: absolute; TOP: 104px" runat="server"
					Width="72px" Text="选择"></asp:Button></FONT>
		</form>
	</body>
</HTML>
