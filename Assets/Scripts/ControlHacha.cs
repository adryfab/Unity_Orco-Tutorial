using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlHacha : MonoBehaviour
{
    ControladorPersonaje ctr;

	// Use this for initialization
	void Start ()
    {
        ctr = GameObject.Find("orc").GetComponent <ControladorPersonaje> ();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("arbol"))
        {
            ctr.SetControlArbol(collision.gameObject.GetComponent<ControlArbol>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("arbol"))
        {
            ctr.SetControlArbol(null);
        }
    }
}
