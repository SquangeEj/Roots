using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootPersonScript : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private void Start()
    {

        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            anim.SetTrigger("Triggered");
            Destroy(GetComponent<BoxCollider2D>());
        }
    }
}
