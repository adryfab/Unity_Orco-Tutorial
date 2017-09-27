using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemigo : MonoBehaviour
{
    public float vel = -1f;
    Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
    void FixedUpdate()
    {
        Vector2 v = new Vector2(vel, 0);
        rb.velocity = v;
    }
}
