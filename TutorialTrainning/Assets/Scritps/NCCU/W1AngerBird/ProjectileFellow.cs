using UnityEngine;
using System.Collections;

public class ProjectileFellow : MonoBehaviour {


    public Transform Projectile;
    public Transform farLeft;
    public Transform farRight;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPosition = transform.position;
        newPosition.x = Projectile.position.x;
        newPosition.x = Mathf.Clamp(newPosition.x, farLeft.position.x, farRight.position.x);
        transform.position = newPosition;

	}
}
