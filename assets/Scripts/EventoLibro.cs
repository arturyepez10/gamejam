using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventoLibro : MonoBehaviour
{

    private Rigidbody2D rb2d;

    // Start is called before the first frame update

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Floor")
        {
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
