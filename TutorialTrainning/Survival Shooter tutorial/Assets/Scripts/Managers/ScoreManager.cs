using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int ScorePoint;
    public GameObject ScoreText;

    Text text;


    void Awake ()
    {
        text = ScoreText.GetComponent<Text> ();
        ScorePoint = 0;
    }


    void Update ()
    {
        text.text = ScorePoint.ToString();
    }
}
