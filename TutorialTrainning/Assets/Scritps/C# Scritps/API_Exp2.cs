using UnityEngine;
using System.Collections;

public class API_Exp2 : MonoBehaviour
{
	public GameObject sphere = null;
	// Use this for initialization
	void Start ()
	{
		StartCoroutine (DelayThenCreat());
	}
	
	// Update is called once per frame
	IEnumerator DelayThenCreat (){
		yield return new WaitForSeconds(3);
		GameObject obj = Instantiate(sphere) as GameObject;
		obj.name = "sphere clone";
		obj.transform.position = this.gameObject.transform.position;
	}

	void Update ()
	{
	
	}
}

