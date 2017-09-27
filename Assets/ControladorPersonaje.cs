using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorPersonaje : MonoBehaviour
{
    public float maxVel = 5f;
    public float jump = 1f;
    public Slider slider;
    public Text txt;
    public float energy = 100f;
    public int costoGolpeAlAire = 1;
    public int costoGolpeAlArbol = 3;
    public int premioArbol = 15;
    public GameObject hacha = null;

    Rigidbody2D rgb;
    Animator anim;
    bool haciaDerecha = true;
    ControlArbol crtArbol = null;
    bool enFire = false;

	// Use this for initialization
	void Start ()
    {
        rgb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        energy = 100;
        hacha = GameObject.Find("/orc/orc_body/orc _R_arm/orc _R_hand/orc_weapon");
    }

    private void Update()
    {
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
        //anim.SetFloat("speed", vel.x);

        //if (haciaDerecha = true && v < 0)
        //{
        //    haciaDerecha = false;
        //    Flip();
        //}
        //else if (haciaDerecha = false && v > 0)
        //{
        //    haciaDerecha = true;
        //    Flip();
        //}

        if (Input.GetAxis("Jump")>0)
        {
            rgb.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
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
}
