using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlArbol : MonoBehaviour
{
    public int numGolpesParaCaer = 3;
    Animator anim;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public bool GolpeOrco()
    {
        bool resp = false;
        numGolpesParaCaer--;
        if (numGolpesParaCaer<=0)
        {
            anim.SetTrigger("caer");
            resp = true;
        }
        return resp;
    }
}
