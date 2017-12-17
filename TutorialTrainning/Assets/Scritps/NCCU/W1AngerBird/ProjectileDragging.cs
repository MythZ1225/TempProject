using UnityEngine;
using System.Collections;

public class ProjectileDragging : MonoBehaviour {


    public float maxStretch = 3.0f;
    public LineRenderer catpultLineRFront;
    public LineRenderer catpultLineRBack;

    private SpringJoint2D spring;
    private Transform catapult;
    private Ray rayToMouse;
    private Ray leftCatapultToProjectile; //用來協助彈弓線的LineRander
    private float maxStretchSqr; //用來幫助向量比較用
    private float CircleRedius;
    private bool clickedOn;
    private Vector2 preVelocity;

    private Collider2D C2D;
    private Rigidbody2D R2D;

    //private float LineRFrontsortingOrder= -0.9f;
    //private float LineRBacksortingOrder = -0.1f;
    private string AstroidSLayerName;
    private int AstroidSLayerInt;


    private void Awake()
    {
        spring = GetComponent<SpringJoint2D>();
        catapult = spring.connectedBody.transform;
        this.C2D = this.GetComponent<Collider2D>();
        this.R2D = this.GetComponent<Rigidbody2D>();
        this.AstroidSLayerName = this.GetComponent<SpriteRenderer>().sortingLayerName;
        this.AstroidSLayerInt = this.GetComponent<SpriteRenderer>().sortingOrder;

    }

    // Use this for initialization
    void Start () {
        LineRendererSetup();

        //一開始先設定Ray起點為彈弓位置，到原點位置，等有按壓操作才變更
        rayToMouse = new Ray(catapult.position, Vector3.zero);
        //計算預設的彈弓彈簧向量，好讓他跟玩家的滑鼠向量比較
        maxStretchSqr = maxStretch * maxStretch;

        leftCatapultToProjectile = new Ray(catpultLineRFront.transform.position, Vector3.zero);

        CircleCollider2D circle = C2D as CircleCollider2D;
        CircleRedius = circle.radius;
    }
	
	// Update is called once per frame
	void Update () {
        LineRanderUpdate();
        if (clickedOn)
        {
            Dragging();

        }
        if (spring != null)
        {
            
            if (R2D.isKinematic ==false && preVelocity.sqrMagnitude > R2D.velocity.sqrMagnitude)
            {
                //當投射物被投射出去的瞬間移除Spring
                Destroy(spring);
                //且讓目前的R2D速度 = 投射出去的瞬間速度，避免R2D受到物理影響立刻停了下來
                R2D.velocity = preVelocity;

            }
            if (clickedOn == false)
            {
                //初始向量速度 = R2D向量速度

                preVelocity = R2D.velocity;
                //同時須每fram更新彈弓線
                LineRanderUpdate();
            }

        }
        else
        {
            catpultLineRFront.enabled = false;
            catpultLineRBack.enabled = false;
        }
	}

    void LineRendererSetup()
    {

        //Vector3 catpultLineRFrontPos =new Vector3( catpultLineRFront.transform.position.x, catpultLineRFront.transform.position.y, LineRFrontsortingOrder);
        //Vector3 catpultLineRBackPos = new Vector3(catpultLineRBack.transform.position.x, catpultLineRBack.transform.position.y, LineRBacksortingOrder);
        catpultLineRFront.SetPosition(0,catpultLineRFront.transform.position );
        catpultLineRBack.SetPosition(0, catpultLineRBack.transform.position);
        
        /*改變作法，不用sortingLayer
        catpultLineRFront.sortingLayerName = "ForegroundUILayer";
        catpultLineRBack.sortingLayerName = "ForegroundUILayer";
        
        catpultLineRFront.sortingOrder = LineRFrontsortingOrder;
        catpultLineRBack.sortingOrder = LineRBacksortingOrder;
 
        Debug.Log(catpultLineRFront.sortingLayerName + catpultLineRFront.sortingOrder + "\n"
            + catpultLineRBack.sortingLayerName + catpultLineRBack.sortingOrder + "\n"
            + AstroidSLayerName + AstroidSLayerInt
            );
                   */
    }

    private void OnMouseDown()
    {
        spring.enabled = false;
        clickedOn = true;
    }
    private void OnMouseUp()
    {
        spring.enabled = true;
        R2D.isKinematic = false;
        clickedOn = false;
    }

    private void Dragging()
    {
        //讓鏡頭跟著滑鼠動
        Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //限制投射物可以被抓太遠
        //需先計算滑鼠到彈弓的向量值
        Vector2 catapultToMouse = mouseWorldPoint - catapult.position; 

        //比較向量(Magnitude)的小訣竅，向量C公式為 a^2 + b^2 = C^2  取得C^2開根號才可以取得向量C
        //但是假使只是要比較C的大小不需要開跟號回來，直接用C^2 (sqrMagnitude)即可
        //假使操作的向量平方大於設定的向量平方
        if (catapultToMouse.sqrMagnitude > maxStretchSqr)
        {
            rayToMouse.direction = catapultToMouse;
            //當拉力太大時，滑鼠的世界座標 = 當初設      定的maxStretch長度的末端 座標
            mouseWorldPoint = rayToMouse.GetPoint(maxStretch);
        }

        mouseWorldPoint.z = 0f;
        //投射物的位移 = 滑鼠位移
        transform.position = mouseWorldPoint;
    }

    private void LineRanderUpdate()
    {
        Vector2 catapultToProjectile = transform.position - catpultLineRFront.transform.position;
        leftCatapultToProjectile.direction = catapultToProjectile;
        Vector3 length = leftCatapultToProjectile.GetPoint(catapultToProjectile.magnitude + CircleRedius);
        Vector3 holdPoint = new Vector3(length.x, length.y,transform.position.z );
        catpultLineRFront.SetPosition(1, holdPoint);
        catpultLineRBack.SetPosition(1, holdPoint);

    }
}

