<%@ WebHandler Language="C#" Class="RatingHandler" %>

using System;
using System.Web;

public class RatingHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "image/png";
        context.Response.Cache.SetCacheability(HttpCacheability.Public);
        context.Response.BufferOutput = false;
        
        try
        {
            int myid = Convert.ToInt32(context.Request.QueryString["id"]);
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

                        int myValidatedRating = Convert.ToInt32(context.Request.QueryString["Rating"]);
                        if ((myValidatedRating == 1) || (myValidatedRating == 2) || (myValidatedRating == 3) || (myValidatedRating == 4) || (myValidatedRating == 5))
                        {
                        // program logic to update rating

                            double myCRating = Convert.ToDouble(myValidatedRating);
                            double myTotalRating = (myScore + myCRating) / (myRatedBy + 1);

                            int RatedBy = Convert.ToInt32(myRatedBy) + 1;
                            int TRating = Convert.ToInt32(myScore) + myValidatedRating;

                            int currentrating = myValidatedRating;

                            int countadded = 0;
                            if (currentrating == 5) countadded = star5 + 1;
                            if (currentrating == 4) countadded = star4 + 1;
                            if (currentrating == 3) countadded = star3 + 1;
                            if (currentrating == 2) countadded = star2 + 1;
                            if (currentrating == 1) countadded = star1 + 1;

                            string updatestar = "Star" + currentrating + " = '" + countadded + "'";

                            string q = "UPDATE AddRatings SET Score = '" + TRating + "', RatedBy = '" + RatedBy + "', " + updatestar + " WHERE id = '" + myid + "'";
                            AddRating.clsDataAccess myDA = new AddRating.clsDataAccess();
                            myDA.openConnection();
                            myDA.saveData(q);
                            myDA.closeConnection();
                            context.Response.WriteFile("images/ar-done.png");
                        }
                        else
                        {
                            context.Response.WriteFile("images/ar-err.png");
                        }
                    }
                }
        }
       

        catch (Exception)
        {
            context.Response.WriteFile("images/ar-err.png");
        }
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}