<%@ Page language="c#" Codebehind="adminJudge.aspx.cs" AutoEventWireup="false" Inherits="Test.admin.adminpanjuan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>adminpanjuan</title>
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
															<td style="WIDTH: 20px"><font color="#ffffff"><IMG height="20" src="../images/6.jpg" width="18"></font></td>
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
																	<td height="4"><FONT face="宋体"></FONT></td>
																</tr>
																<TR>
																	<TD height="8"><FONT face="宋体"></FONT></TD>
																</TR>
																<tr>
																	<td style="HEIGHT: 19px" height="19">&nbsp;
																		<asp:dropdownlist id="DDLtixing" runat="server" Width="66px" AutoPostBack="True">
																			<asp:ListItem Value="填空题" Selected="True">填空题</asp:ListItem>
																			<asp:ListItem Value="简答题">简答题</asp:ListItem>
																			<asp:ListItem Value="编程题">编程题</asp:ListItem>
																		</asp:dropdownlist><FONT face="宋体"></FONT><asp:dropdownlist id="DdlSearchKind" runat="server" Width="75px" Height="24px">
																			<asp:ListItem Value="系部名称">系部名称</asp:ListItem>
																			<asp:ListItem Value="班级名称">班级名称</asp:ListItem>
																			<asp:ListItem Value="答卷.学号">学号</asp:ListItem>
																			<asp:ListItem Value="姓名">姓名</asp:ListItem>
																			<asp:ListItem Value="题干">题干</asp:ListItem>
																			<asp:ListItem Value="使用日期">考试日期</asp:ListItem>
																		</asp:dropdownlist><asp:dropdownlist id="DdlSelectcondition" runat="server" Width="64px">
																			<asp:ListItem Value="like">类似于</asp:ListItem>
																			<asp:ListItem Value="&gt;">大于</asp:ListItem>
																			<asp:ListItem Value="&gt;=">大于等于</asp:ListItem>
																			<asp:ListItem Value="&lt;">小于</asp:ListItem>
																			<asp:ListItem Value="&lt;=">小于等于</asp:ListItem>
																			<asp:ListItem Value="=">等于</asp:ListItem>
																			<asp:ListItem Value="&lt;&gt;">不等于</asp:ListItem>
																		</asp:dropdownlist><asp:textbox id="TxtSearchContent" runat="server" Width="70px" Height="24px"></asp:textbox><asp:dropdownlist id="DdlConnect" runat="server" Width="41px" Height="24px">
																			<asp:ListItem Selected="True"></asp:ListItem>
																			<asp:ListItem Value="and">并且</asp:ListItem>
																			<asp:ListItem Value="or">或者</asp:ListItem>
																		</asp:dropdownlist><asp:button id="BtnAdd" runat="server" Width="60px" BorderStyle="Groove" Text="增加条件"></asp:button><asp:button id="BtnReset" runat="server" Width="60px" BorderStyle="Groove" Text="重置条件"></asp:button><asp:button id="BtnSearch" runat="server" Width="59px" BorderStyle="Groove" Text="搜索记录"></asp:button><asp:button id="BtnAll" runat="server" Width="60px" BorderStyle="Groove" Text="全部显示"></asp:button><asp:button id="btn_Complete" runat="server" Width="100px" BorderStyle="Groove" Text="结束判卷,出成绩"></asp:button></td>
																</tr>
																<TR>
																	<TD><asp:label id="lbl_S_Title" runat="server" CssClass="front">搜索条件：</asp:label><asp:listbox id="DdlSelected" runat="server" Width="628px" Height="26px" Rows="2"></asp:listbox></TD>
																</TR>
																<TR>
																	<TD style="HEIGHT: 340px" align="center"><asp:panel id="Panel_dan" runat="server"><FONT face="宋体">
																				<asp:datagrid id="DG_tian" runat="server" Width="100%" BorderStyle="None" Font-Size="10pt" PageSize="15"
																					AllowPaging="True" AutoGenerateColumns="False" BorderColor="#8EBEEA" BorderWidth="1px" BackColor="White"
																					CellPadding="2" AllowSorting="True" DataKeyField="dati_id">
																					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
																					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
																					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
																					<HeaderStyle Font-Size="10pt" Font-Bold="True" HorizontalAlign="Center" ForeColor="#133694" BackColor="#CDE8FB"></HeaderStyle>
																					<Columns>
																						<asp:BoundColumn DataField="使用日期" SortExpression="使用日期" ReadOnly="True" HeaderText="考试日期" DataFormatString="{0:d}"></asp:BoundColumn>
																						<asp:BoundColumn DataField="系部名称" SortExpression="系部名称" ReadOnly="True" HeaderText="系部名称"></asp:BoundColumn>
																						<asp:BoundColumn DataField="班级名称" SortExpression="班级名称" ReadOnly="True" HeaderText="班级名称"></asp:BoundColumn>
																						<asp:BoundColumn DataField="答卷.学号" SortExpression="答卷.学号" ReadOnly="True" HeaderText="学号"></asp:BoundColumn>
																						<asp:BoundColumn DataField="姓名" SortExpression="姓名" ReadOnly="True" HeaderText="姓名"></asp:BoundColumn>
																						<asp:BoundColumn DataField="题干" SortExpression="题干" ReadOnly="True" HeaderText="题干"></asp:BoundColumn>
																						<asp:BoundColumn DataField="学生答案" SortExpression="学生答案" ReadOnly="True" HeaderText="学生答案"></asp:BoundColumn>
																						<asp:BoundColumn DataField="填空1答案" SortExpression="填空1答案" ReadOnly="True" HeaderText="空1正答"></asp:BoundColumn>
																						<asp:BoundColumn DataField="填空2答案" SortExpression="填空2答案" ReadOnly="True" HeaderText="空2正答"></asp:BoundColumn>
																						<asp:BoundColumn DataField="填空3答案" SortExpression="填空3答案" ReadOnly="True" HeaderText="空3正答"></asp:BoundColumn>
																						<asp:BoundColumn DataField="填空4答案" SortExpression="填空4答案" ReadOnly="True" HeaderText="空4正答"></asp:BoundColumn>
																						<asp:BoundColumn DataField="填空题每空分值" SortExpression="填空题每空分值" ReadOnly="True" HeaderText="分值">
																							<HeaderStyle Width="80px"></HeaderStyle>
																						</asp:BoundColumn>
																						<asp:BoundColumn DataField="得分" SortExpression="得分" HeaderText="得分"></asp:BoundColumn>
																						<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="更新" CancelText="取消" EditText="给分"></asp:EditCommandColumn>
																					</Columns>
																					<PagerStyle PageButtonCount="20" Mode="NumericPages"></PagerStyle>
																				</asp:datagrid></asp:panel></FONT><FONT face="宋体"></FONT><asp:panel id="Panel2" runat="server"><FONT face="宋体"></asp:panel></FONT><asp:panel id="Panel3" runat="server"><FONT face="宋体">
																				<asp:datagrid id="DG_jian" runat="server" Width="100%" BorderStyle="None" Font-Size="10pt" PageSize="15"
																					AllowPaging="True" AutoGenerateColumns="False" BorderColor="#8EBEEA" BorderWidth="1px" BackColor="White"
																					CellPadding="2" AllowSorting="True" DataKeyField="dati_id">
																					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
																					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
																					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
																					<HeaderStyle Font-Size="10pt" Font-Bold="True" HorizontalAlign="Center" ForeColor="#133694" BackColor="#CDE8FB"></HeaderStyle>
																					<Columns>
																						<asp:BoundColumn DataField="使用日期" SortExpression="使用日期" ReadOnly="True" HeaderText="考试日期" DataFormatString="{0:d}"></asp:BoundColumn>
																						<asp:BoundColumn DataField="系部名称" SortExpression="系部名称" ReadOnly="True" HeaderText="系部名称"></asp:BoundColumn>
																						<asp:BoundColumn DataField="班级名称" SortExpression="班级名称" ReadOnly="True" HeaderText="班级名称"></asp:BoundColumn>
																						<asp:BoundColumn DataField="答卷.学号" SortExpression="答卷.学号" ReadOnly="True" HeaderText="学号"></asp:BoundColumn>
																						<asp:BoundColumn DataField="题干" SortExpression="题干" ReadOnly="True" HeaderText="题干"></asp:BoundColumn>
																						<asp:BoundColumn DataField="学生答案" SortExpression="学生答案" ReadOnly="True" HeaderText="学生答案"></asp:BoundColumn>
																						<asp:BoundColumn DataField="正确答案" SortExpression="正确答案" ReadOnly="True" HeaderText="正确答案"></asp:BoundColumn>
																						<asp:BoundColumn DataField="简答题每题分值" SortExpression="简答题每题分值" ReadOnly="True" HeaderText="分值"></asp:BoundColumn>
																						<asp:BoundColumn DataField="得分" SortExpression="得分" HeaderText="得分"></asp:BoundColumn>
																						<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="更新" CancelText="取消" EditText="给分"></asp:EditCommandColumn>
																					</Columns>
																					<PagerStyle PageButtonCount="20" Mode="NumericPages"></PagerStyle>
																				</asp:datagrid></asp:panel></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"><asp:panel id="Panel4" runat="server"><FONT face="宋体">
																					<asp:datagrid id="DG_bian" runat="server" Width="100%" BorderStyle="None" Font-Size="10pt" PageSize="15"
																						AllowPaging="True" AutoGenerateColumns="False" BorderColor="#8EBEEA" BorderWidth="1px" BackColor="White"
																						CellPadding="2" AllowSorting="True" DataKeyField="dati_id">
																						<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
																						<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
																						<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
																						<HeaderStyle Font-Size="10pt" Font-Bold="True" HorizontalAlign="Center" ForeColor="#133694" BackColor="#CDE8FB"></HeaderStyle>
																						<Columns>
																							<asp:BoundColumn DataField="使用日期" SortExpression="使用日期" ReadOnly="True" HeaderText="考试日期" DataFormatString="{0:d}"></asp:BoundColumn>
																							<asp:BoundColumn DataField="系部名称" SortExpression="系部名称" ReadOnly="True" HeaderText="系部名称"></asp:BoundColumn>
																							<asp:BoundColumn DataField="班级名称" SortExpression="班级名称" ReadOnly="True" HeaderText="班级名称"></asp:BoundColumn>
																							<asp:BoundColumn DataField="答卷.学号" SortExpression="答卷.学号" ReadOnly="True" HeaderText="学号"></asp:BoundColumn>
																							<asp:BoundColumn DataField="题干" SortExpression="题干" ReadOnly="True" HeaderText="题干"></asp:BoundColumn>
																							<asp:BoundColumn DataField="学生答案" SortExpression="学生答案" ReadOnly="True" HeaderText="学生答案"></asp:BoundColumn>
																							<asp:BoundColumn DataField="正确答案" SortExpression="正确答案" ReadOnly="True" HeaderText="正确答案"></asp:BoundColumn>
																							<asp:BoundColumn DataField="简答题每题分值" SortExpression="简答题每题分值" ReadOnly="True" HeaderText="分值"></asp:BoundColumn>
																							<asp:BoundColumn DataField="得分" SortExpression="得分" HeaderText="得分"></asp:BoundColumn>
																							<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="更新" CancelText="取消" EditText="给分"></asp:EditCommandColumn>
																						</Columns>
																						<PagerStyle PageButtonCount="20" Mode="NumericPages"></PagerStyle>
																					</asp:datagrid></asp:panel></FONT></FONT><FONT face="宋体"></FONT></TD>
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
