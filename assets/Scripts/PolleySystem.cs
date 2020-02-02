using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolleySystem : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D r2d;
    [SerializeField]
    private Collider2D c2d;
    private float limit;
    private float speed = 1f;
    private Vector3 pos;
    private bool movementStart = false;
    // Start is called before the first frame update
    void Start()
    {
        limit = c2d.bounds.center.y + c2d.bounds.extents.y;
        pos = transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (r2d.velocity.y != 0)
        {
            movementStart = true;
        }

        if (movementStart && transform.position.y >= limit)
        {
            transform.position = new Vector3(transform.position.x, limit, 0f);
        }
        if (movementStart && transform.position.y != limit)
        {
            
            transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
        }
    }
}

