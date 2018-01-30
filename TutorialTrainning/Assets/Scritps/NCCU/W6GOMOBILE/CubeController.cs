using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {

    public Camera MainCamera;

    private void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update () {
        for (int i = 0; i < Input.touches.Length; i++)
        {
            Debug.Log("Point" + Input.touches[i].fingerId + ":" + Input.touches[i].position);
            Vector3 screenPos = Input.touches[i].position;

            //距離Camera多遠
            screenPos.z = this.transform.position.z - MainCamera.transform.position.z;

            Vector3 TargetPos = MainCamera.ScreenToWorldPoint(screenPos);
            this.transform.position = TargetPos;
        }
        this.transform.rotation = convertRotation(Input.gyro.attitude);

	}

    private Quaternion convertRotation(Quaternion q)
    {
        return Quaternion.Euler(90, 0, 0) * new Quaternion(q.x, q.y, q.z,q.w);
    }
}
