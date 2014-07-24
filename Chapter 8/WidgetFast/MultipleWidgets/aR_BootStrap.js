if (ratingArray === undefined)
  {
  var ratingArray =1; 
  document.write('<link rel="stylesheet" type="text/css" href="http://addratings.com/images/ar/'+ aR_StarType +'/star.css">');
  document.write('<div id="test'+ ratingArray +'" type="text/JavaScript" src=""></div>');   
  document.write('<script type="text/javascript" src="aR_Create.js"></script>'); 
  }
  else 
  {
  ratingArray  = ratingArray  + 1;
  document.write('<div id="aR_data'+ ratingArray +'" type="text/JavaScript" src=""></div>');   
  }
  
setTimeout("getJSONData('"+aR_url+"')",1250);
function getJSONData(aR_url)
{
 var dataElement = document.getElementById('aR_data'+ratingArray);
 if (dataElement )
  {
  var JavaScriptCode=document.createElement("script");
  JavaScriptCode.setAttribute('type', 'text/javascript');
  JavaScriptCode.setAttribute("src", 'http://addratings.com/generateJSON.aspx?callback=addRatingCallback&url='+ escape(aR_url) +'&title=' + aR_title);
  dataElement.appendChild(JavaScriptCode);
   }
 }
