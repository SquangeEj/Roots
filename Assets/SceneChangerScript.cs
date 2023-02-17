using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerScript : MonoBehaviour
{
    [SerializeField] private int SceneToLoad;
    [SerializeField] private GameObject StatsMan;
    [SerializeField] private Animator anim;
    [SerializeField] private bool Urgent = false;



    private void Start()
    {
        anim = GetComponent<Animator>();
        StatsMan = GameObject.FindGameObjectWithTag("StatsManager");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log(other);
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("LoadOut");
            if(Urgent == true)
            {
                StatsMan.GetComponent<StatsManagerScript>().GetTimer();
                SceneManager.LoadScene(SceneToLoad);
            }
        }
    }

    public void Next()
    {
        StatsMan.GetComponent<StatsManagerScript>().GetTimer();
        SceneManager.LoadScene(SceneToLoad);
    }
}
