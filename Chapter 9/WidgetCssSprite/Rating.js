var starImages = new Array("images/0star.gif",
"images/1star.gif",
"images/2star.gif",
"images/3star.gif",
"images/4star.gif",
"images/5star.gif");
var nullStarMessage = "images/spacer.gif"
var starMap = new Array('0,0,22,20',
'23,0,36,20',
'37,0,50,20',
'51,0,64,20',
'65,0,78,20',
'79,0,101,20');
var starMessages = new Array("images/0.gif",
"images/1.gif",
"images/2.gif",
"images/3.gif",
"images/4.gif",
"images/5.gif",
"images/saved.gif");

var savedRatings = new Array();
var changedRatings = new Array();
var starTwinkler = new Array();
var msgTwinkler = new Array();
var isRatingsBarChanged = false;
var delayTime = 500;
var allImages = new Array();
function preloadImages(){
for (i=0; i < preloadImages.length ;i++){
allImages[i] = new Image();
allImages[i].src = preloadImages.arguments[i];
}
}

// Preloading he images and the stars //
preloadImages(starImages);
preloadImages(starMessages);


// function to swap the star image //
function SwapStars(id, rating){
if (rating == undefined){
rating = savedRatings[id];
}
document.images["stars." + id].src = starImages[rating];
}

// function to swap the messages  //
function SwapStarMsg(id, rating){
if (rating == undefined){
if ( changedRatings[id] ) {
document.images["messages." + id].src = starMessages[6];
} else {
document.images["messages." + id].src = nullStarMessage;
}
} else {
document.images["messages." + id].src = starMessages[rating];
}
}

// function to save the rating  //
function SaveStars(id, rating){
savedRatings[id] = rating;
changedRatings[id] = 1;
SaveRating(id, 'onetofive', rating);
// show saved message
SwapStarMsg(id, 6);
}

// mouse hover effect for the stars //

function StarMouseOver(id, rating){
if (starTwinkler[id] != 0){
window.clearTimeout(starTwinkler[id]);
starTwinkler[id] = 0;
}
if (msgTwinkler[id] != 0){
window.clearTimeout(msgTwinkler[id]);
msgTwinkler[id] = 0;
}
SwapStars(id, rating);
SwapStarMsg(id, rating); 
}

// mouse out effect for the stars //

function StarMouseOut(id){
starTwinkler[id] = window.setTimeout("SwapStars('"+id+"')", delayTime);
msgTwinkler[id] = window.setTimeout("SwapStarMsg('"+id+"')", delayTime);
}

//Display the stars //

function DisplayStars (id, rating){
var starID = "stars." + id;
starTwinkler[id] = 0;
msgTwinkler[id] = 0;
document.write("<map name='starmap" + id +"'>");
var i = 0;
for (i = 1; i < 6; i++) {
document.write("<area shape=rect " + 
"coords='" + starMap[i] + "' " +
"onMouseOver=\"StarMouseOver('" + id + "'," + i + ");\" " +
"onMouseOut=\"StarMouseOut('" + id + "');\" " +
"onClick=\"SaveStars('" + id + "'," + i + ");" +
"\" >");
}
document.write("</map>");
document.write("<img vspace=2 title = 'Rate' src='" + starImages[rating] + "'");
document.write(" border=0 usemap='#starmap" + id);
document.write("' id='" + starID + "'>");
}

//Display the message //

function DisplayMsg (id, rating){
var msgID = "messages." + id;
if ( rating == undefined ) {
document.write("<img vspace=2 height=11 src='" + nullStarMessage + "'");
}
else {
document.write("<img vspace=2 height=11 src='" + starMessages[rating] + "'"); 
}
document.write("' id='" + msgID + "'>");
}