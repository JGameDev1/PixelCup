using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{   public Text golesTxtT1,golesTxtT2,timer;
    public Image flagT1,flagT2;
    public Text ItemsColected;
    public int timerValue,n;
    public float timeTimer;

    private void Awake()
    {
        if(SceneManager.GetActiveScene().name=="Runner")
        {
        ItemsColected = GameObject.Find("Score").GetComponent<Text>();
        timer = GameObject.Find("timer").GetComponent<Text>();
        }else
        {
        ItemsColected = GameObject.Find("Score").GetComponent<Text>();
        golesTxtT1 = GameObject.Find("golesTxtT1").GetComponent<Text>();
        golesTxtT2 = GameObject.Find("golesTxtT2").GetComponent<Text>();
        timer = GameObject.Find("timer").GetComponent<Text>();
        flagT1 = GameObject.Find("flagT1").GetComponent<Image>();
        flagT2 = GameObject.Find("flagT2").GetComponent<Image>();
        }
    }

    private void Start()
    {   ItemsColected.text = 0.ToString();
        timer.text= timerValue.ToString();
        if(SceneManager.GetActiveScene().name!=("Runner")) 
        {
         golesTxtT1.text = 0.ToString();
         golesTxtT2.text = 0.ToString();
        }
    }

    private void Update()
    {timeTimer= Time.time;
        ItemsColected.text = GameManager.sharedInstance.myScore.ToString();
        if(Time.time>=2*n)
        {n++;
        timerValue--;}
        timer.text=timerValue.ToString();
    }
}