#pragma strict

function Start () {

}


var boxspeed = 1;
var colorRed : Color = Color.red;	
var timeDelay = 0.0;
var DelayAmount = 1;
function OnGUI(){
	GUI.Box(Rect(10,10,150,30),"Real Time is " + Time.realtimeSinceStartup.ToString("f0") );
	GUI.Box(Rect(10,40,150,30),"delta Time is " + Time.deltaTime.ToString("f0") );
	GUI.Box(Rect(10,70,150,30),"Time is " + Time.time.ToString("f0") );
}

function Update () {

transform.Translate(0,Time.deltaTime * boxspeed,0,Space.Self);
transform.Rotate(2,3,1);
GetComponent.<Renderer>().material.color = colorRed;

if( Input.GetKey("d")&& Time.time > timeDelay){
	timeDelay = Time.time + DelayAmount;
	Debug.Log("Delay time is "+ timeDelay);
}
/*
transform.Translate(0,Time.deltaTime*boxspeed,0,Space.World);
transform.Rotate(2,3,1);


transform.Translate( boxspeed * Time.deltaTime,0,0);


	var x = 	gameObject.transform.position.x;
	var posX= 		  this.transform.position.x;
	var positionX= 		   transform.position.x;
	print (x);
	print (posX);
	print (positionX);
*/	
	
}