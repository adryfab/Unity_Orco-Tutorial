using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemigo : MonoBehaviour
{
    public float vel = -1f;
    public GameObject bulletPrototype;
    Rigidbody2D rb;
    Animator anim;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
    void FixedUpdate()
    {
        Vector2 v = new Vector2(vel, 0);
        rb.velocity = v;
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
    }
}
