using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    [SerializeField] private GameObject Target;
    [SerializeField] private int Speed;
    private float volume = 0;
    private AudioSource ADS;
    public bool Active;
    void Start()
    {
        ADS = GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Active == true)
        {
            if (volume < 1)
            {
                volume += 1 * Time.deltaTime;
                ADS.volume = volume;
            }
          
            transform.position += (Target.transform.position - transform.position) * Speed / 5 * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, Speed * Time.deltaTime);
        }
    }
}
