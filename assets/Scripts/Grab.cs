using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    // Variable que checkea si el objeto esta al alcance de ser agarrado
    private bool reach = false;
    private bool reachPendulo = false;
    // Variable que checkea si el objeto fue agarrado
    public bool grabbed = false;
    public bool grabbedPendulo = false;
    // GameObject del objeto agarrado
    private GameObject object_grabbed;
    private Rigidbody2D r2d, r2d2;
    private GameObject pendulo;
    private GameObject player;
    // velocidad del Jugador
    [SerializeField]
    private float speed;
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
        if (Input.GetButtonUp("Grab") && !reach) {
            grabbed = false;
        }

        if(Input.GetButton("Grab") && reachPendulo)
        {
            grabbedPendulo = true;

            player = GameObject.FindWithTag("Player");
            r2d = player.GetComponent<Rigidbody2D>();

            r2d.simulated = false;
            player.transform.parent = pendulo.transform;;
        }

        if (Input.GetButtonUp("Grab") && !reachPendulo) {
            player = GameObject.FindWithTag("Player");
            r2d = player.GetComponent<Rigidbody2D>();
            r2d.simulated = true;

            pendulo.transform.DetachChildren();

            // Actualizamos la posicion
            r2d2 = pendulo.GetComponent<Rigidbody2D>();
            r2d.velocity = new Vector2(2 * r2d2.velocity.x, 2 * r2d2.velocity.y);
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

        if (col.tag == "Pendulo") 
        {
            pendulo = col.gameObject;
            reachPendulo = true;
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

        if (col.tag == "Pendulo")
        {
            grabbedPendulo = false;
            reachPendulo = false;
        }
    }
}
