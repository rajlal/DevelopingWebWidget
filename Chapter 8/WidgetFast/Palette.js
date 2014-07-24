    function createTable(){
    // web safe colors  
    var colors = new Array('00','33','66','99','CC','FF');
    var tableText = '<table border=1 cellpadding=0 cellspacing=0><tr><td><table width=420 height=100  cellpadding="2">';
    for(i=0;i<6;i++){
    tableText += '<tr>';
	    for(j=0;j<6;j++){
		    for(k=0;k<6;k++){
			    var color = colors[i]+colors[j]+colors[k];
			    if(i<4&&j<4&&k<4){
				    tableText += '<td width=70 onClick="setColor(this)" style="color:white;cursor: hand;cursor: pointer;background-color:#' + color + ';"  height=12></td>';
			    }else{
				    tableText += '<td width=70 onClick="setColor(this)" style="cursor: hand;cursor: pointer;background-color:#' + color + ';"  height=12 ></td>';
			    }
		    }
	    }
		    tableText += '</tr>';
    }
    tableText += '</table></td></tr>';
    // Grey shades
    tableText += '<tr><td><table width=420 height=20  cellpadding="0" cellspacing="0" border="0">';
    for(i=0;i<1;i++){
    tableText += '<tr>';
	    for(j=0;j<6;j++){
		    for(k=0;k<6;k++){
			    var color = colors[j]+colors[j]+colors[j];
			    if(i<4&&j<4&&k<4){
				    tableText += '<td width=70 onClick="setColor(this)" style="color:white;cursor: hand;cursor: pointer;background-color:#' + color + ';"  height=12></td>';
			    }else{
				    tableText += '<td width=70 onClick="setColor(this)" style="cursor: hand;cursor: pointer;background-color:#' + color + ';"  height=12 ></td>';
			    }
		    }
	    }
		    tableText += '</tr>';
    }
    tableText += '</table></td></tr></table>';

    return tableText;
    }
    var colorToSet = 'back';

    // function to set the color 
    function setColor(node){
	    if(colorToSet=='fore'){
		    document.getElementById('testArea').style.color = node.style.backgroundColor;
		    var txtFGColor = document.getElementById('txtFGColor');
		    if (txtFGColor ) 
		    {	    txtFGColor.value = node.style.backgroundColor;	    }
	    }
	    else if (colorToSet=="blank")
        {
            document.getElementById('testArea').style.color = "";
		    var txtFGColor = document.getElementById('txtFGColor');
		    if (txtFGColor ) 
		    {txtFGColor.value = "";}
    		
		    document.getElementById('testArea').style.backgroundColor = "";
		    var txtBGColor = document.getElementById('txtBGColor');
		    if (txtBGColor ) 
		    {	    txtBGColor.value = "";}

         }
     else{
		    document.getElementById('testArea').style.backgroundColor = node.style.backgroundColor;
		    var txtBGColor = document.getElementById('txtBGColor');
		    if (txtBGColor ) 
		    {	    txtBGColor.value = node.style.backgroundColor;}
	    }
    }

    //function to set the color type
    function setColorType(val)
    {
    colorToSet=val;
    if (val=="blank")
     {
            document.getElementById('testArea').style.color = "";
		    var txtFGColor = document.getElementById('txtFGColor');
		    if (txtFGColor ) 
		    {txtFGColor.value = "";}
    		
		    document.getElementById('testArea').style.backgroundColor = "";
		    var txtBGColor = document.getElementById('txtBGColor');
		    if (txtBGColor ) 
		    {	    txtBGColor.value = "";}

     }
    }
    			
    function setImage(node)
    {
    var imgStar= document.getElementById('starImage');
        if (imgStar)
        {
        imgStar.innerHTML = '<div style="background: url(images/'+ node.value +'/star.png) left bottom;width:150px;height:30px;"> &nbsp;</div>';
        }
    }