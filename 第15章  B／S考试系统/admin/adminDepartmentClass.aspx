<%@ Page language="c#" Codebehind="adminDepartmentClass.aspx.cs" AutoEventWireup="false" Inherits="Test.admin.adminxibubanji" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>adminxibubanji</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<style type="text/css">
BODY TD { FONT-SIZE: 12px }
.zz { FILTER: glow(color=#213a5a,Strength=1); COLOR: #ffffff }
.front { FONT-WEIGHT: bold; FONT-SIZE: 14px; COLOR: #00258f; FONT-FAMILY: "宋体"; TEXT-DECORATION: none }
.bfront { FONT-WEIGHT: bold; FONT-SIZE: 14px; COLOR: #ffffff; FONT-FAMILY: "宋体"; TEXT-DECORATION: none }
.bxfront { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #ffffff; FONT-FAMILY: "宋体"; TEXT-DECORATION: none }
.frontx { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #00258f; FONT-FAMILY: "宋体"; TEXT-DECORATION: none }
.STYLE9 { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #133694 }
.bk2 { BORDER-RIGHT: #8ebeea 1px solid; BORDER-TOP: #8ebeea 1px solid; BORDER-LEFT: #8ebeea 1px solid; BORDER-BOTTOM: #8ebeea 1px solid }
		</style>
	</HEAD>
	<body leftmargin="0" topmargin="0" bgColor="#ecf6f8">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td width="11" bgcolor="#ecf6f8" style="BORDER-RIGHT: #7dafd4 1px solid; BORDER-TOP: #153693 0px solid; BORDER-LEFT: #153693 0px solid; BORDER-BOTTOM: #153693 0px solid"><br>
					</td>
					<td valign="top" bgcolor="#cde8fb" style="BORDER-RIGHT: #7dafd4 0px solid; BORDER-TOP: #153693 0px solid; BORDER-LEFT: #e3f1fa 1px solid; BORDER-BOTTOM: #153693 0px solid">
						<table width="98%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td height="8">
								</td>
							</tr>
						</table>
						<table width="98%" border="2" cellpadding="0" cellspacing="0" bordercolor="#ffffff">
							<tr>
								<td height="440" bgcolor="#ffffff" style="BORDER-RIGHT: #00258f 1px solid; BORDER-TOP: #00258f 1px solid; BORDER-LEFT: #00258f 1px solid; BORDER-BOTTOM: #00258f 1px solid"
									align="center" valign="top">
									<table width="98%" border="0" align="center" cellpadding="0" cellspacing="0" background="../images/a02.jpg">
										<tr>
											<td width="14" align="left"><img src="../images/a01.jpg" width="13" height="26"></td>
											<td width="317"><table width="100%" border="0" cellpadding="0" cellspacing="0">
													<tr>
														<td style="WIDTH: 13px"><font color="#ffffff"><img src="../images/6.jpg" width="18" height="20"></font></td>
														<td><span class="bxfront">
																<asp:Label id="lbl_Title" runat="server"></asp:Label></span></td>
													</tr>
												</table>
											</td>
											<td align="right"><img src="../images/a03.jpg" width="12" height="26"></td>
										</tr>
									</table>
									<table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
										<TBODY>
											<tr>
												<td height="197" style="BORDER-RIGHT: #c2c2c2 1px solid; BORDER-TOP: #00258f 0px solid; BORDER-LEFT: #c2c2c2 1px solid; BORDER-BOTTOM: #00258f 0px solid"
													align="center" valign="top">
													<asp:Panel id="Panel_xb" runat="server">
														<TABLE id="Table1" style="WIDTH: 432px; HEIGHT: 197px" cellSpacing="1" cellPadding="1"
															width="432" border="1">
															<TR>
																<TD style="WIDTH: 78px" bgColor="#d6e6ff">系别名称:</TD>
																<TD style="WIDTH: 350px; HEIGHT: 28px" align="left" bgColor="#eaeaea">
																	<asp:textbox id="TXTxbmc" runat="server" Width="248px"></asp:textbox>
																	<asp:Button id="BtnSave" runat="server" Text="添加系部"></asp:Button></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 78px" bgColor="#d6e6ff"><FONT face="宋体"></FONT></TD>
																<TD style="WIDTH: 181px" bgColor="#eaeaea">
																	<asp:DataGrid id="Dg_xb" runat="server" Width="330px" AutoGenerateColumns="False" AllowPaging="True"
																		DataKeyField="系部编号" Height="176px">
																		<SelectedItemStyle BackColor="#D6E6FF"></SelectedItemStyle>
																		<Columns>
																			<asp:BoundColumn DataField="系部名称" SortExpression="系部名称" HeaderText="系部名称"></asp:BoundColumn>
																			<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="更新" CancelText="取消" EditText="编辑"></asp:EditCommandColumn>
																			<asp:ButtonColumn Text="删除" CommandName="Delete"></asp:ButtonColumn>
																			<asp:ButtonColumn Text="管理班级" CommandName="Select"></asp:ButtonColumn>
																		</Columns>
																	</asp:DataGrid></TD>
															</TR>
														</TABLE>
													</asp:Panel>
													<asp:Panel id="Panel2" runat="server">
														<FONT face="宋体">
															<asp:Panel id="Panel_bj" runat="server" Visible="False">
																<TABLE id="Table2" style="WIDTH: 432px; HEIGHT: 197px" cellSpacing="1" cellPadding="1"
																	width="432" border="1">
																	<TR>
																		<TD style="WIDTH: 78px" bgColor="#d6e6ff">
																			<P>班级名称:</P>
																		</TD>
																		<TD style="WIDTH: 350px; HEIGHT: 28px" align="left" bgColor="#eaeaea">
																			<asp:textbox id="TXTbjmc" runat="server" Width="224px"></asp:textbox>
																			<asp:Button id="BtnSaveBj" runat="server" Width="64px" Text="添加班级"></asp:Button>
																			<asp:Button id="BtnClose" runat="server" Width="40px" Text="关闭" Height="24px"></asp:Button></TD>
																	</TR>
																	<TR>
																		<TD style="WIDTH: 78px" bgColor="#d6e6ff"><FONT face="宋体"></FONT></TD>
																		<TD style="WIDTH: 181px" bgColor="#eaeaea">
																			<asp:DataGrid id="Dg_bj" runat="server" Width="330px" AutoGenerateColumns="False" AllowPaging="True"
																				DataKeyField="id" Height="176px">
																				<Columns>
																					<asp:BoundColumn DataField="班级名称" SortExpression="班级名称" HeaderText="班级名称"></asp:BoundColumn>
																					<asp:BoundColumn DataField="允许考试日期" SortExpression="允许考试日期" HeaderText="允许考试日期" DataFormatString="{0:d}"></asp:BoundColumn>
																					<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="更新" CancelText="取消" EditText="编辑"></asp:EditCommandColumn>
																					<asp:ButtonColumn Text="删除" CommandName="Delete"></asp:ButtonColumn>
																				</Columns>
																			</asp:DataGrid></TD>
																	</TR>
																</TABLE>
															</asp:Panel></FONT></asp:Panel>
												</td>
											</tr>
										</TBODY>
									</table>
									<table width="98%" border="0" align="center" cellpadding="0" cellspacing="0" background="../images/a05.jpg">
										<tr>
											<td valign="top"><img src="../images/a04.jpg" width="8" height="8"></td>
											<td><div align="right"><img src="../images/a06.jpg" width="8" height="8"></div>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						<table width="98%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td height="25">
									<div align="center">Copy right&nbsp;中原工学院 All rights reserved</div>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
