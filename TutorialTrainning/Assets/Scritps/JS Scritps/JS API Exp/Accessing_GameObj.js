
var otherGameObject = 10;

function printOthers(t : String){
	Debug.Log("function value is "+ otherGameObject);
	Debug.Log(t);

}

function stopRendering(){
	this.GetComponent.<Renderer>().enabled=false;
}

// golbal var 
static var playerHeightGolbal =12 ;
