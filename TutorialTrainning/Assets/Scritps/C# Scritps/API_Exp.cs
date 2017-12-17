using UnityEngine;
using System.Collections;

public class API_Exp : MonoBehaviour {

	public float speed = 2.0f;
	public GameObject shpereObj = null;
	// Use this for initialization
	void Start () {
		Debug.Log("Name: " + this.gameObject.name);
		//this.gameObject.GetComponent<Renderer>().material.color = Color.red ;
		//this.shpereObj.GetComponent<Renderer>().material.color = Color.blue ;
		this.gameObject.GetComponent<Renderer>().material.color = shpereObj.GetComponent<Renderer>().material.color;

	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.Translate(Vector3.up * Time.deltaTime*speed);
		Debug.Log("position : " + this.gameObject.transform.position);
	}
}
