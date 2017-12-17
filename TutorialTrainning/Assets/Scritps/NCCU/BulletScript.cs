using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{

    private Rigidbody2D RG2D;
    private SpriteRenderer spriteRenderer;

    //速度調慢一點
    private float speed = 2;

    const float flashDuration = 0.1f; //閃光的時間長度
    private float flashCounter = 0;   //計算閃光用的記錄器

    public void InitAndShoot(Vector2 direction)
    {
        RG2D = this.GetComponent<Rigidbody2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();

        spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        RG2D.velocity = speed * direction;
        //閃光功能 當子彈射出後子彈會有0.1秒的時間由白變綠
        flashCounter = flashDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (RG2D.velocity == Vector2.zero)
        {
            //確保沒有人停下來
            RG2D.velocity = new Vector2(Random.Range(0, 1.0f), Random.Range(0, 1.0f)).normalized * speed;
        }
        else
        {
            //確保碰撞後速度不變
            RG2D.velocity = RG2D.velocity.normalized * speed;
        }

        float rotationZ = Mathf.Atan2(RG2D.velocity.y, RG2D.velocity.x) / Mathf.Rad2Deg;
        //Debug.Log("rotationZ = "+ rotationZ);

        this.transform.eulerAngles = new Vector3(0, 0, rotationZ);

        //閃光功能 當子彈射出後子彈會有0.1秒的時間由白變綠，之後就一直為綠色
        if (flashCounter >0)
        {
            flashCounter -= Time.deltaTime;
            spriteRenderer.color = Color.white;
           // Debug.Log("flashCounter = " + flashCounter);
        }
        else
        {
            spriteRenderer.color = Color.green;
        }
    }

    //當子彈碰撞時，讓flashCounter = flashDuration 這樣就可以讓 flashCounter>0 使子彈有 flashDuration 的白色閃光時間
    private void OnCollisionEnter2D(Collision2D collision)
    {
        flashCounter = flashDuration;
        //Debug.Log("flashCounter = " + flashCounter);
    }

}
