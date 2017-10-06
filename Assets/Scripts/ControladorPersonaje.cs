using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorPersonaje : MonoBehaviour
{
    Rigidbody2D rgb;
    Animator anim;
    public float maxVel = 5f;
    bool haciaDerecha = true;
    public Slider slider;
    public Text txt;
    public float energy = 100f;
    
    public int costoGolpeAlAire = 1;
    public int costoGolpeAlArbol = 3;
    public int premioArbol = 15;

    bool enFire = false;

    ControlArbol crtArbol = null;
    public GameObject hacha = null;

    public bool jumping = false;
    public float yJumpForce = 300;
    Vector2 jumpForce;

    public float jump = 1f;

    public float costoBala = 3f;
    public bool isOnTheFloor = false;

    // Use this for initialization
    void Start ()
    {
        rgb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        hacha = GameObject.Find("/orc/orc_body/orc _R_arm/orc _R_hand/orc_weapon");
        energy = 100;

        jumpForce = new Vector2(0, 0);
    }

    private void Update()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("muriendo"))
        {
            if (energy <= 0)
            {
                energy = 0;
                anim.SetTrigger("morir");
            }
            else
            {
                return;
            }
        }

        if (Mathf.Abs(Input.GetAxis("Fire1")) > 0.01f)
        {
            if (enFire == false)
            {
                enFire = true;
                hacha.GetComponent<CircleCollider2D>().enabled = false;
                anim.SetTrigger("attack");
                if (crtArbol != null)
                {
                     if (crtArbol.GolpeOrco()==true)
                    {
                        energy += premioArbol;
                        if (energy > 100)
                        {
                            energy = 100;
                        }
                    }
                    else
                    {
                        energy -= costoGolpeAlArbol;
                    }
                }
                else
                {
                    energy -= costoGolpeAlAire;
                }
            }
            else
            {
                enFire = false;
            }
        }
        slider.value = energy;
        txt.text = energy.ToString();
    }

    void FixedUpdate()
    {
        float v = Input.GetAxis("Horizontal");
        Vector2 vel = new Vector2(0, rgb.velocity.y);
        v *= maxVel;
        vel.x = v;
        rgb.velocity = vel;

        // Nueva variable agregada para corregir el error del salto infinito
        isOnTheFloor = rgb.velocity.y == 0;

        if (Input.GetAxis("Jump")>0)
        {
            // ahora solo puede saltar si la velocidad del RGB es 0 en su componente 'y' es decir que no este cayendo o subiendo.
            if (!jumping && isOnTheFloor)
            {
                jumping = true;
                jumpForce.x = 0f;
                jumpForce.y = yJumpForce;
                rgb.AddForce(jumpForce);
            }
            else
                jumping = false;
        }
    }

    void Flip()
    {
        var s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }

    public void SetControlArbol(ControlArbol crt)
    {
        crtArbol = crt;
    }

    public void HabilitarTriggerHacha()
    {
        hacha.GetComponent<CircleCollider2D>().enabled = true;
    }

    public void RecibirBala() {
        energy -= costoBala;
    }
}
