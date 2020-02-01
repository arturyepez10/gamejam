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

    /*// Start is called before the first frame update
    void Start()
    {
      
        
    }
    */

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
        }
    }
}