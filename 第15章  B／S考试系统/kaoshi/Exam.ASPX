<%@ Page CodeBehind="Exam.ASPX.cs" Language="c#" AutoEventWireup="false" Inherits="Test.test" %>
<HTML>
	<HEAD>
		<TITLE>考试页面</TITLE>
		<SCRIPT language="JavaScript">
		var timeID=0;
		var tt1='<%=Session["Time"]%>'; //7200;//120分钟 7200
		tt2=0;tt3=0;
		function startTimer()
		{timeID=setInterval("hnceTimer()",1000);}
		function submitfunction()
        {
             document.getElementById("Submit1").click();
        }
		function hnceTimer()
		{
		
		tt1--;tt2=tt1 % 60;tt3=(tt1-tt2)/60;
	
		if (tt2>=10){mytime1.innerHTML=tt3+":"+tt2;}else{mytime1.innerHTML=tt3+":0"+tt2}
		mytime2.innerHTML=mytime1.innerHTML;
		window.status="剩余时间:"+mytime1.innerHTML;
		if ((tt1<=0) && (tt1>-20))
		{clearInterval(timeID);submitfunction();return true;}}
		</SCRIPT>
	
	</HEAD>
	<body bgColor="#cde8fb" onload="startTimer()">
		<form id="Form1" name="PaperForm" runat="server">
			<P align="center"><FONT color="#3366ff" size="8">C#程序设计考试系统3.0版</FONT></P>
			<DIV align="center">
				<CENTER>
					<TABLE id="Table0" height="30" cellSpacing="0" cellPadding="0" align="center" border="0">
						<TR>
							<TD width="40" bgColor="#ffccff" height="20">
								<P align="center"><FONT size="2">考号</FONT></P>
							</TD>
							<TD width="64" bgColor="#ffffee" height="20">
								<P align="center"><FONT color="#0000ff" size="2"><asp:label id="xuehao" runat="server"></asp:label></FONT></P>
							</TD>
							<TD width="40" bgColor="#ffccff" height="20">
								<P align="center"><FONT size="2">姓名</FONT></P>
							</TD>
							<TD width="60" bgColor="#ffffee" height="20">
								<P align="center"><FONT face="宋体"><asp:label id="name" runat="server"></asp:label></FONT></P>
							</TD>
							<TD width="64" bgColor="#ffccff" height="20">
								<P align="center"><FONT size="2">剩余时间</FONT></P>
							</TD>
							<TD width="113" bgColor="#ffffee" height="20"><FONT face="宋体" color="#ff0000" size="2">
									<DIV id="mytime1" align="center"></DIV>
								</FONT>
							</TD>
							<TD align="center" width="298" colSpan="4" height="20"><asp:button id="save1" runat="server" Text="保存试卷" Width="57px"></asp:button><asp:button id="Submit1" runat="server" Text="提交试卷" Width="60px"></asp:button><asp:button id="BtnDown" runat="server" Text="下载已答答案" Width="95px" Visible="False"></asp:button></TD>
						</TR>
					</TABLE>
				</CENTER>
			</DIV>
			<HR noShade>
			<asp:repeater id="rpCust1" runat="server">
				<HeaderTemplate>
					<Table width="80%" style="font: 8pt verdana" align="center">
						<tr bgcolor="#ffccff">
							<asp:Label ID="lbl_dan" Runat="server"></asp:Label>
						</tr>
				</HeaderTemplate>
				<ItemTemplate>
					<tr style="background-color:#ffffee">
						<td colspan="2" width="80%">
							<asp:Label ID="lbl_dan_sxh" Runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"顺序号") %>'>
							</asp:Label>
							<asp:Label ID="lbl_dan_stbh" Runat="server" Visible=false Text='<%# DataBinder.Eval(Container.DataItem,"试题编号") %>'>
							</asp:Label>
							)
							<%# Changechr(DataBinder.Eval(Container.DataItem,"题干","{0:c}")) %>
						</td>
					</tr>
					<tr style="background-color:#ffffee">
						<td width="40%">
							<asp:radiobutton id="rb_xxa" groupname="aa" runat="server" text="A" />.
							<%# DataBinder.Eval(Container.DataItem, "选项A") %>
						</td>
						<td width="40%">
							<asp:radiobutton id="rb_xxb" groupname="aa" runat="server" text="B" />.
							<%# DataBinder.Eval(Container.DataItem, "选项B") %>
						</td>
					</tr>
					<tr style="background-color:#ffffee">
						<td width="40%">
							<asp:radiobutton id="rb_xxc" groupname="aa" runat="server" text="C" />.
							<%# DataBinder.Eval(Container.DataItem, "选项C") %>
						</td>
						<td width="40%">
							<asp:radiobutton id="rb_xxd" groupname="aa" runat="server" text="D" />.
							<%# DataBinder.Eval(Container.DataItem, "选项D") %>
						</td>
					</tr>
				</ItemTemplate>
				<FooterTemplate>
					</Table>
				</FooterTemplate>
			</asp:repeater>
			<P>
			<P></P>
			<P></P>
			<FONT color="#3366ff" size="7"></FONT>
			<asp:repeater id="rpCust2" runat="server">
				<HeaderTemplate>
					<Table width="80%" style="font: 8pt verdana" align="center">
						<tr style="background-color:#ffccff">
							<asp:Label ID="lbl_duo" Runat="server"></asp:Label>
						</tr>
				</HeaderTemplate>
				<ItemTemplate>
					<tr style="background-color:#ffffee">
						<td colspan="2" width="80%">
							<asp:Label ID="lbl_duo_sxh" Runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"顺序号") %>'>
							</asp:Label>
							<asp:Label ID="lbl_duo_stbh" Runat="server" Visible=false Text='<%# DataBinder.Eval(Container.DataItem,"试题编号") %>'>
							</asp:Label>
							)<%# Changechr(DataBinder.Eval(Container.DataItem,"题干","{0:c}")) %>
						</td>
					</tr>
					<tr style="background-color:#ffffee">
						<td>
							<asp:checkBox id="cb_xxa" runat="server" text="A" />.
							<%# DataBinder.Eval(Container.DataItem, "选项A") %>
						</td>
						<td>
							<asp:checkBox id="cb_xxb" runat="server" text="B" />.
							<%# DataBinder.Eval(Container.DataItem, "选项B") %>
						</td>
					</tr>
					<tr style="background-color:#ffffee">
						<td>
							<asp:checkBox id="cb_xxc" runat="server" text="C" />.
							<%# DataBinder.Eval(Container.DataItem, "选项C") %>
						</td>
						<td>
							<asp:checkBox id="cb_xxd" runat="server" text="D" />.
							<%# DataBinder.Eval(Container.DataItem, "选项D") %>
						</td>
					</tr>
				</ItemTemplate>
				<FooterTemplate>
					</Table>
				</FooterTemplate>
			</asp:repeater>
			<P></P>
			<FONT color="#3366ff" size="7"></FONT>
			<asp:repeater id="rpCust6" runat="server">
				<HeaderTemplate>
					<Table width="80%" style="font: 8pt verdana" align="center">
						<tr style="background-color:#ffccff">
							<asp:Label ID="lbl_tian" Runat="server"></asp:Label>
						</tr>
				</HeaderTemplate>
				<ItemTemplate>
					<tr style="background-color:#ffffee">
						<td colspan="2" width="80%">
							<asp:Label ID="lbl_tian_sxh" Runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"顺序号") %>'>
							</asp:Label>
							<asp:Label ID="lbl_tian_stbh" Runat="server" Visible=False Text='<%# DataBinder.Eval(Container.DataItem,"试题编号") %>'>
							</asp:Label>
							)
							<%# Changechr(DataBinder.Eval(Container.DataItem,"题干","{0:c}")) %>
						</td>
					</tr>
					<tr style="background-color:#ffffee">
						<td colspan="2" width="80%">
							<asp:TextBox id="txt_tk1" runat="server" TextMode="SingleLine"></asp:TextBox>
							<asp:TextBox id="txt_tk2" runat="server" TextMode="SingleLine" Visible="false"></asp:TextBox>
							<asp:TextBox id="txt_tk3" runat="server" TextMode="SingleLine" Visible="False"></asp:TextBox>
							<asp:TextBox id="txt_tk4" runat="server" TextMode="SingleLine" Visible="false"></asp:TextBox>
						</td>
					</tr>
				</ItemTemplate>
				<FooterTemplate>
					</Table>
				</FooterTemplate>
			</asp:repeater>
			<P></P>
			<FONT color="#3366ff" size="7"></FONT>
			<asp:repeater id="rpCust3" runat="server">
				<HeaderTemplate>
					<Table width="80%" style="font: 8pt verdana" align="center">
						<tr style="background-color:#ffccff">
							<asp:Label ID="lbl_pan" Runat="server"></asp:Label>
						</tr>
				</HeaderTemplate>
				<ItemTemplate>
					<tr style="background-color:#ffffee">
						<td colspan="2" width="80%">
							<asp:Label ID="lbl_pan_sxh" Runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"顺序号") %>'>
							</asp:Label>
							<asp:Label ID="lbl_pan_stbh" Runat="server" Visible=False Text='<%# DataBinder.Eval(Container.DataItem,"试题编号") %>'>
							</asp:Label>
							)<%# Changechr(DataBinder.Eval(Container.DataItem,"题干","{0:c}")) %>
						</td>
					</tr>
					<tr style="background-color:#ffffee">
						<td width="40%">
							<asp:radiobutton id="rb_pan1" groupname="cc" runat="server" text="对" />
						</td>
						<td width="40%">
							<asp:radiobutton id="rb_pan2" groupname="cc" runat="server" text="错" />
						</td>
					</tr>
				</ItemTemplate>
				<FooterTemplate>
					</Table>
				</FooterTemplate>
			</asp:repeater>
			<P></P>
			<FONT color="#3366ff" size="7"></FONT>
			<asp:repeater id="rpCust4" runat="server">
				<HeaderTemplate>
					<Table width="80%" style="font: 8pt verdana" align="center">
						<tr style="background-color:#ffccff">
							<asp:Label ID="lbl_jian" Runat="server"></asp:Label>
						</tr>
				</HeaderTemplate>
				<ItemTemplate>
					<tr style="background-color:#ffffee">
						<td colspan="2" width="80%">
							<asp:Label ID="lbl_jian_sxh" Runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"顺序号") %>'>
							</asp:Label>
							<asp:Label ID="lbl_jian_stbh" Runat="server" Visible=False Text='<%# DataBinder.Eval(Container.DataItem,"试题编号") %>'>
							</asp:Label>
							)
							<%# Changechr(DataBinder.Eval(Container.DataItem,"题干","{0:c}")) %>
						</td>
					</tr>
					<tr style="background-color:#ffffee">
						<td colspan="2" width="80%">
							<asp:TextBox id="txt_jian" runat="server" Rows="8" TextMode="MultiLine"></asp:TextBox>
						</td>
					</tr>
				</ItemTemplate>
				<FooterTemplate>
					</Table>
				</FooterTemplate>
			</asp:repeater>
			<P></P>
			<FONT color="#3366ff" size="7"></FONT>
			<asp:repeater id="rpCust5" runat="server">
				<HeaderTemplate>
					<Table width="80%" style="font: 8pt verdana" align="center">
						<tr style="background-color:#ffccff">
							<asp:Label ID="lbl_bian" Runat="server"></asp:Label>
						</tr>
				</HeaderTemplate>
				<ItemTemplate>
					<tr style="background-color:#ffffee">
						<td colspan="2" width="80%">
							<asp:Label ID="lbl_bian_sxh" Runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"顺序号") %>'>
							</asp:Label>
							<asp:Label ID="lbl_bian_stbh" Runat="server" Visible=False Text='<%# DataBinder.Eval(Container.DataItem,"试题编号") %>'>
							</asp:Label>
							)
							<%# Changechr(DataBinder.Eval(Container.DataItem,"题干","{0:c}")) %>
						</td>
					</tr>
					<tr style="background-color:#ffffee">
						<td colspan="2" width="80%">
							<asp:TextBox id="txt_bian" runat="server" width="100%" Rows="20" TextMode="MultiLine"></asp:TextBox>
						</td>
					</tr>
				</ItemTemplate>
				<FooterTemplate>
					</Table>
				</FooterTemplate>
			</asp:repeater><br>
			<DIV align="center">
				<CENTER>
					<TABLE id="Table4" style="BORDER-COLLAPSE: collapse" cellSpacing="0" cellPadding="0" align="center"
						border="0">
						<TR>
							<TD width="40" bgColor="#ffff00" height="20">
								<P align="center"><FONT size="2">考号</FONT></P>
							</TD>
							<TD width="60" bgColor="#ffffee" height="20">
								<P align="center"><FONT color="#0000ff" size="2"><asp:label id="xuehao2" runat="server"></asp:label></FONT></P>
							</TD>
							<TD width="40" bgColor="#ffff00" height="20">
								<P align="center"><FONT size="2">姓名</FONT></P>
							</TD>
							<TD width="60" bgColor="#ffffee" height="20">
								<P align="center"><FONT face="宋体"><asp:label id="name2" runat="server"></asp:label></FONT></P>
							</TD>
							<TD width="60" bgColor="#ffff00" height="20">
								<P align="center"><FONT size="2">剩余时间</FONT></P>
							</TD>
							<TD width="78" bgColor="#ffffee" height="20"><FONT face="宋体" color="#ff0000" size="2">
									<DIV id="mytime2" align="center"></DIV>
								</FONT>
							</TD>
							<TD align="center" width="298" colSpan="4" height="20"><asp:button id="save2" runat="server" Text="保存试卷"></asp:button><asp:button id="Submit" runat="server" Text="提交试卷"></asp:button></TD>
						</TR>
					</TABLE>
				</CENTER>
			</DIV>
			<HR color="#ff0000" noShade>
			<P></TD></TR></TBODY></TABLE></FONT></P>
		</form>
	</body>
</HTML>
