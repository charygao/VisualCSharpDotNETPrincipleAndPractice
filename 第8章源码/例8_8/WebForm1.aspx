<%@ Page language="c#" Codebehind="WebForm1.aspx.cs" AutoEventWireup="false" Inherits="例8_9.WebForm1" %>
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
				<asp:TextBox id="TextBox1" style="Z-INDEX: 101; LEFT: 149px; POSITION: absolute; TOP: 29px" runat="server"
					Width="153px" Height="26px"></asp:TextBox>
				<asp:TextBox id="TextBox3" style="Z-INDEX: 106; LEFT: 152px; POSITION: absolute; TOP: 120px"
					runat="server" Width="153px" Height="26px"></asp:TextBox>
				<asp:TextBox id="TextBox2" style="Z-INDEX: 105; LEFT: 152px; POSITION: absolute; TOP: 72px" runat="server"
					Width="153px" Height="26px"></asp:TextBox>
				<asp:Label id="Label3" style="Z-INDEX: 104; LEFT: 40px; POSITION: absolute; TOP: 120px" runat="server"
					Width="96px" Height="24px">Email信息</asp:Label>
				<asp:Label id="Label2" style="Z-INDEX: 103; LEFT: 40px; POSITION: absolute; TOP: 80px" runat="server"
					Width="96px" Height="24px">年龄</asp:Label>
				<asp:Label id="Label1" style="Z-INDEX: 102; LEFT: 40px; POSITION: absolute; TOP: 32px" runat="server"
					Width="96px" Height="24px">会员帐号</asp:Label>
				<asp:RegularExpressionValidator id="RegularExpressionValidator1" style="Z-INDEX: 107; LEFT: 320px; POSITION: absolute; TOP: 32px"
					runat="server" Width="200px" ErrorMessage="会员帐户是4-8个英文字符" ControlToValidate="TextBox1" ValidationExpression="[A-Za-z]{4,8}"></asp:RegularExpressionValidator>
				<asp:RangeValidator id="RangeValidator1" style="Z-INDEX: 108; LEFT: 320px; POSITION: absolute; TOP: 72px"
					runat="server" Width="136px" Height="32px" ErrorMessage="年龄是20到30之间" ControlToValidate="TextBox2"
					MaximumValue="30" MinimumValue="20"></asp:RangeValidator>
				<asp:RegularExpressionValidator id="RegularExpressionValidator2" style="Z-INDEX: 109; LEFT: 320px; POSITION: absolute; TOP: 120px"
					runat="server" Width="144px" Height="32px" ErrorMessage="请输入正确Email\w{1,}@\w{3,}." 
                ControlToValidate="TextBox3" ValidationExpression="[a-zA-Z]{1,}@[a-z.A-Z]{3,}"></asp:RegularExpressionValidator>
				<asp:Button id="Button1" style="Z-INDEX: 110; LEFT: 200px; POSITION: absolute; TOP: 168px" runat="server"
					Width="80px" Height="32px" Text="提交"></asp:Button>
				<asp:Label id="Label4" style="Z-INDEX: 111; LEFT: 344px; POSITION: absolute; TOP: 168px" runat="server"
					Height="48px" Width="192px"></asp:Label>
				</FONT>
		</form>
	</body>
</HTML>
