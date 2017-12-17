
// Use this for initialization
function Start () {
}

// Update is called once per frame
function Update () {
}
/*
function OnTriggerStay(otherObj : Collider){
	if (otherObj.rigidbody){
		Debug.Log("you have collidered with me");
		otherObj.rigidbody.AddForce(0,20,0);
	}
}
*/
function OnTriggerStay(otherObj : Collider){
	if (otherObj.GetComponent(Accessing_GameObj)){
		Debug.Log("you have collidered with me");
		otherObj.GetComponent(Accessing_GameObj).stopRendering();
	}
}