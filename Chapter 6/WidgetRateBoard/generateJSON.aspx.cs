using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Text.RegularExpressions;
using System.Data.SqlClient;  
namespace AddRating
{
	public partial class generateJSON : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			int RatedBy = 0;
			int Score = 0;
			int StarType = 0;
			int Star5 =0;
			int Star4 =0;
			int Star3 =0;
			int Star2 =0;
			int Star1 =0;
			string myTotalRatingString = "";
			string Star_Image_Url="";
			string Url="";
			DateTime DateAdded= DateTime.Now;
			DateTime DateModified = DateTime.Now;
			string Text ="Title";
            string user_RatingURL ="";
            string user_PageTitle = "";
            int user_StarType = 0; 
            int myid = 0;

            if (Request.QueryString["title"] != null)
            {
                user_PageTitle = Request.QueryString["title"];
                user_PageTitle = Server.HtmlEncode(user_PageTitle);
            }
            if (Request.QueryString["url"] != null)
            {
                user_RatingURL = Request.QueryString["url"];
                user_RatingURL = Server.HtmlEncode(user_RatingURL);
            }
                            
                
			    if (Request.QueryString["id"]!= null)
				myid= Convert.ToInt32(Request.QueryString["id"]);

                string query = "";

                if (myid !=0)    
                    query = "SELECT * FROM AddRatings WHERE ID=" + myid ;  
                else
                    query = "SELECT * FROM AddRatings WHERE URL='" + user_RatingURL +"'";  
                
				clsDataAccess mydataAccess  = new clsDataAccess();
				mydataAccess.openConnection();
				SqlDataReader mydr = mydataAccess.getData(query);
				StringBuilder AddRatingsJSON = new StringBuilder();
                if (mydr.HasRows)
                        {
                            while (mydr.Read())
                            {
                                myid = Convert.ToInt32(mydr.GetValue(0));
                                RatedBy = Convert.ToInt32(mydr.GetValue(3));
                                Score = Convert.ToInt32(mydr.GetValue(4));

                                double myScore = Convert.ToDouble(Score);
                                double myRatedBy = Convert.ToDouble(RatedBy);
                                double ORating = 0.0;

                                if (myRatedBy > 0)
                                    ORating = myScore / myRatedBy;

                                if ((ORating < 1) && (ORating > 0))
                                    myTotalRatingString = ".5";
                                else if (ORating == 1.0)
                                    myTotalRatingString = "1";
                                else if ((ORating > 1) && (ORating < 2))
                                    myTotalRatingString = "1.5";
                                else if (ORating == 2.0)
                                    myTotalRatingString = "2";
                                else if ((ORating > 2) && (ORating < 3))
                                    myTotalRatingString = "2.5";
                                else if (ORating == 3.0)
                                    myTotalRatingString = "3";
                                else if ((ORating > 3) && (ORating < 4))
                                    myTotalRatingString = "3.5";
                                else if (ORating == 4.0)
                                    myTotalRatingString = "4";
                                else if ((ORating > 4) && (ORating < 5))
                                    myTotalRatingString = "4.5";
                                else if (ORating == 5.0)
                                    myTotalRatingString = "5";
                                else if (ORating == 0.0)
                                    myTotalRatingString = "0";

                                Star5 = Convert.ToInt32(mydr.GetValue(5));
                                Star4 = Convert.ToInt32(mydr.GetValue(6));
                                Star3 = Convert.ToInt32(mydr.GetValue(7));
                                Star2 = Convert.ToInt32(mydr.GetValue(8));
                                Star1 = Convert.ToInt32(mydr.GetValue(9));
                                StarType = Convert.ToInt32(mydr.GetValue(10));
                            
                                Url = mydr.GetValue(1).ToString();
                                DateAdded = Convert.ToDateTime(mydr.GetValue(11));
                                DateModified = Convert.ToDateTime(mydr.GetValue(12));
                                Text = mydr.GetValue(2).ToString();
                            }
                        }
                        else
                        {
                            clsDataAccess myda = new clsDataAccess();
                            myda.openConnection();
                            myid = myda.CreateNewItemRate(user_PageTitle, user_RatingURL);
                         
                        }
			
						mydr.Close();
						mydataAccess.closeConnection(); 

						AddRatingsJSON.Append("addRatingCallback");
						AddRatingsJSON.Append("([");
						AddRatingsJSON.Append("{\"ratings\":");
						AddRatingsJSON.Append("{");
						AddRatingsJSON.Append("\"ratedby\":\"" + RatedBy + "\",");
						AddRatingsJSON.Append("\"score\":\"" + Score + "\",");
						AddRatingsJSON.Append("\"startype\":\"" + StarType + "\",");
						AddRatingsJSON.Append("\"star5\":\"" + Star5 + "\",");
						AddRatingsJSON.Append("\"star4\":\"" + Star4 + "\",");
						AddRatingsJSON.Append("\"star3\":\"" + Star3 + "\",");
						AddRatingsJSON.Append("\"star2\":\"" + Star2 + "\",");
						AddRatingsJSON.Append("\"star1\":\"" + Star1 + "\",");
						AddRatingsJSON.Append("\"protected\":false");
						AddRatingsJSON.Append("},");
						AddRatingsJSON.Append("\"star_image_url\":\"" + Star_Image_Url + "\",");
						AddRatingsJSON.Append("\"star_image_value\":\"" + myTotalRatingString + "\",");
						AddRatingsJSON.Append("\"url\":\"" + Url + "\",");
						AddRatingsJSON.Append("\"dateadded\":\"" + DateAdded  + "\",");
						AddRatingsJSON.Append("\"datemodified\":\"" + DateModified + "\",");
						AddRatingsJSON.Append("\"text\":\"" + Text + "\",");
						AddRatingsJSON.Append("\"id\":\"" + myid + "\"");
						AddRatingsJSON.Append("}");
						AddRatingsJSON.Append("]);");
			
			Response.Write(AddRatingsJSON); 
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			InitializeComponent();
			base.OnInit(e);
		}
		
		private void InitializeComponent()
		{    
		}
		#endregion
	}
}
