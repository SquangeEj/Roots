using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_HEDGEHOG: MonoBehaviour
{
    private GameObject Player;
   
    [SerializeField] private float speed;
    [SerializeField] private SpriteRenderer SPRT;
    private bool chase = false;
    [SerializeField] private float damage;
    void Start()
    {

        Player = GameObject.FindGameObjectWithTag("Player");
      
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 localPos = Player.transform.InverseTransformPoint(transform.position);
        if (localPos.x < 0.0f)
        {
            SPRT.flipX = false;
        }
        else if (localPos.x > 0.0f)
        {
            SPRT.flipX = true;
        }
        else return;

        if (chase == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed*Time.deltaTime);    
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            chase = true;
        }
    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            collision.gameObject.GetComponent<PlayerScript>().Timer -= damage;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            chase = false;
        }
    }
}
