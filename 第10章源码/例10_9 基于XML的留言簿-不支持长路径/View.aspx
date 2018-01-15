<%@ Page language="c#" Codebehind="View.aspx.cs" AutoEventWireup="false" Inherits="liu_yan_book.View" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>View</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:DataGrid id="Dg1" style="Z-INDEX: 103; LEFT: 672px; POSITION: absolute; TOP: 196px" runat="server"
				AllowPaging="True" BorderWidth="1px" CellPadding="4" BackColor="White" BorderStyle="None"
				BorderColor="#3366CC" Width="97px" Height="209px">
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
			</asp:DataGrid>
			<asp:Button id="Button2" style="Z-INDEX: 102; LEFT: 680px; POSITION: absolute; TOP: 24px" runat="server"
				Width="104px" Height="40px" Text="表格"></asp:Button>
			<asp:Repeater id="Repeater1" runat="server">
				<HeaderTemplate>
					<Table width="80%" style="font: 10pt verdana" align="center">
						<tr bgcolor="#cc9966">
							留言簿
						</tr>
				</HeaderTemplate>
				<ItemTemplate>
					<tr style="background-color:FFECD8">
						<td width="20%">留言人</td>
						<td><%# DataBinder.Eval(Container.DataItem,"Name") %></td>
					</tr>
					<tr style="background-color:FFECD8">
						<td>Email</td>
						<td><%# DataBinder.Eval(Container.DataItem,"Email") %></td>
					</tr>
					<tr style="background-color:FFECD8">
						<td>留言内容</td>
						<td><%# DataBinder.Eval(Container.DataItem,"Comments") %></td>
					</tr>
					<tr style="background-color:FFECD8">
						<td>留言时间</td>
						<td><%# DataBinder.Eval(Container.DataItem,"DateTime") %></td>
					</tr>
				</ItemTemplate>
				<FooterTemplate>
					</Table>
				</FooterTemplate>
			</asp:Repeater>
			<asp:Label id="Label1" style="Z-INDEX: 104; LEFT: 680px; POSITION: absolute; TOP: 112px" runat="server"
				Width="88px" Height="24px">Label</asp:Label>
		</form>
	</body>
</HTML>
