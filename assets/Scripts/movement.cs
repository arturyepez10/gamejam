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
    private bool can_move = true;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        // Obtenemos el componente 'Grab' de el GameObject hand
        grab = hand.GetComponent<Grab>();
    }

    // Update is called once per frame
    void Update()
    {

        moveHorizontal = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(moveHorizontal)!=0)
        {
            animator.SetBool("camina", true);
        }
        else
        {
            animator.SetBool("camina",false);
        }
       
        if(can_move || moveHorizontal >= 0)
        {
            transform.position += new Vector3(speed * Time.deltaTime * moveHorizontal, 0f, 0f);
        }
        // Actualizamos la posicion
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

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Unseen Wall")
        {
            moveHorizontal = 0;
            can_move = false;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag == "Unseen Wall")
        {
            can_move = true;
        }
    }
}
