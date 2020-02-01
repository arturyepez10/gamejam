using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlatform : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.5f;
    [SerializeField]
    private Collider2D c2d1;
    [SerializeField]
    private Collider2D c2d2;
    private Vector3 pos1;
    private Vector3 pos2;


    // Start is called before the first frame update
    void Start()
    {
        pos1.x = c2d1.bounds.center.x + c2d1.bounds.extents.x;
        pos2.x = c2d2.bounds.center.x - c2d2.bounds.extents.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time / speed, 1f));
    }
}
