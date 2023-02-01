using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer SpriteRend;
    [SerializeField] private FieldOfView fovscript;
    [SerializeField] private float Speed = 5;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Slider Sldr;
    private float stamina = 15f;
    private Vector2 UserInput;

    [SerializeField] private float Timer = 600;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (Vector2)((worldMousePos - transform.position));
        direction.Normalize();
        

        fovscript.viewDistance = 25 * Timer/ 600;
        fovscript.SetAimDirection(direction);
        fovscript.SetOrigin(transform.position);
            

        Timer -= 1 * Time.deltaTime;
        
        UserInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));


   /*     if(Input.GetAxis("Horizontal") <0)
        {
            SpriteRend.flipX = false;
        }
        else if(Input.GetAxis("Horizontal") > 0)
        {
            SpriteRend.flipX = true;
        }*/
     anim.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        
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
            if (stamina < 15f)
            {
                stamina += 1 * (Time.deltaTime * (Timer/1200)) ;
            }
            Speed = 6;
        }
        Debug.Log(stamina);
        rb.MovePosition(rb.position + UserInput * (Speed * Time.deltaTime) * Timer/600);
    }
}
