<%@ Page language="c#" Codebehind="adminStudents.aspx.cs" AutoEventWireup="false" Inherits="Test.admin.adminstudent" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>adminstudent</title>
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
									<table cellSpacing="0" cellPadding="0" width="98%" align="center" background="../images/a02.jpg"
										border="0">
										<tr>
											<td align="left" width="14"><IMG height="26" src="../images/a01.jpg" width="13"></td>
											<td width="317">
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td style="WIDTH: 17px"><font color="#ffffff"><IMG height="20" src="../images/6.jpg" width="18"></font></td>
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
													vAlign="top" align="center" height="197">
													<P>
														<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="468" border="1" style="WIDTH: 468px; HEIGHT: 373px">
															<TR>
																<TD style="WIDTH: 90px" bgColor="#d6e6ff"><FONT face="宋体">姓名</FONT></TD>
																<TD style="WIDTH: 136px" bgColor="#eaeaea"><FONT face="宋体">
																		<asp:textbox id="TXTxm" runat="server" Width="137px"></asp:textbox></FONT></TD>
																<TD style="WIDTH: 93px" bgColor="#d6e6ff"><FONT face="宋体">学号</FONT></TD>
																<TD bgColor="#eaeaea">
																	<asp:textbox id="TXTxh" runat="server" Width="147px"></asp:textbox></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 90px; HEIGHT: 25px" bgColor="#d6e6ff"><FONT face="宋体">系部</FONT></TD>
																<TD style="WIDTH: 136px; HEIGHT: 25px" bgColor="#eaeaea"><FONT face="宋体">
																		<asp:DropDownList id="DDLxb" runat="server" Width="136px" AutoPostBack="True"></asp:DropDownList></FONT></TD>
																<TD style="WIDTH: 93px; HEIGHT: 25px" bgColor="#d6e6ff"><FONT face="宋体">班级</FONT></TD>
																<TD style="HEIGHT: 25px" bgColor="#eaeaea">
																	<asp:DropDownList id="DDLbj" runat="server" Width="144px"></asp:DropDownList></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 90px" bgColor="#d6e6ff"><FONT face="宋体">密码</FONT></TD>
																<TD style="WIDTH: 136px" bgColor="#eaeaea"><FONT face="宋体">
																		<asp:textbox id="TXTmm" runat="server" Width="136px" TextMode="Password"></asp:textbox></FONT></TD>
																<TD style="WIDTH: 93px" bgColor="#d6e6ff"><FONT face="宋体">密码确认</FONT></TD>
																<TD bgColor="#eaeaea">
																	<asp:textbox id="TXTmmqr" runat="server" Width="147px" TextMode="Password"></asp:textbox></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 90px" bgColor="#d6e6ff"></TD>
																<TD style="WIDTH: 136px" align="right" bgColor="#eaeaea"><FONT face="宋体">
																		<asp:button id="BtnSave" runat="server" Text="添加"></asp:button></FONT></TD>
																<TD style="WIDTH: 93px" bgColor="#eaeaea">
																	<asp:button id="BtnReset" runat="server" Text="重置"></asp:button></TD>
																<TD bgColor="#eaeaea"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 90px" bgColor="#d6e6ff"><FONT face="宋体">数据列表</FONT></TD>
																<TD colspan="3" bgColor="#eaeaea"><FONT face="宋体">
																		<asp:dropdownlist id="DdlSearchKind" runat="server" Width="96px">
																			<asp:ListItem Value="姓名">姓名</asp:ListItem>
																			<asp:ListItem Value="学号">学号</asp:ListItem>
																			<asp:ListItem Value="系别">系别</asp:ListItem>
																			<asp:ListItem Value="班级">班级</asp:ListItem>
																		</asp:dropdownlist></FONT>
																	<asp:textbox id="TxtSearchContent" runat="server" Width="93px"></asp:textbox>
																	<asp:button id="BtnSearch" runat="server" Width="40px" Text="搜索" Height="25px"></asp:button>
																	<asp:button id="BtnAll" runat="server" Width="35px" Text="全部"></asp:button></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 90px" bgColor="#d6e6ff"></TD>
																<TD colspan="3" bgColor="#eaeaea">
																	<asp:datagrid id="Dg_xuesheng" runat="server" Width="385px" Height="250px" AllowSorting="True"
																		DataKeyField="学号" AllowPaging="True" AutoGenerateColumns="False">
																		<Columns>
																			<asp:BoundColumn DataField="姓名" SortExpression="姓名" HeaderText="姓名"></asp:BoundColumn>
																			<asp:BoundColumn DataField="学号" SortExpression="学号" HeaderText="学号"></asp:BoundColumn>
																			<asp:TemplateColumn SortExpression="系部名称" HeaderText="系部">
																				<ItemTemplate>
																					<asp:Label id=Label1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.系部名称") %>'>
																					</asp:Label>
																				</ItemTemplate>
																				<EditItemTemplate>
																					<asp:DropDownList id="DDLdgxb" runat="server" Width="105px" AutoPostBack="True"></asp:DropDownList>
																				</EditItemTemplate>
																			</asp:TemplateColumn>
																			<asp:TemplateColumn SortExpression="班级名称" HeaderText="班级">
																				<ItemTemplate>
																					<asp:Label id=Label2 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.班级名称") %>'>
																					</asp:Label>
																				</ItemTemplate>
																				<EditItemTemplate>
																					<asp:DropDownList id="DDLdgbj" runat="server" Width="105px"></asp:DropDownList>
																				</EditItemTemplate>
																			</asp:TemplateColumn>
																			<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="更新" CancelText="取消" EditText="编辑"></asp:EditCommandColumn>
																			<asp:ButtonColumn Text="删除" CommandName="Delete"></asp:ButtonColumn>
																			<asp:BoundColumn Visible="False" DataField="系部编号" SortExpression="系部编号" HeaderText="系部编号"></asp:BoundColumn>
																			<asp:BoundColumn Visible="False" DataField="班级编号" SortExpression="班级编号" HeaderText="班级编号"></asp:BoundColumn>
																		</Columns>
																	</asp:datagrid></TD>
															</TR>
														</TABLE>
													</P>
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
