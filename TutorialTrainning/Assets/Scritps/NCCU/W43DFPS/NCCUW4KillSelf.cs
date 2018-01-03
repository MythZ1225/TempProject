
using UnityEngine;
using System.Collections;

public class NCCUW4KillSelf : MonoBehaviour {
    private float liveTime = 1;

	// Use this for initialization
	void Start () {
        Invoke("DestroySelf", liveTime);
	}


    private void DestroySelf()
    {
        GameObject.Destroy(this.gameObject);
    }

}
