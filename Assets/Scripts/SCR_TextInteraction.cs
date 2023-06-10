using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class SCR_TextInteraction : MonoBehaviour
{
  [SerializeField]  private UnityEvent Event;
    [SerializeField] private float Time;
    private bool interacted;

    private void OnMouseDown()
    {
        if (interacted != true)
        {
            interacted = true;
            StartCoroutine(InteractedText());
        }
    }

    private IEnumerator InteractedText()
    {

        Event.Invoke();

        yield return new WaitForSeconds(Time);

        interacted = false;
    }
}
