using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBala : MonoBehaviour {
    public float speed = 6;
    public float lifeTime = 2;
    public Vector3 direction = new Vector3(-1,0,0);

    Vector3 stepVector;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, lifeTime);
        rb = GetComponent<Rigidbody2D>();
        stepVector = speed * direction.normalized;
	}
	
    private void FixedUpdate() {
        rb.velocity = stepVector;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name.Equals("arbol")) {
            ControlArbol ctr = collision.gameObject.GetComponent<ControlArbol>();
            if (ctr != null)  ctr.RecibirDisparo();
            Destroy(gameObject);
        }
        if (collision.gameObject.name.Equals("orc")) {
            ControladorPersonaje ctr = collision.gameObject.GetComponent<ControladorPersonaje>();
            if (ctr != null) ctr.RecibirBala();
            Destroy(gameObject);
        }
    }
}
