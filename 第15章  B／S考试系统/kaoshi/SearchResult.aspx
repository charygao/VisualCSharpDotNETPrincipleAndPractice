<%@ Page language="c#" Codebehind="SearchResult.aspx.cs" AutoEventWireup="false" Inherits="Test.kaoshi.chaxun" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>chaxun</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
								<td height="8"></td>
							</tr>
						</table>
						<table borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="98%" border="2">
							<tr>
								<td style="BORDER-RIGHT: #00258f 1px solid; BORDER-TOP: #00258f 1px solid; BORDER-LEFT: #00258f 1px solid; BORDER-BOTTOM: #00258f 1px solid"
									vAlign="top" align="center" bgColor="#ffffff" height="440">
									<div align="center">
										<table cellSpacing="0" cellPadding="0" width="98%" align="center" background="../images/a02.jpg"
											border="0">
											<tr>
												<td align="left" width="14"><IMG height="26" src="../images/a01.jpg" width="13"></td>
												<td width="317">
													<table cellSpacing="0" cellPadding="0" width="100%" border="0">
														<tr>
															<td style="WIDTH: 18px"><font color="#ffffff"><IMG height="20" src="../images/6.jpg" width="18"></font></td>
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
														height="197">
														<table cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
															<TBODY>
																<tr>
																	<td style="HEIGHT: 12px" height="12">&nbsp;<FONT face="宋体"></FONT><asp:dropdownlist id="DdlSearchKind" runat="server" Width="72px" Height="24px">
																			<asp:ListItem Value="系部名称">系部</asp:ListItem>
																			<asp:ListItem Value="班级名称">班级</asp:ListItem>
																			<asp:ListItem Value="成绩.学号">学号</asp:ListItem>
																			<asp:ListItem Value="姓名">姓名</asp:ListItem>
																		</asp:dropdownlist><asp:textbox id="TxtSearchContent" runat="server" Width="70px"></asp:textbox><asp:button id="BtnSearch" runat="server" Width="64px" Text="搜索记录" BorderStyle="Groove"></asp:button><asp:button id="BtnAll" runat="server" Width="64px" Text="全部显示" BorderStyle="Groove"></asp:button><FONT face="宋体">&nbsp;</FONT></td>
																</tr>
																<TR>
																	<TD></TD>
																</TR>
																<TR>
																	<TD style="HEIGHT: 340px" align="center"><asp:panel id="Panel_dan" runat="server"><FONT face="宋体">
																				<asp:datagrid id="DG_chengji" runat="server" Width="730px" BorderStyle="None" Font-Size="10pt"
																					PageSize="15" AllowPaging="True" AutoGenerateColumns="False" BorderColor="#8EBEEA" BorderWidth="1px"
																					BackColor="White" CellPadding="2" AllowSorting="True">
																					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
																					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
																					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
																					<HeaderStyle Font-Size="10pt" Font-Bold="True" HorizontalAlign="Center" ForeColor="#133694" BackColor="#CDE8FB"></HeaderStyle>
																					<Columns>
																						<asp:BoundColumn DataField="成绩.学号" SortExpression="成绩.学号" ReadOnly="True" HeaderText="学号"></asp:BoundColumn>
																						<asp:BoundColumn DataField="姓名" SortExpression="姓名" ReadOnly="True" HeaderText="姓名"></asp:BoundColumn>
																						<asp:BoundColumn DataField="得分" SortExpression="得分" ReadOnly="True" HeaderText="成绩"></asp:BoundColumn>
																					</Columns>
																					<PagerStyle PageButtonCount="20" Mode="NumericPages"></PagerStyle>
																				</asp:datagrid></asp:panel></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"><FONT face="宋体"></FONT></FONT><FONT face="宋体"></FONT></TD>
																</TR>
															</TBODY>
														</table>
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
									</div>
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
