// Use this for initialization
function Start () {
}
var theOneObjStr : String;
var theOneObjStr2 : String;
// Update is called once per frame
function Update () {
Camera.main.orthographic = true;


/*
// find single object
var sphere = GameObject.Find(theOneObjStr);
sphere.transform.Translate(0,0.01,0);

// find object with tag
var PlayerTag = GameObject.FindWithTag(theOneObjStr2);
PlayerTag.transform.Translate(0.01,0,0);


// find multiple object with tag
var Players = GameObject.FindGameObjectsWithTag(theOneObjStr2);
for(var i=0; i<Players.length;i++){
	Debug.Log(Players[i].name);
	Debug.Log(Players.length);
	Players[i].transform.Translate(0,0,0.01);
	Players[i].transform.Rotate(2,3,1);
}


// access function through obj "name" => Spheare
var getSphere = GameObject.Find(theOneObjStr);
getSphere.GetComponent(Accessing_GameObj).printOthers("This is Sphere");

// access function through obj Tag => Player
var getPlayerTag = GameObject.FindWithTag(theOneObjStr2);
getPlayerTag.GetComponent(Accessing_GameObj).printOthers("This is PlayerTag");
*/



/*
	transform.Find(theOneObj).Translate(0,0.01,0);
	
	transform.Find(theOneObj).GetComponent(Accessing_GameObj).otherGameObject = 25 ;
	Debug.Log(transform.Find(theOneObj).GetComponent(Accessing_GameObj).otherGameObject);
	
	//function access hierarchy
	transform.Find(theOneObj).GetComponent(Accessing_GameObj).printOthers("function access child hierarchy");
	//function access hierarchy to L2
	transform.Find(theOneObj2).GetComponent(Rigidbody).AddForce(0,1,0);
	//looping over all child obj (add additional obj to hierarchy)
	for(var children : Transform in transform ){
		children.Translate(0,0.01,0);
	}
*/	
	
} 


