using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // velocidad del Jugador
    [SerializeField]
    private float speed = 5f;
    // Direccion de movimiento
    private float moveHorizontal;
    public GameObject hand;
    private Grab grab;
    private bool grabbed;

    void Start()
    {
        // Obtenemos el componente 'Grab' de el GameObject hand
        grab = hand.GetComponent<Grab>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        // Actualizamos la posicion
        transform.position += new Vector3(speed * Time.deltaTime * moveHorizontal, 0f, 0f);
        grabbed = grab.grabbed;
        // Si se mueve en direccion contraria y no tiene nada agarrado, rota 180 grados
        if((moveHorizontal < 0) && !grabbed)
        {
            transform.rotation = Quaternion.Euler(Vector3.up * 180);
        }
        if((moveHorizontal > 0) && !grabbed)
        {
            transform.rotation = Quaternion.Euler(Vector3.up * 0);
        }
    }
}
