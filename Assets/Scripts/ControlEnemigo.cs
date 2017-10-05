using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlEnemigo : MonoBehaviour
{
    public float vel = -1f;
    Rigidbody2D rb;
    Animator anim;

    public GameObject bulletPrototype;

    public Slider slider;
    public Text txt;

    public int energy = 100;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (energy <= 0)
        {
            energy = 0;
            anim.SetTrigger("morir");
        }
        slider.value = energy;
        txt.text = energy.ToString();
    }

    void FixedUpdate()
    {
        Vector2 v = new Vector2(vel, 0);
        rb.velocity = v;

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Caminando") && Random.value < 1f / (60f * 3f))
        {
            anim.SetTrigger("apuntar");
        } else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Apuntando"))
        {
            if (Random.value < 1f / 3f)
            {
                anim.SetTrigger("disparar");
            }
            else
            {
                anim.SetTrigger("caminar");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Flip();
    }

    void Flip()
    {
        vel *= -1;

        var s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }

    public void Disparar()
    {
        anim.SetTrigger("apuntar");
    }

    public void EmitirBala()
    {
        GameObject bulletCopy = Instantiate(bulletPrototype);
        bulletCopy.transform.position = new Vector3(transform.position.x, transform.position.y, -1f);
        bulletCopy.GetComponent<ControlBala>().direction = new Vector3(transform.localScale.x, 0, 0);

        energy--;
    }

    public void BajarPuntosPorOrcoCerca()
    {
        energy--;
    }
}
