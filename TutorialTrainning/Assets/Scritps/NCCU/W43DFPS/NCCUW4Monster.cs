using UnityEngine;
using System.Collections;
using DG.Tweening;

public class NCCUW4Monster : MonoBehaviour {

    private Animator _MoAnimator;
    public float CurrentHP = 100;
    private float minimumHitPeriod = 1f;
    private float hitCounter = 0;

    public float MoveSpeed = 10;
    public GameObject FollowTarget;

    private Rigidbody _MRB;
    public NCCUW5CollisionListScript _PlayerSensorList;
    public NCCUW5CollisionListScript _AttackSeneorList;

    // Use this for initialization
    void Start () {
        _MoAnimator = this.GetComponent<Animator>();
        _MRB = this.GetComponent<Rigidbody>();
	}

    public void Hit(float value)
    {
        FollowTarget = GameObject.FindGameObjectWithTag("Player");
        if (hitCounter <= 0 )
        {
            hitCounter = minimumHitPeriod;
            CurrentHP -= value;
            _MoAnimator.SetFloat("HP", CurrentHP);
            _MoAnimator.SetTrigger("Hit");

            if (CurrentHP <= 0)
                PlayDead();
        }
    }

    void PlayDead()
    {
        this.GetComponent<Rigidbody>().useGravity = false;
        this.GetComponent<Collider>().enabled = false;
        this.transform.DOMoveY(-0.8f, 1f).SetRelative(true).SetDelay(1).OnComplete
            (
                () =>
                    {
                        this.transform.DOMoveY(-0.8f, 1f).SetRelative(true).SetDelay(3).OnComplete
                        (
                            () =>
                            {
                            GameObject.Destroy(this.gameObject);
                            }
                        );
                    }
            );
    }

    public void AttackPlayer()
    {
        if (_AttackSeneorList._CollisionObjs.Count>0)
        {
            _AttackSeneorList._CollisionObjs[0].transform.SendMessage("Hit", 10);
        }
    }

    // Update is called once per frame
    void Update () {
        if (_PlayerSensorList._CollisionObjs.Count > 0)
        {
            FollowTarget = _PlayerSensorList._CollisionObjs[0].gameObject;
        }

        if (CurrentHP > 0 && hitCounter > 0)
        {
            hitCounter -= Time.deltaTime;
        }
        else
        {
            if (CurrentHP > 0)
            {
                if (FollowTarget != null)
                {
                    Vector3 lookAt = FollowTarget.gameObject.transform.position;
                    lookAt.y = this.gameObject.transform.position.y;
                    this.transform.LookAt(lookAt);
                    _MoAnimator.SetBool("Run", true);

                                        
                    if (_AttackSeneorList._CollisionObjs.Count > 0)
                    {
                        _MoAnimator.SetBool("Attack", true);
                        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    }
                    else
                    {
                        _MoAnimator.SetBool("Attack", false);
                        _MRB.velocity = this.transform.forward * MoveSpeed;
                    }
                }
            }
            else
            {
                this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }



        /*
        if (_PlayerSensorList._CollisionObjs.Count>0)
            FollowTarget = _PlayerSensorList._CollisionObjs[0].gameObject;
        
        if (currentHP > 0 && hitCounter >0)
            hitCounter -= Time.deltaTime;
        else
        {
            if (currentHP>0)
            {
                if (FollowTarget != null)
                {
                    Vector3 lookAt = FollowTarget.transform.position;
                    lookAt.y = this.gameObject.transform.position.y;
                    this.transform.LookAt(lookAt);
                    MoAnimator.SetBool("Run", true);
                    _MRB.velocity = this.transform.forward * MoveSpeed;
                    
                    if (_AttackSeneorList._CollisionObjs.Count > 0)
                    {
                        MoAnimator.SetBool("Attack", true);
                        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    }
                    else
                    {
                        MoAnimator.SetBool("Attack", false);
                        
                    } 
                }
                else
                {
                    //MoAnimator.SetBool("Run", false);
                    //this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
            }
            
        }*/
    }
}
