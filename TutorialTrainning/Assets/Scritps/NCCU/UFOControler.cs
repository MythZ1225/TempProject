using UnityEngine;
using System.Collections;

public class UFOControler : MonoBehaviour {
    //public float speed = 10f;
    public float forceValue;
    private Rigidbody2D RG2D = null;
    // Use this for initialization
    public ScoreManager scoreManager;

    void Start () {
        RG2D = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 force2D = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            //this.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            force2D.y += forceValue;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //this.transform.position += new Vector3(-speed * Time.deltaTime,0 , 0);
            force2D.x -= forceValue;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //this.transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
            force2D.y -= forceValue;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            force2D.x += forceValue;
        }

        RG2D.AddForce(force2D);
    }


    //吃金塊的時候消除物件
    private void OnTriggerEnter2D(Collider2D other)
    {
        scoreManager.AddScore(100);
        other.gameObject.SetActive(false);

    }

}
