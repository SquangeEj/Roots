using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private GameObject PlayerMenu;
    [SerializeField] private Animator anim;
    [SerializeField] private Slider HealthSlider;
    [SerializeField] private SpriteRenderer SpriteRend;
    [SerializeField] private FieldOfView fovscript;
    [SerializeField] private float Speed = 5;
    [SerializeField] private float townmult=1 ;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject statsman;
    [SerializeField] private Slider Sldr;
    private float stamina = 15f;
    private Vector2 UserInput;

     public float Timer = 600;


    void Start()
    {
        statsman = GameObject.FindGameObjectWithTag("StatsManager");
        if (statsman != null)
        {
            statsman.GetComponent<StatsManagerScript>().SetTimer();
        }
        PlayerMenu.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.M))
            {
            PlayerMenu.SetActive(!PlayerMenu.activeSelf);

        }

        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (Vector2)((worldMousePos - transform.position));
        direction.Normalize();
        

        fovscript.viewDistance = 25 * Timer/ 600;
        fovscript.SetAimDirection(direction);
        fovscript.SetOrigin(transform.position);
            

        Timer -= 1 * Time.deltaTime;
        HealthSlider.value = -Timer;

        UserInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if(Timer < 0)

        {
            SceneManager.LoadScene(6);
        }


   /*     if(Input.GetAxis("Horizontal") <0)
        {
            SpriteRend.flipX = false;
        }
        else if(Input.GetAxis("Horizontal") > 0)
        {
            SpriteRend.flipX = true;
        }*/
     anim.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        anim.SetFloat("Vertical", Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            stamina -= 1 * Time.deltaTime;
            Speed = 12 * townmult;
            Sldr.value = stamina;
        }
        else
        {
            if (stamina < 15f)
            {
                stamina += 1 * (Time.deltaTime * (Timer/1200)) ;
                Sldr.value = stamina;
            }
            Speed = 6 * townmult;
        }
      
        rb.MovePosition(rb.position + UserInput * (Speed * Time.deltaTime) * Timer/600);
    }

   
}
