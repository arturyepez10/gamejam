using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enter_Level : MonoBehaviour
{
    private bool onDoor, momDoor, dadDoor;
    // Start is called before the first frame update
    void Start()
    {
        onDoor = false;
        momDoor = false;
        dadDoor = false;
    }
    void Update()
    {
        if(Input.GetButtonDown("Vertical") && onDoor)
        {
            Debug.Log("Holis");
        } else if(Input.GetButtonDown("Vertical") && momDoor) {
            SceneManager.LoadScene("Mom Dream");
        } else if(Input.GetButtonDown("Vertical") && dadDoor) {
            SceneManager.LoadScene("Dad Dream");
        }


    }

    private void OnTriggerEnter2D(Collider2D col)
    {       
            if (col.tag == "mom_door") {
                momDoor = true;
            } else if (col.tag == "dad_door") {
                dadDoor = true;
            } else if (col.tag == "self_dream") {
                onDoor = true;
                // Lo siento, el Jam dura 48 horas no 72 jeje
                //SceneManager.LoadScene("Hub");
            }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "mom_door")
        {
            momDoor = false;
        } else if (col.tag == "dad_door") {
            dadDoor = false;
        } else if (col.tag == "self_dream") {
            onDoor = false;
        }
    }
}
