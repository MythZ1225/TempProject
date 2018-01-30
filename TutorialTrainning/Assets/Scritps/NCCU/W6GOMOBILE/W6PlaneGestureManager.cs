using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using TouchScript.Hit;
using DG.Tweening;

public class W6PlaneGestureManager : MonoBehaviour {

    public TapGesture SingleTap;
    public TapGesture doubleTap;
    public Rigidbody RB;

    // Use this for initialization
    void Start () {
        SingleTap.Tapped += (object sender, System.EventArgs e) => 
        {
            TouchHit hit;
            SingleTap.GetTargetHitResult(out hit);

            Vector3 targetPoint = hit.Point;
            targetPoint.y = RB.transform.position.y;

            RB.transform.DOMove(targetPoint, 0.5f);
        };
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
