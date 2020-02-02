using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    // Fuerza de salto
    [SerializeField]
    private float jump = 230f;
    // Rigidbody del Jugador
    private Rigidbody2D r2d;
    // Variable que checkea si el Jugador toca el piso
    private bool grounded = false;
    private bool alreadyDJ = false;
    [SerializeField]
    private bool djEnabled = true;
    // Vector con la posicion actual antes de saltar
    private Vector3 current_pos;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Obtiene el componente Rigidbody2D
        r2d = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is called once per frame
    void Update()
    {
        // Si se preciona espacio y el jugador esta en el piso
        if(Input.GetKeyDown("space") && grounded)
        {
            // Agrega fuerza de salto al jugador
            r2d.AddForce(Vector2.up * jump);
            current_pos = transform.position;
            grounded = false;                             // **Ponemos grounded aqui en vez de OnCollisionExit2D() ya que puede tardar unos microsegundos en cambiarse y nos agrega una fuerza mucho mayor. En cambio aqui el cambio de grounded se realiza al instante.
            
        }
        else if (Input.GetKeyDown("space") && !grounded && !alreadyDJ && djEnabled)
        {
            r2d.velocity = (Vector2.right * r2d.velocity.x);
            r2d.AddForce(Vector2.up * jump);
            current_pos = transform.position;
            grounded = false;  
            alreadyDJ = true;

          
        }

        if (!grounded)
        {
            animator.SetBool("Player_jump", true);
        }
        else
        {
            animator.SetBool("Player_jump", false);
        }

        // Cuando el salto llega a su limite, el Jugador se regresa al piso
        if (transform.position.y >= current_pos.y + 1f)
        {
            r2d.velocity = (Vector2.right * r2d.velocity.x) + (Vector2.up * -2f);
        }
    }

    // Detecta una colision
    private void OnCollisionEnter2D(Collision2D col) 
    {
        // Si el jugador colisiona (toca) el piso
        if (col.gameObject.tag == "Floor")
        {
            // marcamos que esta en el piso
            grounded = true;
            alreadyDJ = false;

            // Hacemos esto para evitar inconsistencias en la fuerza de salto
            r2d.velocity = Vector3.zero;
            r2d.angularVelocity = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
         // Si el jugador colisiona (toca) el piso
        if (col.gameObject.tag == "Obstacle")
        {
            // marcamos que esta en el piso
            grounded = true;
            alreadyDJ = false;

            // Hacemos esto para evitar inconsistencias en la fuerza de salto
            r2d.velocity = Vector3.zero;
            r2d.angularVelocity = 0f;
        }
    }
}
