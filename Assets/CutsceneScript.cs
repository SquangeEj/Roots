using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneScript : MonoBehaviour
{
    [SerializeField] private AudioSource ADS;
    [SerializeField] private bool Closegame;
    private int SceneToload;
   

    public void closegame()
    {
        if (Closegame == true)
        {


            Application.Quit();
        }
        if(Closegame == false)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void PlaySound()
    {
        ADS.pitch = Random.Range(0.3f, 1.2f);
        ADS.Play();
    }
}
