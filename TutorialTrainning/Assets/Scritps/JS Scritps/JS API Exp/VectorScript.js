
// Use this for initialization
function Start () {
}

// Update is called once per frame
/*
var startObj : Transform;
var endObj : Transform;
var mover = 0.5;
var smooth = 5.0;
var Hight = 1;
*/
var Explosion : Transform;

function Update () {

/*
//transform.position = Vector3.Lerp(startObj.position,endObj.position,mover);
//transform.position += Vector3.up * Time.deltaTime;

//Lerp
//transform.position = Vector3.Lerp(transform.position,startObj.position,Time.deltaTime*smooth);

//slerp
var CenterPoint = (startObj.position + endObj.position)*mover;
CenterPoint -= Vector3(0,Hight,0);
var riseRelCenter = startObj.position - CenterPoint;
var setRelCenter = endObj.position - CenterPoint;
transform.position = Vector3.Slerp(riseRelCenter,setRelCenter,Time.time);
transform.position += CenterPoint;

//Golbal Var 
Debug.Log(Accessing_GameObj.playerHeightGolbal) ;

*/



}


//var CharacterHight = 6 ; 
//private var CharacterName = "Jed";


// instantiate
function OnCollisionEnter(){
	Debug.Log(OnCollisionEnter);
	Destroy (gameObject);
	
	var cloneExplosion : Transform;
	
	cloneExplosion = Instantiate(Explosion, transform.position, transform.rotation);
	
}


