function addRatingCallback(obj) {
	var addRatings = obj;
	var str = "";
	var username = "";
	username = addRatings[0].ratings.url
    ratingWidth = addRatings[0].star_image_value * 30 ;
	str +=('<DIV class="rateblock" id="unit_long50" ><UL class="addRating" >');
	str +=('<LI class="current-rating" style="WIDTH: '+ ratingWidth+'px">Currently '+addRatings[0].star_image_value+'/10</LI>');
	str +=('<LI><A class="r1-unit" title="Rate 1 out of 5" onclick="javascript:AddRating(\'1\')" href="javascript:void()">1</A></LI>');
	str +=('<LI><A class="r2-unit" title="Rate 2 out of 5" onclick="javascript:AddRating(\'2\')" href="javascript:void()">2</A></LI>');
	str +=('<LI><A class="r3-unit" title="Rate 3 out of 5" onclick="javascript:AddRating(\'3\')" href="javascript:void()">3</A></LI>');
	str +=('<LI><A class="r4-unit" title="Rate 4 out of 5" onclick="javascript:AddRating(\'4\')" href="javascript:void()">4</A></LI>');
	str +=('<LI><A class="r5-unit" title="Rate 5 out of 5" onclick="javascript:AddRating(\'5\')" href="javascript:void()">5</A></LI>');
	str +=('</UL><FONT face="arial" size="1">Rating: <STRONG>'+addRatings[0].star_image_value+'</STRONG> / '+addRatings[0].ratings.ratedby+' votes </FONT></DIV>');
	
	document.getElementById('addrating_star_info').innerHTML += str;
}

function AddRating(rating,id)
{
    try
    { 
        alert('You Rated: ' + rating + ' \nThank You for your Rating !');
     }
    catch (err)
    {
        alert('If you have installed a popup-blocker, turn it off, or hold down the Ctrl-key, and try again.' + err);
    }
}

