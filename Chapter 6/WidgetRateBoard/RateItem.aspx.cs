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
namespace AddRating
{
	public partial class RateItem: System.Web.UI.Page
	{
     	protected void Page_Load(object sender, System.EventArgs e)
		{
                ltlMsg.Text = "You Rated " + Request.QueryString["Rating"] + "  out of 5 !"; 
                RateItemViewBoard();  
		}
        protected void RateItemViewBoard()
        {
             try
            {
                int myid = Convert.ToInt32(Request.QueryString["id"]);
                string p = "Select * from AddRatings WHERE id = '" + myid + "'";
                AddRating.clsDataAccess myDAR = new AddRating.clsDataAccess();
                myDAR.openConnection();
                System.Data.SqlClient.SqlDataReader mydr = myDAR.getData(p);
                if (mydr.HasRows)
                    {
                        while (mydr.Read())
                        {
                            double myScore = Convert.ToDouble(mydr.GetValue(4).ToString());
                            double myRatedBy = Convert.ToInt32(mydr.GetValue(3).ToString());

                            int star5 = Convert.ToInt32(mydr.GetValue(5).ToString());
                            int star4 = Convert.ToInt32(mydr.GetValue(6).ToString());
                            int star3 = Convert.ToInt32(mydr.GetValue(7).ToString());
                            int star2 = Convert.ToInt32(mydr.GetValue(8).ToString());
                            int star1 = Convert.ToInt32(mydr.GetValue(9).ToString());
                            string Title = mydr.GetValue(2).ToString();

                            int myValidatedRating = Convert.ToInt32(Request.QueryString["Rating"]);
                            if ((myValidatedRating == 1) || (myValidatedRating == 2) || (myValidatedRating == 3) || (myValidatedRating == 4) || (myValidatedRating == 5))
                            {
                                // program logic to update rating
                                double myCRating = Convert.ToDouble(myValidatedRating);
                                double myTotalRating = (myScore + myCRating) / (myRatedBy + 1);
                                int RatedBy = Convert.ToInt32(myRatedBy) + 1;
                                int TRating = Convert.ToInt32(myScore) + myValidatedRating;

                                int currentrating = myValidatedRating;

                                int countadded = 0;
                                if (currentrating == 5) { countadded = star5 = star5 + 1; }
                                if (currentrating == 4) {countadded = star4 = star4 + 1;}
                                if (currentrating == 3) {countadded = star3 = star3 + 1;}
                                if (currentrating == 2) {countadded = star2 = star2 + 1;}
                                if (currentrating == 1) {countadded = star1 = star1 + 1;}

                                string updatestar = "Star" + currentrating + " = '" + countadded + "'";

                                string q = "UPDATE AddRatings SET Score = '" + TRating + "', RatedBy = '" + RatedBy + "', " + updatestar + " WHERE id = '" + myid + "'";
                                AddRating.clsDataAccess myDA = new AddRating.clsDataAccess();
                                myDA.openConnection();
                                myDA.saveData(q);
                                myDA.closeConnection();
                                ShowBarChart(star1, star2, star3, star4, star5, Title);
                            }
                            else
                            {
                                ShowBarChart(star1, star2, star3, star4, star5, Title);
                            }
                        }
                    }
            }
            catch (Exception e)
            {
                Response.WriteFile("Error occured: " + e.Message);
            }
        }
        private void ShowBarChart(int star1, int star2, int star3, int star4, int star5, string Title)
        {
            int maximum = Convert.ToInt32(star1);
            if (maximum < Convert.ToInt32(star2)) maximum = Convert.ToInt32(star2);
            if (maximum < Convert.ToInt32(star3)) maximum = Convert.ToInt32(star3);
            if (maximum < Convert.ToInt32(star4)) maximum = Convert.ToInt32(star4);
            if (maximum < Convert.ToInt32(star5)) maximum = Convert.ToInt32(star5);

                BarChart1.Maximum = maximum;
                BarChart1.Add("1 star", star1);
                BarChart1.Add("2 star", star2);
                BarChart1.Add("3 star", star3);
                BarChart1.Add("4 star", star4, "Average votes", Color.DarkOrange);
                BarChart1.Add("5 star", star5);
                BarChart1.SubTitle = "( " + Title + " )";

        }
	}
}

