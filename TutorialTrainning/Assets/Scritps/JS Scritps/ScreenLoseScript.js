#pragma strict
var x : float =30;
var y: float  =5;

function Update () {
OnGUI();
}


function OnGUI()
{
	GUI.Label(Rect(Screen.width/2-x,Screen.height/2-y,100,40),"You Lose");
	
	if(GUI.Button(Rect(10,10,100,30),"Start Game"))
	{
		print("Start Game");
		Application.LoadLevel("StageScene1");
	};
	if(GUI.Button(Rect(10,50,100,30),"Exit Game"))
	{
		print("Exit Game");
		Application.Quit();
	};
}