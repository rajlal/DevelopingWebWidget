using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Text;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;  
using System.Configuration; 
using System.Text.RegularExpressions;    


namespace AddRating
{
	public partial class EditWidget : System.Web.UI.Page
	{
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
					panelWidgetCode.Visible = false; 
			}
		}
        protected void btnGetCode_Click(object sender, System.EventArgs e)
		{
            createWidgetCode();
		}
		private void createWidgetCode()
		{
			StringBuilder sbWC= new StringBuilder();
            string WString = "";
			
                WString = sbWC.Append(@"<!-- Begin AddRating.com widget code -->" + Environment.NewLine)
                              .Append(@"<script type='text/javascript'>" + Environment.NewLine)
                              .Append("var WidgetBackgroundColor=\"" + txtBGColor.Text + "\";" + Environment.NewLine)
                              .Append("var WidgetForegroundColor=\"" + txtFGColor.Text + "\";" + Environment.NewLine)
                              .Append(@"WidgetURL=location.href;" + Environment.NewLine)
                              .Append(@"WidgetStarType ='" + RadioButtonListStar.SelectedValue + "';" + Environment.NewLine)
                              .Append("document.write('<link rel=\"stylesheet\" type=\"text/css\" href=\"images/'+ WidgetStarType +'/star.css\">');" + Environment.NewLine)
                              .Append("document.write('<div id=\"addrating_star_info\" style=\"height:60px;\"></div>');" + Environment.NewLine)
                              .Append("document.write('<scr'+'ipt type=\"text/javascript\" src=\"createRating.js\"></scr' + 'ipt>');" + Environment.NewLine)
                              .Append("document.write('<scr'+'ipt text=\"text/javascript\" src=\"generateJSON.aspx?callback=addRatingCallback&url='+ WidgetURL +'\"</scr' + 'ipt>');" + Environment.NewLine)
                              .Append(@"</script>" + Environment.NewLine)
                              .Append(@"<!-- End AddRating.com widget code -->")
                              .ToString();       
    		
            TextBoxWidgetCode.Rows = 15;
            TextBoxWidgetCode.Text = WString;
            ltlCode.Text = WString + "";
			panelCustomize.Visible = false; 
			panelWidgetCode.Visible = true; 
			lblTitle.Text = "Get Widget Code";
		}
        protected void btnCustomize_Click(object sender, System.EventArgs e)
		{
			TextBoxWidgetCode.Text = "";
			ltlCode.Text  = "";
			panelWidgetCode.Visible = false; 
			panelCustomize.Visible = true;
            lblTitle.Text = "Customize Widget: Format, Color, and Preview";
		}
	}
}

