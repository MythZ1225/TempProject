using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

    public Rigidbody _RB;
    public float moveSpeed;
    // Use this for initialization
    void Start () {
        _RB = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        _RB.velocity = transform.forward * moveSpeed ;
    }
}
