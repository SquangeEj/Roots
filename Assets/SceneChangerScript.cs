using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerScript : MonoBehaviour
{
    [SerializeField] private int SceneToLoad;
    [SerializeField] private GameObject StatsMan;



    private void Start()
    {
        StatsMan = GameObject.FindGameObjectWithTag("StatsManager");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log(other);
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("touched player");

            StatsMan.GetComponent<StatsManagerScript>().GetTimer();
            SceneManager.LoadScene(SceneToLoad);
        }
    }
}
