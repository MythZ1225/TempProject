using UnityEngine;
using System.Collections;

public class UFOCameraController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.eulerAngles = Vector3.zero; //這樣就不會轉了
	}
}
