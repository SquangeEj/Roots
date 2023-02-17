using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private Animator anim;
//   [SerializeField] private GameObject Disalbe;
    [SerializeField] private AudioSource ads;
    [SerializeField] private GameObject MeatSound;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    public void PlayTheSound()
    {
        ads.pitch = Random.Range(0.5f, 1.2f);
        ads.Play();
    }
    public void startintro()
    {
        
        anim.SetTrigger("Started");
    }
    public void ActuallyPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void SndSpawnMeat()
    {
        Instantiate(MeatSound);
    }
}
