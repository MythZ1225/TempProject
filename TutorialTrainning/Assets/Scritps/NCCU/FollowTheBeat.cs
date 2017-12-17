using UnityEngine;
using System.Collections;

public class FollowTheBeat : MonoBehaviour {
    private const float beatPreiod = 1.485f;

    //提前0.2秒旋轉
    private float rotateCounter = 0.2f;

    //前三拍不做事
    private float shootCounter = -0.5f - beatPreiod*3;

    private TurrentManagerScript turrent;
    // Use this for initialization
    void Start () {
        turrent = this.GetComponent<TurrentManagerScript>();
	}
	
	// Update is called once per frame
	void Update () {
        rotateCounter += Time.deltaTime;
        shootCounter += Time.deltaTime;

        if (rotateCounter >beatPreiod)
        {
            turrent.playRotateAni();
            rotateCounter -= beatPreiod;
        }
        if (shootCounter > beatPreiod)
        {
            turrent.playShootAni();
            shootCounter -= beatPreiod;
        }
    }

    public void Reset()
    {
        shootCounter = -0.5f - beatPreiod * 3;
        rotateCounter = 0.2f;
    }
}
