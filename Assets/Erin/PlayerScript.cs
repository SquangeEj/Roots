using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float Speed = 5;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Slider Sldr;
    private float stamina = 6f;
    private Vector2 UserInput;

    [SerializeField] private float Timer = 600;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= 1 * Time.deltaTime;
        
        UserInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            stamina -= 1 * Time.deltaTime;
            Speed = 12;
        }
        else
        {
            if (stamina < 6f)
            {
                stamina += 1 * (Time.deltaTime * (Timer/1200)) ;
            }
            Speed = 6;
        }
        Debug.Log(stamina);
        rb.MovePosition(rb.position + UserInput * (Speed * Time.deltaTime) * Timer/600);
    }
}
