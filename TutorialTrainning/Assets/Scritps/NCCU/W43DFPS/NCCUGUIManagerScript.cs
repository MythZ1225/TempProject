using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class NCCUGUIManagerScript : MonoBehaviour {
    public Image BlackCover;
    public Image BloodBlur;
    public Text HPText;

    private Tween _tweemAnimation;
	// Use this for initialization
	void Start () {
        BlackCover.color = Color.black;
        DOTween.To(() => BlackCover.color, (x) => BlackCover.color = x, new Color(0, 0, 0, 0),1f);
	}

    public void playHitAnimation()
    {
        if (_tweemAnimation !=null)
          _tweemAnimation.Kill();

        BloodBlur.color = Color.white;
        _tweemAnimation = DOTween.To(()=> BloodBlur.color,(x) => BloodBlur.color = x,new Color(1,1,1,0),0.5f);
    }

    public void PlayDieAnimation()
    {
        BloodBlur.color = Color.white;
        DOTween.To(() => BlackCover.color, (x) => BlackCover.color = x, new Color(0, 0, 0, 1), 1f).SetDelay(3)
            .OnComplete(()=> 
            {
                SceneManager.LoadScene("NCCUWeek43DFPS");
            }            
            );
    }

    public void SetHp(int hP)
    {
        HPText.text = "HP : " + hP;
    }

	// Update is called once per frame
	void Update () {
	
	}
}
