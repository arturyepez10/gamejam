using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    // Variable que checkea si el objeto esta al alcance de ser agarrado
    private bool reach = false;
    // Variable que checkea si el objeto fue agarrado
    public bool grabbed = false;
    // GameObject del objeto agarrado
    private GameObject object_grabbed;
    // velocidad del Jugador
    [SerializeField]
    private float speed = 5f;
    // Direccion de movimiento
    private float moveHorizontal;

    void Update()
    {
        // Si el jugador presiona 'E' y esta al alcance, agarra un objeto
        if(Input.GetButton("Grab") && reach)
        {
            // El objeto se mueve con el Jugador
            moveHorizontal = Input.GetAxisRaw("Horizontal");
            grabbed = true;
            // Actualizamos la posicion
            object_grabbed.transform.position += new Vector3(speed * Time.deltaTime * moveHorizontal, 0f, 0f);
        }
        // Si se suelta la 'E', el Jugador suelta el objeto
        if(Input.GetButtonUp("Grab"))
        {
            grabbed = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Si collisiona con el Objeto, toma su GameObject y esta al alcance de ser agarrado
        if(col.tag == "Obstacle")
        {
            object_grabbed = col.gameObject;
            reach = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        // Si se aleja del trigger, el objeto ya no esta al alcance de ser agarrado
        // O se suelta
        if(col.tag == "Obstacle")
        {
            grabbed = false;
            reach = false;
        }
    }
}
