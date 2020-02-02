using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enable_floor : MonoBehaviour
{
    public GameObject Switch;

    // Update is called once per frame
    void Update()
    {
        if(Switch.GetComponent<Switch_function>().pressed)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
            this.GetComponent<Collider2D>().enabled = true;
        }
    }
}
