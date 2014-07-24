function addRatingCallback(obj) {
	var aR = obj;
	var sH = "";
	var myID = aR[0].id;
	
	rW = aR[0].star_image_value * 30 ;
	sH +=('<div id="AddRatingsWidget'+myID + '" style="WIDTH:150px;BACKGROUND-COLOR:'+ aR_BgColor +';COLOR:' + aR_FgColor + ';" align="center">');
	sH +=('<DIV class="r-b" style ="border:0;" title="Current Rating"><UL class="a-r" STYLE="padding:0 0 0 0;border:0;margin:0 0 0 0;">');
	sH +=('<LI class="c-r" style="WIDTH: '+ rW+'px;padding:0 0 0 0;"></LI>');
	sH +=('<LI><A class="r1" onclick="AR(\'1\',\''+myID+'\',\''+aR[0].ratings.score+'\',\''+aR[0].ratings.ratedby+'\');return false;" href="javascript:void();">1</A></LI>');
	sH +=('<LI><A class="r2" onclick="AR(\'2\',\''+myID+'\',\''+aR[0].ratings.score+'\',\''+aR[0].ratings.ratedby+'\');return false;" href="javascript:void();">2</A></LI>');
	sH +=('<LI><A class="r3" onclick="AR(\'3\',\''+myID+'\',\''+aR[0].ratings.score+'\',\''+aR[0].ratings.ratedby+'\');return false;" href="javascript:void();">3</A></LI>');
	sH +=('<LI><A class="r4" onclick="AR(\'4\',\''+myID+'\',\''+aR[0].ratings.score+'\',\''+aR[0].ratings.ratedby+'\');return false;" href="javascript:void();">4</A></LI>');
	sH +=('<LI><A class="r5" onclick="AR(\'5\',\''+myID+'\',\''+aR[0].ratings.score+'\',\''+aR[0].ratings.ratedby+'\');return false;" href="javascript:void();">5</A></LI>');
	sH +=('</UL><CENTER>'+aR[0].star_image_value+' / '+aR[0].ratings.ratedby+' votes </CENTER></DIV>');
	sH +=('</div>');
	
	document.getElementById('aR_star_info').setAttribute("id",'aR_star_info'+myID);
	document.getElementById('aR_star_info'+myID).innerHTML = sH;
}
function AR(r,id,sc,rb)
{
        if ((r==1)||(r==2)||(r==3)||(r==4)||(r==5))
        {
        var Sc = parseInt(sc) + parseInt(r);
        var RB = parseInt(rb)+1;
        var oR =Sc/RB ;
        
        if ((oR <1)&&(oR>0)) oR = ".5";
		else if (oR ==1.0) oR = "1";
		else if ((oR >1)&&(oR<2)) oR = "1.5";
		else if (oR ==2.0) oR = "2";
		else if ((oR >2)&&(oR<3)) oR = "2.5";
		else if (oR ==3.0) oR = "3";
		else if ((oR >3)&&(oR<4)) oR = "3.5";
		else if (oR ==4.0) oR = "4";
		else if ((oR >4)&&(oR<5)) oR = "4.5";
		else if (oR ==5.0) oR = "5";
		else if (oR ==0.0) oR = "0";
        var rW = oR * 30; 
        
        var sH = "";
        
        sH +=('<DIV class="r-b" style ="border:0;" title="Current Rating"><UL class="a-r" STYLE="padding:0 0 0 0;border:0;margin:0 0 0 0;">');
	    sH +=('<LI class="c-r" style="WIDTH: '+ rW+'px;padding:0 0 0 0;"></LI>');
	    sH +=('</UL><CENTER>'+oR+' / '+RB+' votes <A target="_blank" href="http://addrating.com" title="Get FREE Rating Widget at AddRating.com"><img alt="Get your FREE Rating Widget at AddRatings.com" border="0" width="14px" height="14px" src="http://addratings.com/RatingHandler.ashx?id='+id+'&Rating='+r+'"></a></CENTER></DIV>');
	    document.getElementById('aR_star_info' + id).innerHTML = sH;
	    }
}   