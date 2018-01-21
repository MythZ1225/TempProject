using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;

    private Vector3 movement;
    private Animator _anim;
    private Rigidbody playerRB;
    private int floorMask;
    private float camRayLength=100f;

    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        _anim = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
        Turning();
        _Animating(h, v);
    }

    private void Move(float h, float v)
    {
        movement.Set(h, 0, v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRB.MovePosition(transform.position + movement);
    }

    private void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if (Physics.Raycast(camRay, out floorHit , camRayLength,floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRB.MoveRotation(newRotation);
        }
        
        
    }
    private void _Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        _anim.SetBool("IsWalking", walking);
    }
} 
