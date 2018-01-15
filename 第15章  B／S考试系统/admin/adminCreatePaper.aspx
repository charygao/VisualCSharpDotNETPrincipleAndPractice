<%@ Page language="c#" Codebehind="adminCreatePaper.aspx.cs" AutoEventWireup="false" Inherits="Test.admin.adminzujuan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>adminzujuan</title>
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
														<td style="WIDTH: 14px"><font color="#ffffff"><IMG height="20" src="../images/6.jpg" width="18"></font></td>
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
																<TD colSpan="3"><FONT face="宋体">
																		<asp:Panel id="Panel_txtl" runat="server">
																			<FONT face="宋体">题型及题量设置:
																				<TABLE id="Table1" style="WIDTH: 462px; HEIGHT: 160px" cellSpacing="1" cellPadding="1"
																					width="462" border="1">
																					<TR>
																						<TD style="WIDTH: 102px; HEIGHT: 19px" bgColor="#d6e6ff">单选题量:</TD>
																						<TD style="WIDTH: 116px; HEIGHT: 19px" bgColor="#eaeaea"><FONT face="宋体">
																								<asp:textbox id="TXTdantl" runat="server" Width="129px"></asp:textbox></FONT></TD>
																						<TD style="WIDTH: 116px; HEIGHT: 19px" bgColor="#d6e6ff">单选题每题分值</TD>
																						<TD style="HEIGHT: 19px" bgColor="#eaeaea">
																							<asp:textbox id="TXTdanfz" runat="server" Width="128px"></asp:textbox></TD>
																					</TR>
																					<TR>
																						<TD style="WIDTH: 102px; HEIGHT: 7px" bgColor="#d6e6ff">多选题量:</TD>
																						<TD style="WIDTH: 116px; HEIGHT: 7px" bgColor="#eaeaea">
																							<asp:textbox id="TXTduotl" runat="server" Width="128px"></asp:textbox></TD>
																						<TD style="WIDTH: 116px; HEIGHT: 7px" bgColor="#d6e6ff">多选题每题分值</TD>
																						<TD style="HEIGHT: 7px" bgColor="#eaeaea">
																							<asp:textbox id="TXTduofz" runat="server" Width="128px"></asp:textbox></TD>
																					</TR>
																					<TR>
																						<TD style="WIDTH: 102px; HEIGHT: 6px" bgColor="#d6e6ff">填空题空量:</TD>
																						<TD style="WIDTH: 116px; HEIGHT: 6px" bgColor="#eaeaea">
																							<P><FONT face="宋体">
																									<asp:textbox id="TXTtiankl" runat="server" Width="127px"></asp:textbox></FONT></P>
																						</TD>
																						<TD style="WIDTH: 116px; HEIGHT: 6px" bgColor="#d6e6ff">填空题每空分值:</TD>
																						<TD style="HEIGHT: 6px" bgColor="#eaeaea">
																							<asp:textbox id="TXTtianfz" runat="server" Width="128px"></asp:textbox></TD>
																					</TR>
																					<TR>
																						<TD style="WIDTH: 102px; HEIGHT: 6px" bgColor="#d6e6ff">判断题量:</TD>
																						<TD style="WIDTH: 116px; HEIGHT: 6px" bgColor="#eaeaea">
																							<asp:textbox id="TXTpantl" runat="server" Width="127px"></asp:textbox></TD>
																						<TD style="WIDTH: 116px; HEIGHT: 6px" bgColor="#d6e6ff">判断题每题分值:</TD>
																						<TD style="HEIGHT: 6px" bgColor="#eaeaea">
																							<asp:textbox id="TXTpanfz" runat="server" Width="128px"></asp:textbox></TD>
																					</TR>
																					<TR>
																						<TD style="WIDTH: 102px; HEIGHT: 6px" bgColor="#d6e6ff">简答题量:</TD>
																						<TD style="WIDTH: 116px; HEIGHT: 6px" bgColor="#eaeaea">
																							<asp:textbox id="TXTjiantl" runat="server" Width="127px"></asp:textbox></TD>
																						<TD style="WIDTH: 116px; HEIGHT: 6px" bgColor="#d6e6ff">简答题每题分值</TD>
																						<TD style="HEIGHT: 6px" bgColor="#eaeaea">
																							<asp:textbox id="TXTjianfz" runat="server" Width="128px"></asp:textbox></TD>
																					</TR>
																					<TR>
																						<TD style="WIDTH: 102px; HEIGHT: 6px" bgColor="#d6e6ff">编程题量:</TD>
																						<TD style="WIDTH: 116px; HEIGHT: 6px" bgColor="#eaeaea">
																							<asp:textbox id="TXTbiantl" runat="server" Width="127px"></asp:textbox></TD>
																						<TD style="WIDTH: 116px; HEIGHT: 6px" bgColor="#d6e6ff">编程题每题分值</TD>
																						<TD style="HEIGHT: 6px" bgColor="#eaeaea">
																							<asp:textbox id="TXTbianfz" runat="server" Width="127px"></asp:textbox></TD>
																					</TR>
																					<TR>
																						<TD style="WIDTH: 102px; HEIGHT: 6px" bgColor="#d6e6ff">此类组卷数:</TD>
																						<TD style="WIDTH: 116px; HEIGHT: 6px" bgColor="#eaeaea">
																							<asp:textbox id="TXTzjs" runat="server" Width="127px"></asp:textbox></TD>
																						<TD style="WIDTH: 116px; HEIGHT: 6px" bgColor="#d6e6ff">试卷使用日期</TD>
																						<TD style="HEIGHT: 6px" bgColor="#eaeaea">
																							<asp:textbox id="TXTsjsyrq" runat="server" Width="127px"></asp:textbox></TD>
																					</TR>
																					<TR>
																						<TD style="WIDTH: 102px; HEIGHT: 6px" bgColor="#d6e6ff"></TD>
																						<TD style="WIDTH: 116px; HEIGHT: 6px" bgColor="#eaeaea"></TD>
																						<TD style="WIDTH: 116px; HEIGHT: 6px" bgColor="#d6e6ff">
																							<asp:button id="BtnNext" runat="server" Text="下一步"></asp:button></TD>
																						<TD style="HEIGHT: 6px" bgColor="#eaeaea"></TD>
																					</TR>
																				</TABLE>
																			</FONT>
																		</asp:Panel></FONT>
																	<asp:Panel id="Panel_cqfs" runat="server" Visible="False">
																		<FONT face="宋体">抽取方式:
																			<TABLE id="Table3" style="WIDTH: 462px; HEIGHT: 160px" cellSpacing="1" cellPadding="1"
																				width="462" border="1">
																				<TR>
																					<TD style="WIDTH: 250px; HEIGHT: 37px" bgColor="#d6e6ff"><FONT face="宋体">单选题:(共
																							<asp:Label id="lbl_dan" runat="server" Width="40px"></asp:Label>题,已选
																							<asp:Label id="lbl_dan_yx" runat="server" Width="16px"></asp:Label>题)</FONT></TD>
																					<TD style="HEIGHT: 37px" bgColor="#eaeaea" colSpan="3"><FONT face="宋体">抽取方式
																							<asp:DropDownList id="DDLdancqfs" runat="server" Width="104px" AutoPostBack="True">
																								<asp:ListItem Value="完全随机">完全随机</asp:ListItem>
																								<asp:ListItem Value="控制章节比重" Selected="True">控制章节比重</asp:ListItem>
																							</asp:DropDownList></FONT></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 67px; HEIGHT: 37px" bgColor="#d6e6ff" colSpan="4">
																						<asp:Panel id="Panel_dan" runat="server">
																							<TABLE id="Table9" style="WIDTH: 448px; HEIGHT: 54px" cellSpacing="1" cellPadding="1" width="448"
																								border="1">
																								<TR>
																									<TD style="WIDTH: 35px">章节:</TD>
																									<TD style="WIDTH: 110px">
																										<asp:DropDownList id="DDLdanzj" runat="server" Width="103px"></asp:DropDownList></TD>
																									<TD>题量:</TD>
																									<TD>
																										<asp:TextBox id="TXTdanzjtl" runat="server" Width="50px"></asp:TextBox></TD>
																									<TD>
																										<asp:Button id="BtnAddDan" runat="server" Text="添加"></asp:Button></TD>
																								</TR>
																								<TR>
																									<TD style="WIDTH: 35px" colSpan="5">
																										<asp:datagrid id="Dg_dan" runat="server" Width="440px" Visible="False" PageSize="5" AutoGenerateColumns="False"
																											AllowPaging="True" Height="82px">
																											<Columns>
																												<asp:BoundColumn DataField="章节名称" SortExpression="章节名称" ReadOnly="True" HeaderText="章节名称"></asp:BoundColumn>
																												<asp:BoundColumn DataField="题量" SortExpression="题量" HeaderText="题量"></asp:BoundColumn>
																												<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="更新" CancelText="取消" EditText="编辑"></asp:EditCommandColumn>
																												<asp:ButtonColumn Text="删除" CommandName="Delete"></asp:ButtonColumn>
																												<asp:BoundColumn Visible="False" DataField="章节编号" SortExpression="章节编号" HeaderText="章节编号"></asp:BoundColumn>
																											</Columns>
																										</asp:datagrid></TD>
																								</TR>
																							</TABLE>
																						</asp:Panel></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 250px; HEIGHT: 37px" bgColor="#d6e6ff">多选题: (共
																						<asp:Label id="lbl_duo" runat="server" Width="34px"></asp:Label>题,已选
																						<asp:Label id="lbl_duo_yx" runat="server" Width="56px"></asp:Label>题)</TD>
																					<TD style="HEIGHT: 37px" bgColor="#eaeaea" colSpan="3">抽取方式
																						<asp:DropDownList id="DDLduocqfs" runat="server" Width="104px" AutoPostBack="True">
																							<asp:ListItem Value="完全随机">完全随机</asp:ListItem>
																							<asp:ListItem Value="控制章节比重" Selected="True">控制章节比重</asp:ListItem>
																						</asp:DropDownList></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 67px; HEIGHT: 37px" bgColor="#d6e6ff" colSpan="4">
																						<asp:Panel id="Panel_duo" runat="server">
																							<TABLE id="Table4" style="WIDTH: 451px; HEIGHT: 26px" cellSpacing="1" cellPadding="1" width="451"
																								border="1">
																								<TR>
																									<TD style="WIDTH: 35px; HEIGHT: 28px">章节:</TD>
																									<TD style="WIDTH: 110px; HEIGHT: 28px">
																										<asp:DropDownList id="DDLduozj" runat="server" Width="103px"></asp:DropDownList></TD>
																									<TD style="HEIGHT: 28px">题量:</TD>
																									<TD style="HEIGHT: 28px">
																										<asp:TextBox id="TXTduozjtl" runat="server" Width="50px"></asp:TextBox></TD>
																									<TD style="HEIGHT: 28px">
																										<asp:Button id="BtnAddDuo" runat="server" Text="添加"></asp:Button></TD>
																								</TR>
																								<TR>
																									<TD style="WIDTH: 35px" colSpan="5">
																										<asp:datagrid id="Dg_duo" runat="server" Width="440px" Visible="False" PageSize="5" AutoGenerateColumns="False"
																											AllowPaging="True" Height="76px">
																											<Columns>
																												<asp:BoundColumn DataField="章节名称" SortExpression="章节名称" ReadOnly="True" HeaderText="章节名称"></asp:BoundColumn>
																												<asp:BoundColumn DataField="题量" SortExpression="题量" HeaderText="题量"></asp:BoundColumn>
																												<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="更新" CancelText="取消" EditText="编辑"></asp:EditCommandColumn>
																												<asp:ButtonColumn Text="删除" CommandName="Delete"></asp:ButtonColumn>
																												<asp:BoundColumn Visible="False" DataField="章节编号" SortExpression="章节编号" ReadOnly="True" HeaderText="章节编号"></asp:BoundColumn>
																											</Columns>
																										</asp:datagrid></TD>
																								</TR>
																							</TABLE>
																						</asp:Panel></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 250px; HEIGHT: 37px" bgColor="#d6e6ff">填空题:(共
																						<asp:Label id="lbl_tian" runat="server" Width="58px"></asp:Label>题,已选
																						<asp:Label id="lbl_tian_yx" runat="server" Width="56px"></asp:Label>题)</TD>
																					<TD style="HEIGHT: 37px" bgColor="#eaeaea" colSpan="3">抽取方式
																						<asp:DropDownList id="DDLtiancqfs" runat="server" Width="104px" AutoPostBack="True">
																							<asp:ListItem Value="完全随机">完全随机</asp:ListItem>
																							<asp:ListItem Value="控制章节比重" Selected="True">控制章节比重</asp:ListItem>
																						</asp:DropDownList></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 67px; HEIGHT: 37px" bgColor="#d6e6ff" colSpan="4">
																						<asp:Panel id="Panel_tian" runat="server">
																							<TABLE id="Table5" style="WIDTH: 448px; HEIGHT: 54px" cellSpacing="1" cellPadding="1" width="448"
																								border="1">
																								<TR>
																									<TD style="WIDTH: 35px; HEIGHT: 28px">章节:</TD>
																									<TD style="WIDTH: 110px; HEIGHT: 28px">
																										<asp:DropDownList id="DDLtianzj" runat="server" Width="103px"></asp:DropDownList></TD>
																									<TD style="HEIGHT: 28px">空量:</TD>
																									<TD style="HEIGHT: 28px">
																										<asp:TextBox id="TXTtianzjtl" runat="server" Width="50px"></asp:TextBox></TD>
																									<TD style="HEIGHT: 28px">
																										<asp:Button id="BtnAddTian" runat="server" Text="添加"></asp:Button></TD>
																								</TR>
																								<TR>
																									<TD style="WIDTH: 35px" colSpan="5">
																										<asp:datagrid id="Dg_tian" runat="server" Width="440px" Visible="False" PageSize="5" AutoGenerateColumns="False"
																											AllowPaging="True" Height="76px">
																											<Columns>
																												<asp:BoundColumn DataField="章节名称" SortExpression="章节名称" ReadOnly="True" HeaderText="章节名称"></asp:BoundColumn>
																												<asp:BoundColumn DataField="题量" SortExpression="题量" HeaderText="题量"></asp:BoundColumn>
																												<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="更新" CancelText="取消" EditText="编辑"></asp:EditCommandColumn>
																												<asp:ButtonColumn Text="删除" CommandName="Delete"></asp:ButtonColumn>
																												<asp:BoundColumn Visible="False" DataField="章节编号" SortExpression="章节编号" ReadOnly="True" HeaderText="章节编号"></asp:BoundColumn>
																											</Columns>
																										</asp:datagrid></TD>
																								</TR>
																							</TABLE>
																						</asp:Panel></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 250px; HEIGHT: 37px" bgColor="#d6e6ff">判断题:(共
																						<asp:Label id="lbl_pan" runat="server" Width="40px"></asp:Label>题,已选
																						<asp:Label id="lbl_pan_yx" runat="server" Width="56px"></asp:Label>题)</TD>
																					<TD style="HEIGHT: 37px" bgColor="#eaeaea" colSpan="3">抽取方式
																						<asp:DropDownList id="DDLpancqfs" runat="server" Width="104px" AutoPostBack="True">
																							<asp:ListItem Value="完全随机">完全随机</asp:ListItem>
																							<asp:ListItem Value="控制章节比重" Selected="True">控制章节比重</asp:ListItem>
																						</asp:DropDownList></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 67px; HEIGHT: 37px" bgColor="#d6e6ff" colSpan="4">
																						<asp:Panel id="Panel_pan" runat="server">
																							<TABLE id="Table6" style="WIDTH: 448px; HEIGHT: 54px" cellSpacing="1" cellPadding="1" width="448"
																								border="1">
																								<TR>
																									<TD style="WIDTH: 35px; HEIGHT: 28px">章节:</TD>
																									<TD style="WIDTH: 110px; HEIGHT: 28px">
																										<asp:DropDownList id="DDLpanzj" runat="server" Width="103px"></asp:DropDownList></TD>
																									<TD style="HEIGHT: 28px">题量:</TD>
																									<TD style="HEIGHT: 28px">
																										<asp:TextBox id="TXTpanzjtl" runat="server" Width="50px"></asp:TextBox></TD>
																									<TD style="HEIGHT: 28px">
																										<asp:Button id="BtnAddPan" runat="server" Text="添加"></asp:Button></TD>
																								</TR>
																								<TR>
																									<TD style="WIDTH: 35px" colSpan="5">
																										<asp:datagrid id="Dg_pan" runat="server" Width="440px" Visible="False" PageSize="5" AutoGenerateColumns="False"
																											AllowPaging="True" Height="72px">
																											<Columns>
																												<asp:BoundColumn DataField="章节名称" SortExpression="章节名称" ReadOnly="True" HeaderText="章节名称"></asp:BoundColumn>
																												<asp:BoundColumn DataField="题量" SortExpression="题量" HeaderText="题量"></asp:BoundColumn>
																												<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="更新" CancelText="取消" EditText="编辑"></asp:EditCommandColumn>
																												<asp:ButtonColumn Text="删除" CommandName="Delete"></asp:ButtonColumn>
																												<asp:BoundColumn Visible="False" DataField="章节编号" SortExpression="章节编号" ReadOnly="True" HeaderText="章节编号"></asp:BoundColumn>
																											</Columns>
																										</asp:datagrid></TD>
																								</TR>
																							</TABLE>
																						</asp:Panel></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 250px; HEIGHT: 37px" bgColor="#d6e6ff">简答题:(共
																						<asp:Label id="lbl_jian" runat="server" Width="48px"></asp:Label>题,已选
																						<asp:Label id="lbl_jian_yx" runat="server" Width="56px"></asp:Label>题)</TD>
																					<TD style="HEIGHT: 37px" bgColor="#eaeaea" colSpan="3">抽取方式
																						<asp:DropDownList id="DDLjiancqfs" runat="server" Width="104px" AutoPostBack="True">
																							<asp:ListItem Value="完全随机">完全随机</asp:ListItem>
																							<asp:ListItem Value="控制章节比重" Selected="True">控制章节比重</asp:ListItem>
																						</asp:DropDownList></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 67px; HEIGHT: 19px" bgColor="#d6e6ff" colSpan="4">
																						<asp:Panel id="Panel_jian" runat="server">
																							<TABLE id="Table8" style="WIDTH: 448px; HEIGHT: 54px" cellSpacing="1" cellPadding="1" width="448"
																								border="1">
																								<TR>
																									<TD style="WIDTH: 35px; HEIGHT: 28px">章节:</TD>
																									<TD style="WIDTH: 110px; HEIGHT: 28px">
																										<asp:DropDownList id="DDLjianzj" runat="server" Width="103px"></asp:DropDownList></TD>
																									<TD style="HEIGHT: 28px">题量:</TD>
																									<TD style="HEIGHT: 28px">
																										<asp:TextBox id="TXTjianzjtl" runat="server" Width="50px"></asp:TextBox></TD>
																									<TD style="HEIGHT: 28px">
																										<asp:Button id="BtnAddJian" runat="server" Text="添加"></asp:Button></TD>
																								</TR>
																								<TR>
																									<TD style="WIDTH: 35px" colSpan="5">
																										<asp:datagrid id="Dg_jian" runat="server" Width="440px" Visible="False" PageSize="5" AutoGenerateColumns="False"
																											AllowPaging="True" Height="87px">
																											<Columns>
																												<asp:BoundColumn DataField="章节名称" SortExpression="章节名称" ReadOnly="True" HeaderText="章节名称"></asp:BoundColumn>
																												<asp:BoundColumn DataField="题量" SortExpression="题量" HeaderText="题量"></asp:BoundColumn>
																												<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="更新" CancelText="取消" EditText="编辑"></asp:EditCommandColumn>
																												<asp:ButtonColumn Text="删除" CommandName="Delete"></asp:ButtonColumn>
																												<asp:BoundColumn Visible="False" DataField="章节编号" SortExpression="章节编号" ReadOnly="True" HeaderText="章节编号"></asp:BoundColumn>
																											</Columns>
																										</asp:datagrid></TD>
																								</TR>
																								<TR>
																									<TD style="WIDTH: 462px" align="center" colSpan="5"></TD>
																								</TR>
																							</TABLE>
																						</asp:Panel></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 500px; HEIGHT: 19px" align="center" bgColor="#d6e6ff" colSpan="4">
																						<asp:button id="BtnCreate" runat="server" Text="开始组卷"></asp:button>
																						<asp:button id="BtnPre" runat="server" Text="上一步"></asp:button></TD>
																				</TR>
																			</TABLE>
																		</FONT>
																	</asp:Panel></TD>
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
