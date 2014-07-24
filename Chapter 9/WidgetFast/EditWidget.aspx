<%@ Page validateRequest=false language="c#" trace="false" Inherits="AddRating.EditWidget" CodeFile="EditWidget.aspx.cs" %>
<HTML>
	<HEAD>
		<TITLE>Customize Widget Format, Color, and Preview</TITLE>
        <script src="Palette.js" type="text/javascript"></script>
	</HEAD>
	<BODY>
		<DIV id="pageHolder">
			<!-- main body area -->
			<DIV class="action" id="DIV1">
				<center>
					<H2><asp:label id="lblTitle" runat="server">Customize Widget: Format, Color, and Preview</asp:label></H2><br />
					<form runat="server">
						<table width="460" border="0" cellpadding="2" cellspacing="2">
								<TBODY>
								<asp:panel id="panelCustomize" runat="server">	<TR>
										<TD vAlign="top"><font size =3><b>Format</b></font></TD>
										<TD valign=top>
										<table cellpadding=2  border= 0 width=440 ><tr><td>
											<asp:radiobuttonlist id="RadioButtonListStar" runat="server" BackColor="White">
												<asp:ListItem align onClick="setImage(this)" Selected=True Value="0">&nbsp;&nbsp;<img style="width:150px;height:30px;background: url('images/0/star.png') left bottom;" src="images/spacer.gif" border=0"/></asp:ListItem>
												<asp:ListItem onClick="setImage(this)" Value="1">&nbsp;&nbsp;<img style="width:150px;height:30px;background: url('images/1/star.png') left bottom;" src="images/spacer.gif" border=0/> </asp:ListItem>
												<asp:ListItem onClick="setImage(this)" Value="2">&nbsp;&nbsp;<img style="width:150px;height:30px;background: url('images/2/star.png') left bottom;" src="images/spacer.gif" border=0/> </asp:ListItem>
												<asp:ListItem onClick="setImage(this)" Value="3">&nbsp;&nbsp;<img style="width:150px;height:30px;background: url('images/3/star.png') left bottom;" src="images/spacer.gif" border=0/> </asp:ListItem>
												<asp:ListItem onClick="setImage(this)" Value="4">&nbsp;&nbsp;<img style="width:150px;height:30px;background: url('images/4/star.png') left bottom;" src="images/spacer.gif" border=0/> </asp:ListItem>
												</asp:radiobuttonlist>
											</td>
											<td valign = top>
											<table border= 0 cellpadding = 3 style="BACKGROUND-COLOR:rgb(204, 255, 204)">
											<TR>
													<TD colSpan="2" valign= top>
														<font size =3><b>Preview</b></font>
														<DIV id="testArea" align="center" style="width:150px; padding: 5px;">
														<div id="starImage"><div style="width:150px;height:30px;background: url('images/0/star.png') left bottom;"> &nbsp;</div></div>99 Ratings</DIV>
														<font size=1 face = verdana>Full preview is on the next page</font>
													</TD>
												</TR>
											</table>
											</td></tr></table>
											</TD>
									</TR>
									
									<TR style="PADDING-TOP: 0px">
										<TD vAlign="top"><font size =3><b>Color</b></font></TD>
										<TD style="PADDING-TOP: 0px" vAlign="top" width="84%">
											<TABLE id="Table1" cellSpacing="1" width="420" border="0"> <!--Create Table for Web safe colors -->
												<TR>
													<TD style="PADDING-TOP: 0px" colSpan="3">
														<DIV id="colorTable" style="PADDING-TOP: 0px">
															<SCRIPT type="text/javascript">
																	document.write(createTable());
															</SCRIPT>
														</DIV>
													</TD>
												</TR> <!--On click set the colors -->
												<TR>
													<TD>
													<INPUT onclick="setColorType('blank');" type="radio" CHECKED value="blank" name="colorControl">Transparent</INPUT>
													</td><td><INPUT onclick="setColorType('back');" type="radio" value="back" name="colorControl">Set background color</INPUT>
													</td><td><INPUT onclick="setColorType('fore');" type="radio"  value="fore" name="colorControl">Set font color</INPUT></TD>
												</TR>
												<TR>
													<td></td><TD id="background">
														<asp:TextBox id="txtBGColor" runat="server"></asp:TextBox></TD>
													<TD id="foreground">
														<asp:TextBox id="txtFGColor" runat="server"></asp:TextBox></TD>
												</TR><TR>
													<TD colspan=3>To create a transparent Widget which uses web page background color and web page's text foreground color leave the fields blank</TD>
												</TR>
												<!--The content block for WYSIWYG -->
												
											</TABLE>
										</TD>
									</TR>
									<TR>
										<TD align="center" colSpan="2">
											<asp:Label id="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label></TD>
									</TR>
									<TR>
										<TD align="center" colSpan="2">&nbsp;<asp:button id="btnGetCode" runat="server" Text="Get Widget Code" onclick="btnGetCode_Click"></asp:button>&nbsp;</TD>
									</TR>
							</asp:panel>
							    <asp:panel id="panelWidgetCode" runat="server">
								<TR>
									<TD align="left" colSpan="2" valign=top><h3>Preview</h3>
										<asp:Literal id="ltlCode" runat="server"></asp:Literal></TD>
								</TR><TR>
									<TD align="left" colSpan="2"><h3>Code you need</h3>
											<P>Copy and paste the Widget Code in the web page to add Rating Feature.</P>
											</TD>
								</TR>
								
								<TR>
									<TD align="center" colSpan="2">
										<asp:textbox id="TextBoxWidgetCode" ReadOnly="true" onclick="JavaScript:this.select();" runat="server" TextMode="MultiLine"
											Columns="55" Rows="25" Height="280px" Width="500px"></asp:textbox><br>
											</TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2">
										<asp:button id="btnCustomize" runat="server" Text="Go Back" onclick="btnCustomize_Click"></asp:button>&nbsp;&nbsp;
										</TR>
							</asp:panel>
							</TBODY></table>
					</form>
				</center>
			</DIV> 
</DIV> 
</BODY>
</HTML>
