using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{

    public GameObject padre;
    private int distancia = 10;
    private float offset = 0.5f;
    // velocidad del Jugador
    [SerializeField]
    private float speed = 5f;
    // Direccion de movimiento
    private float moveHorizontal;
    [SerializeField]
    private float jump = 60f;
    // Rigidbody del Jugador
    private Rigidbody2D r2d;
    // Variable que checkea si el Jugador toca el piso
    private bool grounded = false;
    private bool alreadyDJ = false;
    [SerializeField]
    private bool djEnabled = true;
    // Vector con la posicion actual antes de saltar
    private Vector3 current_pos;
    public GameObject libreria;

    // Start is called before the first frame update
    void Start()
    {
        // Obtiene el componente Rigidbody2D
        r2d = GetComponent<Rigidbody2D>();

    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D choque= CheckRaycastRight(Vector2.right * distancia, offset);

        Movement(choque);

        choque = CheckRaycastLeft(Vector2.left * distancia, -offset);

        Movement(choque);
    }

    private RaycastHit2D CheckRaycastRight(Vector2 direccion, float offset)
    {

        Vector2 startingpoint = new Vector2(padre.transform.position.x+offset,padre.transform.position.y);
        Debug.DrawRay(startingpoint,direccion);
        return Physics2D.Raycast(startingpoint,direccion, distancia);
    }

    private RaycastHit2D CheckRaycastLeft(Vector2 direccion, float offset)
    {
        Vector2 startingpoint = new Vector2(padre.transform.position.x + offset, padre.transform.position.y);
        Debug.DrawRay(startingpoint, direccion);
        return Physics2D.Raycast(startingpoint, direccion, distancia);
    }

    void Movement(RaycastHit2D choque)
    {
        if (choque.collider)
        {
            if (choque.collider.tag == "Player" && choque.distance < 6f && choque.distance > 0.5f)
            {
                if (CheckRaycastRight(Vector2.right * distancia, offset))
                {
                    moveHorizontal = 1f;
                }
                else if (CheckRaycastLeft(Vector2.left * distancia, -offset))
                {
                    moveHorizontal = -1f;
                }
                
                // Actualizamos la posicion

                transform.position += new Vector3(speed * Time.deltaTime * moveHorizontal , 0f, 0f);

                // Si se mueve en direccion contraria , rota 180 grados
                if ((moveHorizontal < 0))
                {
                    transform.rotation = Quaternion.Euler(Vector3.up * 180);
                }
                if ((moveHorizontal > 0))
                {
                    transform.rotation = Quaternion.Euler(Vector3.up * 0);
                }
            }

            if (choque.collider.name == "Libros" && choque.distance < 6f && choque.distance > 0.5f)
            {
                if (CheckRaycastRight(Vector2.right * distancia, offset))
                {
                    moveHorizontal = 1f;
                }
                else if (CheckRaycastLeft(Vector2.left * distancia, -offset))
                {
                    moveHorizontal = -1f;
                }

                // Actualizamos la posicion

                transform.position += new Vector3(speed * Time.deltaTime * moveHorizontal, 0f, 0f);

                // Si se mueve en direccion contraria , rota 180 grados
                if ((moveHorizontal < 0))
                {
                    transform.rotation = Quaternion.Euler(Vector3.up * 180);
                }
                if ((moveHorizontal > 0))
                {
                    transform.rotation = Quaternion.Euler(Vector3.up * 0);
                }
            }

            if (choque.collider.name == "Libros" && choque.distance <= 0.5f)
            {
                if (CheckRaycastRight(Vector2.right * distancia, offset))
                {
                    moveHorizontal = 1f;
                    
                }
                else if (CheckRaycastLeft(Vector2.left * distancia, -offset))
                {
                    moveHorizontal = -1f;
                }

                
                   // Si se preciona espacio y el jugador esta en el piso
                    if (grounded)
                    {
                        // Agrega fuerza de salto al jugador
                        r2d.AddForce(Vector2.up * jump);
                        current_pos = transform.position;
                        grounded = false;     // **Ponemos grounded aqui en vez de OnCollisionExit2D() ya que puede tardar unos microsegundos en cambiarse y nos agrega una fuerza mucho mayor. En cambio aqui el cambio de grounded se realiza al instante.
                    }
                    else if (!grounded && !alreadyDJ && djEnabled)
                    {
                        r2d.velocity = (Vector2.right * r2d.velocity.x);
                        r2d.AddForce(Vector2.up * jump);
                        current_pos = transform.position;
                        grounded = false;
                        alreadyDJ = true;
                    }

                    

                    // Cuando el salto llega a su limite, el Jugador se regresa al piso
                    if (transform.position.y >= current_pos.y + 1f)
                    {
                        r2d.velocity = (Vector2.right * r2d.velocity.x) + (Vector2.up * -2f);
                    }

                for (int i = 0; i < 2; i++)
                {
                    r2d.AddForce(Vector2.right * 2 * speed); ;
                }

                
            }
                
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

        if (col.gameObject.name == "Pisito")
        {
            libreria.layer = 2;
        }
    }

    /* IEnumerator SaltoLibreria(int direccion, )
     {


     }*/
     }