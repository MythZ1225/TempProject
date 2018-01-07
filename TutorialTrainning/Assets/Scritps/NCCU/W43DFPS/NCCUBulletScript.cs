using UnityEngine;
using System.Collections;

public class NCCUBulletScript : MonoBehaviour {

    public float FlySpeed;
    public float LifeTime;
    public float damageValue = 15f;
    public GameObject explosion;
    public AudioSource bulletSound;

    public void InitAndShoot(Vector3 Direction)
    {
        Rigidbody BulletRB = this.GetComponent<Rigidbody>();
        BulletRB.velocity = Direction * FlySpeed;
        Invoke("KillSelf", LifeTime);
    }

    public void KillSelf()
    {
        GameObject.Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.GetComponent<Animator>() || other.gameObject.GetComponent<NCCUW4BreakableItems>())
        {
            other.gameObject.SendMessage("Hit", damageValue);
            //Debug.Log("Hit");
        }
        
        explosion.gameObject.transform.parent = null;
        explosion.gameObject.SetActive(true);

        bulletSound.pitch = Random.Range(0.8f, 1);

        KillSelf();
    }

}
