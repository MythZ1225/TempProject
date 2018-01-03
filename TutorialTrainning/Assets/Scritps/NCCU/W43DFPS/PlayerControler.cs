using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {
    public float MoveSpeed;
    public Transform RotateY;
    public Transform RotateX;
    public float RotateSpeed;
    public float CurrentRotateX = 0;
    public Rigidbody playerRB;

    public JumpSensor _JumpSensor;
    public float JumpSpeed;

    public NCCUW4GunManager gunManager;

    public GameObject PlayerObj;

    private Animator _animatorControler;
    private float currentSpeed = 0;
    private float defMoveSpeed;
    // Use this for initialization
    void Start () {
        _animatorControler = PlayerObj.GetComponent<Animator>();
        
        defMoveSpeed = MoveSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 moveDirection = Vector3.zero;
        Cursor.visible = true;

        //float result = 0;
        //鍵盤輸入
        if (Input.GetKey(KeyCode.W))
            moveDirection.z += 1;
        if (Input.GetKey(KeyCode.S))                    
            moveDirection.z -= 1;        
        if (Input.GetKey(KeyCode.A))        
            moveDirection.x -= 1;        
        if (Input.GetKey(KeyCode.D))        
            moveDirection.x += 1;

        if (Input.GetMouseButton(0))
        {
            gunManager.TryTriggerGun();
        }

            
        //加速功能
        if (Input.GetKeyDown(KeyCode.LeftShift))
            MoveSpeed = MoveSpeed * 2;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            MoveSpeed = defMoveSpeed;

        moveDirection = moveDirection.normalized;

        //決定要給Animator的動畫參數
        if (moveDirection.magnitude == 0 || !_JumpSensor.IsCanJump()) { currentSpeed = 0; }
        else
        {
            if (moveDirection.z < 0) { currentSpeed = -MoveSpeed; }
            else { currentSpeed = MoveSpeed; }
        }
        _animatorControler.SetFloat("Speed", currentSpeed);

        Vector3 worldSpaceDirecrion = moveDirection.z * RotateY.transform.forward + moveDirection.x * RotateY.transform.right;
        Vector3 velocity = playerRB.velocity; //先賦值
        //在運算
        velocity.x = worldSpaceDirecrion.x * MoveSpeed;
        velocity.z = worldSpaceDirecrion.z * MoveSpeed;

        if (Input.GetKey(KeyCode.Space) && _JumpSensor.IsCanJump())
            velocity.y = JumpSpeed;

        //重新還給值
        playerRB.velocity = velocity;

        //計算滑鼠
        RotateY.transform.localEulerAngles += new Vector3(0, Input.GetAxis("Horizontal"), 0) * RotateSpeed;
        CurrentRotateX += Input.GetAxis("Vertical") * RotateSpeed;

        if (CurrentRotateX >90)
        {
            CurrentRotateX = 90;
        }
        else if(CurrentRotateX < -90)
        {
            CurrentRotateX = -90;
        }

        RotateX.transform.localEulerAngles = new Vector3(-CurrentRotateX, 0, 0);
	}
}
