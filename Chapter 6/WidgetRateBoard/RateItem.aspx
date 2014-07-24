<%@ Page language="c#" trace="false" Inherits="AddRating.RateItem" CodeFile="RateItem.aspx.cs" AutoEventWireup="true" %>
<%@ Register TagPrefix="cc1" Namespace="IVCS" Assembly="BarChart" %>
<HTML>
	<HEAD>
		<TITLE>Add Your Rating: AddRating.com</TITLE>
		<style>
		body {
	margin:  0px 0px 0px;
	font-size:  12px;
	font-family:  arial,verdana;
	border: none;
}
		</style>
	</HEAD>
	<BODY class="narrow">
		<DIV id="pageHolder">
			<!-- main body area -->
			<DIV class="action" id="DIV1">
				<center><br /><H2>Thank You for Your Rating </font></H2><font size ="3" color=green>
                    <asp:Literal ID="ltlMsg" runat="server"></asp:Literal></font><br />
                    <cc1:barchart id="BarChart1" runat="server" BackColor="White" Width="364px" BorderWidth="1px"
			BorderColor="Gray" Height="150px" Caption="Rate board" ChartColor="SteelBlue" BorderStyle="Dotted"
			Maximum="100">
			</cc1:barchart>
					<asp:Literal id="ltlScore" runat="server"></asp:Literal>
					</center>
				<center><br />	
				<INPUT onclick ="javascript:window.close();" style="cursor: hand" class="button" type="button" value="Close Window"></a>
				<br /></center>
			</DIV> <br/><center>
		</center>
			</DIV>
	</BODY>
</HTML>
