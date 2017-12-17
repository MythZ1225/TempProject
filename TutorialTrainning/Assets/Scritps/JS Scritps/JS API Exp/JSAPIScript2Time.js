
// Use this for initialization
function Start () {
}

// Update is called once per frame
var boxspeed : int = 1;
var colorRed : Color = Color.red;	

function Update () {

transform.Translate(0,Time.time * boxspeed ,0,Space.Self);
transform.Rotate(2,3,1);
GetComponent.<Renderer>().material.color = colorRed;



}

