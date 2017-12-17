using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rG2D;
    public float ForceValue;
    public float MaxSpeed;
    public float DecreasingSpeed;
    public ParticleSystem PlayerDieParticle;
    public AudioSource KillAudio;

    public UnityEvent playerKillEvent;
    public int speedfactor = 300;

    // Use this for initialization
    void Start () {
        rG2D = this.GetComponent<Rigidbody2D>();
	}
    /*
    void OnCollisionEnter2D(Collision2D collision)
    {

        PlayerDieParticle.transform.position = this.transform.position;
        PlayerDieParticle.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }*/

    void OnCollisionEnter2D(Collision2D collision)
    {

        PlayerDieParticle.transform.position = this.transform.position;
        PlayerDieParticle.gameObject.SetActive(true);
        KillAudio.Play();

        if (playerKillEvent != null)
        {
            playerKillEvent.Invoke();
        }
        this.gameObject.SetActive(false);
    }

    public void Reset()
    {
        this.transform.localPosition = new Vector3(2, 0, 0);
        this.gameObject.SetActive(true);
        PlayerDieParticle.Stop();
        PlayerDieParticle.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        Vector2 force = Vector2.zero; //歸零

        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position += new Vector3(0, ForceValue/ speedfactor);
            //force += new Vector2 (0,ForceValue);
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position += new Vector3(0, -ForceValue / speedfactor);
            //force += new Vector2(0, -ForceValue);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position += new Vector3( -ForceValue / speedfactor,0);
            //force += new Vector2(-ForceValue,0 );
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += new Vector3( ForceValue / speedfactor, 0);
            //force += new Vector2(ForceValue,0);
        }

        if (force != Vector2.zero) //如果有加速的Force時
        {
            rG2D.AddForce(force);   //推動物體
            float speed = rG2D.velocity.magnitude;
            //當物體速度太快
            if (speed > MaxSpeed)
            {
                speed = MaxSpeed;
            }
            rG2D.velocity = rG2D.velocity.normalized * speed;
        }
        else //當沒有加速度時
        {
            float speed = rG2D.velocity.magnitude;
            speed -= DecreasingSpeed * Time.deltaTime; //就隨時間減速

            if (speed<0)
            {
                speed = 0;
            }
            rG2D.velocity = rG2D.velocity.normalized * speed;
        }
        /*
        if (rG2D.velocity ==Vector2.zero)
        {
            this.transform.eulerAngles = Vector3.zero;
        }
        else
        {
            float rotationZ = Mathf.Atan2(rG2D.velocity.y, rG2D.velocity.x) * Mathf.Rad2Deg;
            this.transform.eulerAngles = new Vector3(0, 0, rotationZ);
        }
        */
    }
}
