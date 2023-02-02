using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{

    [SerializeField] private float damage;
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision);
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("damaging");
            collision.gameObject.GetComponent<PlayerScript>().Timer -=damage;
        }
    }
}
