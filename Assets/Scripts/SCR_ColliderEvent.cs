using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SCR_ColliderEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent Event;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
          
            Event.Invoke();
        }
    }
}
