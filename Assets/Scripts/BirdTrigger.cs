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

    [SerializeField] private GameObject PlayerVision;
    [SerializeField] private bool Is2chase = false;



    private void Update()
    {
     
        if(Is2chase == true)
        {
            PlayerVision.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (Vcam1 != null)
            {
                Vcam1.Priority = 0;
                Vcam2.Priority = 1;
            }
            if(PlayerVision != null)
            {
                 Is2chase = true;
            }
            BirdToActivate.GetComponent<BirdScript>().Active = true;
            BirdToActivate.GetComponent<AudioSource>().Play();
        }
    }
}
