using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManagerScript : MonoBehaviour
{

    public float TimerStat = 600;
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

     public void GetTimer()
    {

        GameObject Player = GameObject.FindGameObjectWithTag("Player");
       TimerStat= Player.GetComponent<PlayerScript>().Timer;
      
    }

    public void SetTimer()
    {
      GameObject Player = GameObject.FindGameObjectWithTag("Player");
        Player.GetComponent<PlayerScript>().Timer = TimerStat;
    }
}
