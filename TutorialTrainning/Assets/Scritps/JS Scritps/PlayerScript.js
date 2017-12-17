#pragma strict
// player Script


//Public Var
var tagName 	: String="Enemy";
var rayDistance : float =100;
var Score 		: int	=0;
var gameTime 	: float = 20.0;
var waitTime 	: float = 1.0;
var ScoreToWin 	: int = 5;
var x : float =30;
var y: float  =5;
//Private Var



function Start () 
{
	Score = 0;
	InvokeRepeating("TimeConuntDown",1.0,1.0);
}

function Update() {
/*
	//if(Input.GetMouseButtonDown(0))
	if(Input.GetMouseButton(0))
	{
*/
	//Debug.Log("Pressed left click.");
	var ray :	Ray =Camera.main.ScreenPointToRay(Input.mousePosition);
	var hit :	RaycastHit;
    
		if(Physics.Raycast(ray,hit,rayDistance)) 
		{
			Debug.DrawLine(ray.origin, hit.point);
			if(hit.transform.tag == tagName)
			{
				//var Posposition = Vector3(Random.Range(-9,9),Random.Range(1,4),0);
				//hit.transform.position = Posposition;
				
				var enemyScrpt = hit.transform.GetComponent(EnemyScript);
				enemyScrpt.numberOfClick -= 1;
				if(enemyScrpt.numberOfClick ==0)
				{
					Score += enemyScrpt.enemyPoint;
				}
				
				Debug.Log("numberOfClick =" + enemyScrpt.numberOfClick);	
				Debug.Log("You Hit a enemy");			
			}else{
				Debug.Log("You Hit not a enemy");
			}
		}
//	}
}



function TimeConuntDown()
{
	if(--gameTime == 0)
	{
		CancelInvoke("TimeConuntDown");
		//yield WaitForSeconds(waitTime);
		if(Score>=ScoreToWin)
		{
			Debug.Log("W");
			//OnGUIWin();
			Application.LoadLevel("StageSceneWin");
		}
		else if(Score<ScoreToWin)
		{
			Debug.Log("L");
			//OnGUIWin();
			Application.LoadLevel("StageSceneLose");
		}
	}
}
	
function OnGUI()
{
	GUI.Label(Rect(Screen.width/2-10,10,100,40),"Time: "+gameTime);
	GUI.Label(Rect(Screen.width/2-10,30,100,40),"Score "+Score);	
}
function OnGUIWin()
{
		GUI.Label(Rect(Screen.width/2-x,Screen.height/2-y,100,40),"You Win");
}
function OnGUILose()
{
		GUI.Label(Rect(Screen.width/2-x,Screen.height/2-y,100,40),"You Lose");
}
