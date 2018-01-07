using UnityEngine;
using System.Collections;
using DG.Tweening;

public class NCCUW4GunManager : MonoBehaviour {

    public float MinmusShootTime;
    public float MuzzleShowTime;

    private float shootCount = 0;
    private float muzzleCount = 0;

    private AudioSource gunShootSound;

    public GameObject MuzzleFlash;
    public GameObject bulletCandidate;

    void Start()
    {
        gunShootSound = this.GetComponent<AudioSource>();
    }



    public void TryTriggerGun()
    {
        if (shootCount <=0 )
        {
            //先清掉舊音效
            gunShootSound.Stop();
            //設定一點隨機
            gunShootSound.pitch = Random.Range(0.8f, 1);
            //撥放
            gunShootSound.Play();

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
