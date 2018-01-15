<%@ Page language="c#" Codebehind="guest.aspx.cs" AutoEventWireup="false" Inherits="liu_yan_book.guestpost" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>guestpost</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 104px; WIDTH: 488px; POSITION: absolute; TOP: 40px; HEIGHT: 242px"
					borderColor="#999900" cellSpacing="1" borderColorDark="#993300" cellPadding="1" width="488"
					bgColor="#99ffff" border="1">
					<TR>
						<TD style="WIDTH: 142px; HEIGHT: 36px">留言人:</TD>
						<TD style="HEIGHT: 36px">
							<asp:TextBox id="Name" runat="server" Width="184px" Height="24px"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 142px">Email:</TD>
						<TD>
							<asp:TextBox id="Email" runat="server" Width="184px"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 142px">留言内容</TD>
						<TD>
							<asp:TextBox id="Comments" runat="server" Width="328px" Rows="10" TextMode="MultiLine"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 142px"></TD>
						<TD>
							<asp:Button id="Button2" runat="server" Height="32px" Width="88px" Text="留言提交"></asp:Button>
							<asp:Label id="errmess" runat="server" Height="22px" Width="96px">Label</asp:Label></TD>
					</TR>
				</TABLE>
				<asp:Button id="Button1" style="Z-INDEX: 102; LEFT: 208px; POSITION: absolute; TOP: 336px" runat="server"
					Height="32px" Width="96px" Text="流提交"></asp:Button>
				<asp:LinkButton id="LinkButton1" style="Z-INDEX: 104; LEFT: 440px; POSITION: absolute; TOP: 8px"
					runat="server" Height="24px" Width="120px">返回首页</asp:LinkButton>
			</FONT>
		</form>
	</body>
</HTML>
