using UnityEngine;
using System.Collections;

public class NCCUBulletScript : MonoBehaviour {

    public float FlySpeed;
    public float LifeTime;
    public float damageValue = 15f;
    public GameObject explosion;

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
        if (other.gameObject.GetComponent<Animator>())
        {
            other.gameObject.SendMessage("Hit", damageValue);
        }

        explosion.gameObject.transform.parent = null;
        explosion.gameObject.SetActive(true);

        KillSelf();
    }

}
