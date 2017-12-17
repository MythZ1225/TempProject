function printMe()
{
	Debug.Log("Accessing Compoent Now!");
}

// Use this for initialization
function Start () {
}

// Update is called once per frame
function Update () {
}

var otherGameObject = 10;

function printOthers(t : String){
	Debug.Log("function value is "+ otherGameObject);
	Debug.Log(t);

}



