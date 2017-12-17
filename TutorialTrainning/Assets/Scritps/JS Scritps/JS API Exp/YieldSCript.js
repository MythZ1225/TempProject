
// Use this for initialization
var printToggle = false;
function Start () {
}

// Update is called once per frame
function Update () {

	WaitFor();
		print("Its Time To Wait");
		if (printToggle== true){
		print ("yield statement 3 sec wait completed");
		}
}

function WaitFor(){
	// do something
	Debug.Log("Star to wait");
	yield WaitForSeconds(3.0); 
	// do something else 
	Debug.Log("3 Sec pass");
	printToggle = true;
}