using UnityEngine;
using System.Collections;

public class HoverMoter : MonoBehaviour {

    public float Speed = 90f;
    public float TurnSpeed = 5f;
    public float HoverForce = 65f;
    public float HoverHeight = 3.5f;

    //public GameObject CarModel;

    private float powerInput;
    private float turnInput;
    private Rigidbody carRigibody;

    private void Awake()
    {
        carRigibody = GetComponent<Rigidbody>();
    }


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        powerInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, HoverHeight))
        {
            float currentHeight = (HoverHeight - hit.distance) / HoverHeight;
            Vector3 appliedHoverForce = Vector3.up * currentHeight * HoverForce;
            carRigibody.AddForce(appliedHoverForce, ForceMode.Acceleration);
        }

        carRigibody.AddRelativeForce(0f, 0f, powerInput * Speed);
        carRigibody.AddRelativeTorque(0f, turnInput * Speed, 0f);
    }
}
