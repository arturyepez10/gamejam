using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_function : MonoBehaviour
{
    public bool pressed = false;
    SpriteRenderer SR_switch;

    void Start()
    {
        SR_switch = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if((col.tag == "Player") || (col.tag == "Mother"))
        {
            pressed = true;
            SR_switch.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if((col.tag == "Player") || (col.tag == "Mother"))
        {
            pressed = false;
            SR_switch.enabled = true;
        }
    }
}
