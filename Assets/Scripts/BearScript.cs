using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearScript : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody2D rb2d;
    [SerializeField] private float speed;
    [SerializeField] private SpriteRenderer SPRT;
    private bool chase = false;
    [SerializeField] private float damage;
    void Start()
    {
      
        Player = GameObject.FindGameObjectWithTag("Player");
        rb2d = GetComponent<Rigidbody2D>();
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
            rb2d.AddForce( (Player.transform.position - transform.position) * speed, ForceMode2D.Force);
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
