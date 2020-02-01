using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab_madre : MonoBehaviour
{
    private bool madre_grabbed = true;
    [SerializeField]
    private GameObject parent;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Grab Parent") && madre_grabbed)
        {
            parent.GetComponent<Detect>().enabled = false;
            madre_grabbed = false;
        }
        else if(Input.GetButtonDown("Grab Parent") && !madre_grabbed)
        {
            parent.GetComponent<Detect>().enabled = true;
            madre_grabbed = true;
        }
    }
}
