using UnityEngine;
using System.Collections;
using DG.Tweening;

public class NCCUW4GunManager : MonoBehaviour {

    public float MinmusShootTime;
    public float MuzzleShowTime;

    private float shootCount = 0;
    private float muzzleCount = 0;

    public GameObject MuzzleFlash;
    public GameObject bulletCandidate;

    public void TryTriggerGun()
    {
        if (shootCount <=0 )
        {
            this.transform.DOShakeRotation(MinmusShootTime * 0.8f, 3f);

            muzzleCount = MuzzleShowTime;
            MuzzleFlash.transform.localEulerAngles = new Vector3(0, 0, Random.Range(0, 360));

            shootCount = MinmusShootTime;

            GameObject newBullet;
            newBullet = Instantiate(bulletCandidate);
            newBullet.transform.position = MuzzleFlash.transform.position;
            newBullet.transform.rotation = MuzzleFlash.transform.rotation;

            NCCUBulletScript bullet = newBullet.GetComponent<NCCUBulletScript>();
            bullet.InitAndShoot( MuzzleFlash.transform.forward);
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (shootCount >0)
        {
            shootCount -= Time.deltaTime;
        }
        if (muzzleCount >0)
        {
            muzzleCount -= Time.deltaTime;
            MuzzleFlash.gameObject.SetActive(true);
        }
        else
        {
            MuzzleFlash.gameObject.SetActive(false);
        }
	}
}
