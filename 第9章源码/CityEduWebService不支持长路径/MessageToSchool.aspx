<%@ Page language="c#" Codebehind="MessageToSchool.aspx.cs" AutoEventWireup="false" Inherits="CityEduWebService.MessageToSchool" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>发给学校的消息</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="forum.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="Label" style="Z-INDEX: 101; LEFT: 80px; POSITION: absolute; TOP: 368px" runat="server">发给学校的新消息</asp:Label>
			<asp:Label id="Label1" style="Z-INDEX: 104; LEFT: 232px; POSITION: absolute; TOP: 16px" runat="server"
				Width="320px">发给学校的消息只有一条是当前有效的</asp:Label>
			<asp:TextBox id="TextBox1" style="Z-INDEX: 102; LEFT: 224px; POSITION: absolute; TOP: 368px"
				runat="server" Width="248px" Height="74px" TextMode="MultiLine"></asp:TextBox>
			<asp:Button id="Button1" style="Z-INDEX: 103; LEFT: 512px; POSITION: absolute; TOP: 368px" runat="server"
				Text="确定" Width="80px"></asp:Button>
			<asp:DataGrid id="DataGrid1" style="Z-INDEX: 105; LEFT: 160px; POSITION: absolute; TOP: 40px"
				runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False" BorderColor="#CCCCCC"
				BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" Font-Size="X-Small">
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
				<ItemStyle Font-Size="Smaller" ForeColor="#000066"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#006699"></HeaderStyle>
				<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
				<Columns>
					<asp:BoundColumn DataField="Message_ID" HeaderText="消息号码"></asp:BoundColumn>
					<asp:BoundColumn DataField="MessageText" HeaderText="消息内容"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="消息有效否">
						<HeaderStyle Wrap="False"></HeaderStyle>
						<ItemTemplate>
							<asp:CheckBox id=CheckBoxr1r runat="server" Checked='<%# IsOK(DataBinder.Eval(Container.DataItem, "MessageValid"))  %>' Enabled="false">
							</asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
			</asp:DataGrid>
		</form>
	</body>
</HTML>
