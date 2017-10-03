using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDisparo : MonoBehaviour {
    Collider2D disparandoA = null;
    public float probabilidadDeDisparo = 1f;

    ControlEnemigo ctr;

	// Use this for initialization
	void Start () {
        ctr = GameObject.Find("enemigo").GetComponent<ControlEnemigo>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("arbol") && disparandoA == null)
        {
            DecidaSiDispara(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == disparandoA)
        {
            disparandoA = null;
        }
    }

    void DecidaSiDispara(Collider2D other)
    {
        if (Random.value < probabilidadDeDisparo)
        {
            Disparar();
            disparandoA = other;
        }
    }

    void Disparar()
    {
        ctr.Disparar();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
