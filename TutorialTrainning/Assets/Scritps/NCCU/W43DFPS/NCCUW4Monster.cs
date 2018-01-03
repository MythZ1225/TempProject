using UnityEngine;
using System.Collections;
using DG.Tweening;

public class NCCUW4Monster : MonoBehaviour {

    private Animator MoAnimator;
    private float currentHP = 100;
    private float minimumHitPeriod = 1f;
    private float hitCounter = 0;

    // Use this for initialization
    void Start () {
        this.MoAnimator = GetComponent<Animator>();
	}

    public void Hit(float value)
    {
        if (hitCounter <= 0 )
        {
            hitCounter = minimumHitPeriod;
            currentHP -= value;
            MoAnimator.SetFloat("HP", currentHP);
            MoAnimator.SetTrigger("Hit");

            if (currentHP <= 0)
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

    // Update is called once per frame
    void Update () {
        if (currentHP > 0 && hitCounter >0)
        {
            hitCounter -= Time.deltaTime;
        }
	}
}
