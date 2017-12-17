#pragma strict

var buttomSize : float = 90;

function Start () {

}

function Update () {

}

function OnGUI()
{
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