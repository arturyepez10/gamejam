using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enter_Level : MonoBehaviour
{
    private bool onDoor;
    // Start is called before the first frame update
    void Start()
    {
        onDoor = false;
    }
    void Update()
    {
        if(Input.GetButtonDown("Vertical") && onDoor)
        {
            Debug.Log("Holis");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            onDoor = true;
            Debug.Log("Magic");
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            onDoor = false;
        }
    }
}
