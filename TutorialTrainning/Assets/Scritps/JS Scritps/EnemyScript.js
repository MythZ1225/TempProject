#pragma strict
// player Script


//Public Var
var numberOfClick 		: int 			= 2; 	//敵人點幾次會死
var respwanWaiteTime 	: float 		= 1.0; 	//下一隻出現的間隔時間
var shapeColor 			: Color[]; 		
var explosionPrefabs 	: Transform;
var enemyPoint 			: int 			= 1;

//Private Var
private var storeClicks : int 			= 0;


function Start () {
	storeClicks = numberOfClick;
	var startPosition = Vector3(Random.Range(-8,8),Random.Range(1,9),0);
		transform.position = startPosition;
	randomColor();		
}

function Update () 
{
	if (numberOfClick <= 0)
	{
		if(explosionPrefabs){
		Instantiate(explosionPrefabs,transform.position,transform.rotation);
		}
		if(AudioClip){
			GetComponent.<AudioSource>().Play();		
		}
		
		var Posposition = Vector3(Random.Range(-8,8),Random.Range(1,9),0);
		ReSpwanWaiteTime();
		transform.position = Posposition;
		numberOfClick = storeClicks;

	}
	
}

// 避免重生太快
function ReSpwanWaiteTime()
{
	GetComponent.<Renderer>().enabled = false;
	yield WaitForSeconds(respwanWaiteTime);
	GetComponent.<Renderer>().enabled = true;
	randomColor();
}


//重生後換顏色
function randomColor()
{
	if(shapeColor.length > 0){
	var newColor = Random.Range(0,shapeColor.length);
	GetComponent.<Renderer>().material.color= shapeColor[newColor];
	}
	
}




