using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class BirdTrigger : MonoBehaviour
{
    [SerializeField] private bool IsActivater;
    [SerializeField] private GameObject BirdToActivate;
    [SerializeField]
    private CinemachineVirtualCamera Vcam1;
    [SerializeField]
    private CinemachineVirtualCamera Vcam2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Vcam1.Priority = 0;
            Vcam2.Priority = 1;
            BirdToActivate.GetComponent<BirdScript>().Active = true;
            BirdToActivate.GetComponent<AudioSource>().Play();
        }
    }
}
