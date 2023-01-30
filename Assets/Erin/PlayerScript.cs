using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float Speed = 5;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 UserInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        transform.Translate(UserInput * Speed * Time.deltaTime);
    }
}
