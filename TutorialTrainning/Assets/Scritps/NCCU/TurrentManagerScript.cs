using UnityEngine;
using System.Collections;
using DG.Tweening;

public class TurrentManagerScript : MonoBehaviour {

    private Animator _animator;
    const int DirectionCount = 8;
    public Ease RotateEaseFunction;
    public float RotateTime;
    public Camera GameCamera;
    public float cameraShakeDuration;
    public float cameraShakePower;
    public GameObject bullet;
    private float bulletSpwamPoint= 0.6f;

    public ScoreManager ScoreManager;

    public GameLoopManager GameLoopManager;
    // Use this for initialization
    void Start () {
        _animator = this.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (GameLoopManager.playerAlive == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playShootAni();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                playRotateAni();
            }
        }


    }

    public void playShootAni()
    {
        _animator.SetTrigger("Shoot");
        GameCamera.transform.DOShakePosition(cameraShakeDuration, cameraShakePower);
        GameObject bulletObj = GameObject.Instantiate(bullet);
        BulletScript bulletScript = bulletObj.GetComponent<BulletScript>();
        bulletScript.transform.position = this.transform.position + bulletSpwamPoint * this.gameObject.transform.right;
        bulletScript.transform.rotation = this.transform.rotation;

        Vector3 shootDirection3D = this.gameObject.transform.right;
        Vector2 shootDirection2D = new Vector2(shootDirection3D.x, shootDirection3D.y);

        bulletScript.InitAndShoot(shootDirection2D);

        ScoreManager.AddScore(1);
        GameLoopManager.bullets.Add(bulletScript);
        Reset();
    }

    public void playRotateAni()
    {
        float targetDegree = 360f / DirectionCount * Random.Range(0, DirectionCount);
        this.transform.DORotate(new Vector3(0,0,targetDegree),RotateTime);
    }

    public void Reset()
    {
        
        GameCamera.transform.position = new Vector3(0, 0, -10);
    }

}
