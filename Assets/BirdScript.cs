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
    [SerializeField] private SpriteRenderer SPRT;
    void Start()
    {
        ADS = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Active == true)
        {

            Vector3 localPos = Target.transform.InverseTransformPoint(transform.position);
            if (localPos.x < 0.0f)
            {
                SPRT.flipX = false;
            }
            else if (localPos.x > 0.0f)
            {
                SPRT.flipX = true;
            }
            else return;

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
