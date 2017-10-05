using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDanioEnemigo : MonoBehaviour {
    Collider2D colliderEnem = null;
    public int delayBajarPuntosEnemigo = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("enemigo") && colliderEnem == null)
        {
            Debug.Log("Colision con el enemigo");
            colliderEnem = collision;
            Invoke("BajarPuntosEnemigo", delayBajarPuntosEnemigo);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == colliderEnem)
        {
            Debug.Log("Salir de colision con el enemigo");
            colliderEnem = null;
            CancelInvoke("BajarPuntosEnemigo");
        }
    }

    void BajarPuntosEnemigo()
    {
        Debug.Log("BajarPuntosEnemigo");
        colliderEnem.gameObject.GetComponent<ControlEnemigo>().BajarPuntosPorOrcoCerca();
    }
}
