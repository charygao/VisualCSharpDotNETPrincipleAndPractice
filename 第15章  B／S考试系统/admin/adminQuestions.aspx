<%@ Page language="c#" Codebehind="adminQuestions.aspx.cs" AutoEventWireup="false" Inherits="Test.admin.adminquestions" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>adminquestions</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<style type="text/css">BODY TD { FONT-SIZE: 12px }
	.zz { FILTER: glow(color=#213a5a,Strength=1); COLOR: #ffffff }
	.front { FONT-WEIGHT: bold; FONT-SIZE: 14px; COLOR: #00258f; FONT-FAMILY: "宋体"; TEXT-DECORATION: none }
	.bfront { FONT-WEIGHT: bold; FONT-SIZE: 14px; COLOR: #ffffff; FONT-FAMILY: "宋体"; TEXT-DECORATION: none }
	.bxfront { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #ffffff; FONT-FAMILY: "宋体"; TEXT-DECORATION: none }
	.frontx { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #00258f; FONT-FAMILY: "宋体"; TEXT-DECORATION: none }
	.STYLE9 { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #133694 }
	.bk2 { BORDER-RIGHT: #8ebeea 1px solid; BORDER-TOP: #8ebeea 1px solid; BORDER-LEFT: #8ebeea 1px solid; BORDER-BOTTOM: #8ebeea 1px solid }
		</style>
	</HEAD>
	<body bgColor="#ecf6f8" leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td style="BORDER-RIGHT: #7dafd4 1px solid; BORDER-TOP: #153693 0px solid; BORDER-LEFT: #153693 0px solid; BORDER-BOTTOM: #153693 0px solid"
						width="11" bgColor="#ecf6f8"><br>
					</td>
					<td style="BORDER-RIGHT: #7dafd4 0px solid; BORDER-TOP: #153693 0px solid; BORDER-LEFT: #e3f1fa 1px solid; BORDER-BOTTOM: #153693 0px solid"
						vAlign="top" bgColor="#cde8fb">
						<table cellSpacing="0" cellPadding="0" width="98%" border="0">
							<tr>
								<td height="8"><FONT face="宋体"></FONT></td>
							</tr>
						</table>
						<table borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="98%" border="2">
							<tr>
								<td style="BORDER-RIGHT: #00258f 1px solid; BORDER-TOP: #00258f 1px solid; BORDER-LEFT: #00258f 1px solid; BORDER-BOTTOM: #00258f 1px solid"
									vAlign="top" align="center" bgColor="#ffffff" height="440">
									<table cellSpacing="0" cellPadding="0" width="98%" align="center" background="../images/a02.jpg"
										border="0">
										<tr>
											<td align="left" width="14"><IMG height="26" src="../images/a01.jpg" width="13"></td>
											<td width="317">
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td style="WIDTH: 21px"><font color="#ffffff"><IMG height="20" src="../images/6.jpg" width="18"></font></td>
														<td><span class="bxfront"><asp:label id="lbl_Title" runat="server"></asp:label></span></td>
													</tr>
												</table>
											</td>
											<td align="right"><IMG height="26" src="../images/a03.jpg" width="12"></td>
										</tr>
									</table>
									<table cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
										<TBODY>
											<tr>
												<td style="BORDER-RIGHT: #c2c2c2 1px solid; BORDER-TOP: #00258f 0px solid; BORDER-LEFT: #c2c2c2 1px solid; BORDER-BOTTOM: #00258f 0px solid"
													vAlign="top" align="center" height="197"><asp:panel id="panel_add" runat="server">
														<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="300" border="1">
															<TR>
																<TD style="WIDTH: 146px" colSpan="3"><FONT face="宋体">
																		<asp:Label id="Label1" runat="server" Height="16px" Width="30px">题型:</asp:Label>
																		<asp:DropDownList id="DDLTx" runat="server" AutoPostBack="True">
																			<asp:ListItem Value="单选题" Selected="True">单选题</asp:ListItem>
																			<asp:ListItem Value="多选题">多选题</asp:ListItem>
																			<asp:ListItem Value="判断题">判断题</asp:ListItem>
																			<asp:ListItem Value="填空题">填空题</asp:ListItem>
																			<asp:ListItem Value="简答题">简答题</asp:ListItem>
																			<asp:ListItem Value="编程题">编程题</asp:ListItem>
																		</asp:DropDownList></FONT></TD>
															</TR>
															<TR>
																<TD colSpan="3"><FONT face="宋体">
																		<asp:Panel id="Panel_dan" runat="server">
																			<FONT face="宋体">
																				<TABLE id="Table1" style="WIDTH: 462px; HEIGHT: 160px" cellSpacing="1" cellPadding="1"
																					width="462" border="1">
																					<TR>
																						<TD style="WIDTH: 67px; HEIGHT: 37px" bgColor="#d6e6ff">题干:</TD>
																						<TD style="HEIGHT: 37px" bgColor="#eaeaea" colSpan="3">
																							<asp:textbox id="TXTdantg" runat="server" Width="371px" TextMode="MultiLine"></asp:textbox></TD>
																					</TR>
																					<TR>
																						<TD style="WIDTH: 67px; HEIGHT: 19px" bgColor="#d6e6ff">选项A:</TD>
																						<TD style="WIDTH: 143px; HEIGHT: 19px" bgColor="#eaeaea"><FONT face="宋体">
																								<asp:textbox id="TXTdanxza" runat="server" Width="144px"></asp:textbox></FONT></TD>
																						<TD style="WIDTH: 75px; HEIGHT: 19px" bgColor="#d6e6ff">选项B:</TD>
																						<TD style="HEIGHT: 19px" bgColor="#eaeaea">
																							<asp:textbox id="TXTdanxzb" runat="server" Width="144px"></asp:textbox></TD>
																					</TR>
																					<TR>
																						<TD style="WIDTH: 67px; HEIGHT: 7px" bgColor="#d6e6ff">选项C:</TD>
																						<TD style="WIDTH: 143px; HEIGHT: 7px" bgColor="#eaeaea">
																							<asp:textbox id="TXTdanxzc" runat="server" Width="142px"></asp:textbox></TD>
																						<TD style="WIDTH: 75px; HEIGHT: 7px" bgColor="#d6e6ff">选项D:</TD>
																						<TD style="HEIGHT: 7px" bgColor="#eaeaea">
																							<asp:textbox id="TXTdanxzd" runat="server" Width="144px"></asp:textbox></TD>
																					</TR>
																					<TR>
																						<TD style="WIDTH: 67px; HEIGHT: 6px" bgColor="#d6e6ff">正确答案:</TD>
																						<TD style="WIDTH: 143px; HEIGHT: 6px" bgColor="#eaeaea">
																							<P><FONT face="宋体">
																									<asp:RadioButtonList id="RBLdanzqda" runat="server" RepeatDirection="Horizontal">
																										<asp:ListItem Value="A">A</asp:ListItem>
																										<asp:ListItem Value="B">B</asp:ListItem>
																										<asp:ListItem Value="C">C</asp:ListItem>
																										<asp:ListItem Value="D">D</asp:ListItem>
																									</asp:RadioButtonList></FONT></P>
																						</TD>
																						<TD style="WIDTH: 75px; HEIGHT: 6px" bgColor="#d6e6ff">所属章节:</TD>
																						<TD style="HEIGHT: 6px" bgColor="#eaeaea">
																							<asp:DropDownList id="DDLdansszj" runat="server" Width="144px"></asp:DropDownList></TD>
																					</TR>
																				</TABLE>
																			</FONT>
																		</asp:Panel></FONT>
																	<asp:Panel id="Panel_duo" runat="server" Visible="False">
																		<FONT face="宋体">
																			<TABLE id="Table3" style="WIDTH: 462px; HEIGHT: 160px" cellSpacing="1" cellPadding="1"
																				width="462" border="1">
																				<TR>
																					<TD style="WIDTH: 67px; HEIGHT: 37px" bgColor="#d6e6ff">题干:</TD>
																					<TD style="HEIGHT: 37px" bgColor="#eaeaea" colSpan="3">
																						<asp:textbox id="TXTduotg" runat="server" Width="371px" TextMode="MultiLine"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 67px; HEIGHT: 19px" bgColor="#d6e6ff">选项A:</TD>
																					<TD style="WIDTH: 143px; HEIGHT: 19px" bgColor="#eaeaea"><FONT face="宋体">
																							<asp:textbox id="TXTduoxza" runat="server" Width="144px"></asp:textbox></FONT></TD>
																					<TD style="WIDTH: 75px; HEIGHT: 19px" bgColor="#d6e6ff">选项B:</TD>
																					<TD style="HEIGHT: 19px" bgColor="#eaeaea">
																						<asp:textbox id="TXTduoxzb" runat="server" Width="144px"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 67px; HEIGHT: 7px" bgColor="#d6e6ff">选项C:</TD>
																					<TD style="WIDTH: 143px; HEIGHT: 7px" bgColor="#eaeaea">
																						<asp:textbox id="TXTduoxzc" runat="server" Width="142px"></asp:textbox></TD>
																					<TD style="WIDTH: 75px; HEIGHT: 7px" bgColor="#d6e6ff">选项D:</TD>
																					<TD style="HEIGHT: 7px" bgColor="#eaeaea">
																						<asp:textbox id="TXTduoxzd" runat="server" Width="144px"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 67px; HEIGHT: 6px" bgColor="#d6e6ff">正确答案:</TD>
																					<TD style="WIDTH: 143px; HEIGHT: 6px" bgColor="#eaeaea">
																						<P><FONT face="宋体">
																								<asp:CheckBoxList id="CBLduozqda" runat="server" RepeatDirection="Horizontal">
																									<asp:ListItem Value="A">A</asp:ListItem>
																									<asp:ListItem Value="B">B</asp:ListItem>
																									<asp:ListItem Value="C">C</asp:ListItem>
																									<asp:ListItem Value="D">D</asp:ListItem>
																								</asp:CheckBoxList></FONT></P>
																					</TD>
																					<TD style="WIDTH: 75px; HEIGHT: 6px" bgColor="#d6e6ff">所属章节:</TD>
																					<TD style="HEIGHT: 6px" bgColor="#eaeaea">
																						<asp:DropDownList id="DDLduosszj" runat="server" Width="144px"></asp:DropDownList></TD>
																				</TR>
																			</TABLE>
																		</FONT>
																	</asp:Panel>
																	<asp:Panel id="Panel_tian" runat="server" Visible="False">
																		<FONT face="宋体">
																			<TABLE id="Table4" style="WIDTH: 462px; HEIGHT: 190px" cellSpacing="1" cellPadding="1"
																				width="462" border="1">
																				<TR>
																					<TD style="WIDTH: 205px; HEIGHT: 37px" bgColor="#d6e6ff">题干:</TD>
																					<TD style="HEIGHT: 37px" bgColor="#eaeaea" colSpan="3">
																						<asp:textbox id="TXTtiantg" runat="server" Width="371px" TextMode="MultiLine"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 205px; HEIGHT: 16px" bgColor="#d6e6ff">填空数</TD>
																					<TD style="WIDTH: 143px; HEIGHT: 16px" bgColor="#eaeaea">
																						<asp:DropDownList id="DDLtiantks" runat="server" Width="136px" AutoPostBack="True">
																							<asp:ListItem Value="1">1</asp:ListItem>
																							<asp:ListItem Value="2">2</asp:ListItem>
																							<asp:ListItem Value="3">3</asp:ListItem>
																							<asp:ListItem Value="4">4</asp:ListItem>
																						</asp:DropDownList></TD>
																					<TD style="WIDTH: 75px; HEIGHT: 16px" bgColor="#d6e6ff">所属章节:</TD>
																					<TD style="HEIGHT: 16px" bgColor="#eaeaea">
																						<asp:DropDownList id="DDLtiansszj" runat="server" Width="144px"></asp:DropDownList></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 205px; HEIGHT: 6px" bgColor="#d6e6ff">正确答案:</TD>
																					<TD style="WIDTH: 450px; HEIGHT: 6px" bgColor="#eaeaea" colSpan="3">
																						<TABLE id="table_tian" style="WIDTH: 376px; HEIGHT: 119px" cellSpacing="1" cellPadding="1"
																							width="376" border="1" runat="server">
																							<TR>
																								<TD style="WIDTH: 43px"><FONT face="宋体">填空1答案</FONT></TD>
																								<TD>
																									<asp:TextBox id="TXTtiankong1" runat="server" Width="320px"></asp:TextBox></TD>
																							</TR>
																							<TR>
																								<TD style="WIDTH: 43px"><FONT face="宋体">填空2答案</FONT></TD>
																								<TD>
																									<asp:TextBox id="TXTtiankong2" runat="server" Width="320px"></asp:TextBox></TD>
																							</TR>
																							<TR>
																								<TD style="WIDTH: 43px; HEIGHT: 28px">填空3答案</TD>
																								<TD style="HEIGHT: 28px">
																									<asp:TextBox id="TXTtiankong3" runat="server" Width="320px"></asp:TextBox></TD>
																							</TR>
																							<TR>
																								<TD style="WIDTH: 43px">填空4答案</TD>
																								<TD>
																									<asp:TextBox id="TXTtiankong4" runat="server" Width="321px"></asp:TextBox></TD>
																							</TR>
																						</TABLE>
																					</TD>
																				</TR>
																			</TABLE>
																		</FONT>
																	</asp:Panel>
																	<asp:Panel id="Panel_pan" runat="server" Visible="False">
																		<FONT face="宋体">
																			<TABLE id="Table5" style="WIDTH: 462px; HEIGHT: 112px" cellSpacing="1" cellPadding="1"
																				width="462" border="1">
																				<TR>
																					<TD style="WIDTH: 67px; HEIGHT: 2px" bgColor="#d6e6ff">题干:</TD>
																					<TD style="HEIGHT: 2px" bgColor="#eaeaea" colSpan="3">
																						<asp:textbox id="TXTpantg" runat="server" Width="371px" TextMode="MultiLine"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 67px; HEIGHT: 6px" bgColor="#d6e6ff">正确答案</TD>
																					<TD style="WIDTH: 143px; HEIGHT: 6px" bgColor="#eaeaea">
																						<asp:DropDownList id="DDLpanzqda" runat="server" Width="136px">
																							<asp:ListItem Value="对">对</asp:ListItem>
																							<asp:ListItem Value="错">错</asp:ListItem>
																						</asp:DropDownList></TD>
																					<TD style="WIDTH: 75px; HEIGHT: 6px" bgColor="#d6e6ff">所属章节:</TD>
																					<TD style="HEIGHT: 6px" bgColor="#eaeaea">
																						<asp:DropDownList id="DDLpansszj" runat="server" Width="144px"></asp:DropDownList></TD>
																				</TR>
																			</TABLE>
																		</FONT>
																	</asp:Panel>
																	<asp:Panel id="Panel_jian" runat="server" Visible="False">
																		<FONT face="宋体">
																			<TABLE id="Table6" style="WIDTH: 462px; HEIGHT: 112px" cellSpacing="1" cellPadding="1"
																				width="462" border="1">
																				<TR>
																					<TD style="WIDTH: 182px; HEIGHT: 37px" bgColor="#d6e6ff">题干:</TD>
																					<TD style="HEIGHT: 37px" bgColor="#eaeaea" colSpan="3">
																						<asp:textbox id="TXTjiantg" runat="server" Height="122px" Width="371px" TextMode="MultiLine"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 182px; HEIGHT: 6px" bgColor="#d6e6ff">正确答案</TD>
																					<TD style="WIDTH: 143px; HEIGHT: 6px" bgColor="#eaeaea" colSpan="3">
																						<asp:textbox id="TXTjianzqda" runat="server" Height="122px" Width="371px" TextMode="MultiLine"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 182px; HEIGHT: 6px" bgColor="#d6e6ff">所属章节:</TD>
																					<TD style="WIDTH: 143px; HEIGHT: 6px" bgColor="#eaeaea" colSpan="3">
																						<asp:DropDownList id="DDLjiansszj" runat="server" Width="144px"></asp:DropDownList></TD>
																				</TR>
																			</TABLE>
																		</FONT>
																	</asp:Panel>
																	<asp:Panel id="Panel_bian" runat="server" Visible="False">
																		<FONT face="宋体">
																			<TABLE id="Table7" style="WIDTH: 462px; HEIGHT: 112px" cellSpacing="1" cellPadding="1"
																				width="462" border="1">
																				<TR>
																					<TD style="WIDTH: 67px; HEIGHT: 37px" bgColor="#d6e6ff">题干:</TD>
																					<TD style="HEIGHT: 37px" bgColor="#eaeaea" colSpan="3">
																						<asp:textbox id="TXTbiantg" runat="server" Height="52px" Width="371px" TextMode="MultiLine"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 67px; HEIGHT: 29px" bgColor="#d6e6ff">正确答案</TD>
																					<TD style="HEIGHT: 29px" bgColor="#eaeaea" colSpan="3">
																						<asp:textbox id="TXTbianzqda" runat="server" Height="204px" Width="371px" TextMode="MultiLine"></asp:textbox></TD>
																				</TR>
																			</TABLE>
																		</FONT>
																	</asp:Panel></TD>
															</TR>
															<TR>
																<TD align="center" colSpan="3">
																	<asp:button id="BTNsave" runat="server" Text="保存"></asp:button>
																	<asp:button id="BTNreset" runat="server" Text="重置"></asp:button>
																	<asp:button id="BTNreturn" runat="server" Width="32px" Text="返回"></asp:button></TD>
															</TR>
														</TABLE>
													</asp:panel>
													<P><FONT face="宋体"></FONT>&nbsp;</P>
												</td>
											</tr>
										</TBODY>
									</table>
									<table cellSpacing="0" cellPadding="0" width="98%" align="center" background="../images/a05.jpg"
										border="0">
										<tr>
											<td vAlign="top"><IMG height="8" src="../images/a04.jpg" width="8"></td>
											<td>
												<div align="right"><IMG height="8" src="../images/a06.jpg" width="8"></div>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						<table cellSpacing="0" cellPadding="0" width="98%" border="0">
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
