using UnityEngine;
using System.Collections;
using DG.Tweening;
using System.Collections.Generic;



public class GameLoopManager : MonoBehaviour {

    public AudioSource bgmAudioSource;
    public HUE_Rotate hueRotate;

    public AudioSource bgmAudio;
    private float bgmValume;
    public ScoreManager ScoreManager;
    public TurrentManagerScript TurrentManagerScript;

    public List<BulletScript>bullets;

    public PlayerController PlayerController;
    public FollowTheBeat FollowTheBeat;

    public bool playerAlive = true;

    public float TimeScaleCounter ;

    public void GameOver()
    {
        DOTween.To(() => Time.timeScale, (x) => Time.timeScale = x, 0, 1f).SetUpdate(true);
        bgmAudioSource.DOFade(0, 0.5f).OnComplete(()=> 
        {
            bgmAudioSource.Stop();
        }
        ).SetUpdate(true);

        hueRotate.RotateValue = Mathf.PI;

        playerAlive = false;
    }

	// Use this for initialization
	void Start () {
        this.bgmValume = bgmAudio.volume;
    }
	
	// Update is called once per frame
	void Update () {
        TimeScaleCounter = Time.timeScale;
        if (playerAlive == false)
        {

            if (TimeScaleCounter == 0) //防按太快當機
            {
                if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.R))
                {
                    RestartGame();
                }
            }
        }
	}

    public void RestartGame()
    {
        playerAlive = true;
        hueRotate.RotateValue = 0;
        ScoreManager.Reset();
        PlayerController.Reset();
        FollowTheBeat.Reset();
        TurrentManagerScript.Reset();
            
           

        for (int i = 0; i < bullets.Count; i++)
        {
            GameObject.Destroy(bullets[i].gameObject);
        }

        bullets.Clear();
        bgmAudio.volume = bgmValume;
        bgmAudio.Play();
        Time.timeScale = 1;
    }
}
