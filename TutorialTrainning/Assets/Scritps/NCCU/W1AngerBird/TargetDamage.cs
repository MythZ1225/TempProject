using UnityEngine;
using System.Collections;
using DG.Tweening;

public class TargetDamage : MonoBehaviour {
    public int HP = 2;
    public Sprite DamageSprite;
    public float damageImpactSpeed;

    private int CurrentHitPoints;
    private float damageImpactSpeedSqr;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        CurrentHitPoints = HP;
        damageImpactSpeedSqr = damageImpactSpeed * damageImpactSpeed;

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Damager")
        {
            return;
        }
        if (collision.relativeVelocity.sqrMagnitude < damageImpactSpeedSqr)
        {
            return;
        }

        //spriteRenderer.sprite = DamageSprite;
        CurrentHitPoints--;

        if (CurrentHitPoints <= 0)
        {
            kill();
        }
    }

    private void kill()
    {
        Collider2D BC2D;
        Rigidbody2D RG2D;
        ParticleSystem PS;

        PS = GetComponentInChildren<ParticleSystem>();
        this.transform.DOScale(0, 0.1f);
        //this.transform.DOShakeScale();
        //spriteRenderer.enabled = false;
        BC2D = GetComponent<BoxCollider2D>();
        BC2D.enabled = false; 
        RG2D = GetComponent<Rigidbody2D>();
        //RG2D.isKinematic = false;
        PS.Play();

    }

    // Update is called once per frame
    void Update () {
	
	}
}
