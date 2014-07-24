  document.write('<link rel="stylesheet" type="text/css" href="images/star.css">');
  document.write('<div id="aR_data" type="text/JavaScript" src=""></div>');   
  document.write('<script type="text/javascript" src="createRating.js"></script>'); 
  
setTimeout("getJSONData('"+WidgetURL+"')",5000);
function getJSONData(WidgetURL)
{

 var dataElement = document.getElementById('aR_data');
 if (dataElement)
  {
  var JavaScriptCode=document.createElement("script");
  JavaScriptCode.setAttribute('type', 'text/javascript');
  JavaScriptCode.setAttribute("src", 'generateJSON.aspx?callback=addRatingCallback&url='+ escape(WidgetURL) +'&title=' + WidgetTitle);
  dataElement.appendChild(JavaScriptCode);
 }
}
