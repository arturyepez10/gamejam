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
    public float posy1;
    public float posy2;
    [SerializeField]
    private GameObject switch1;
    [SerializeField]
    private GameObject switch2;
    private bool both_pressed = false;



    // Start is called before the first frame update
    void Start()
    {
        pos1.x = c2d1.bounds.center.x + c2d1.bounds.extents.x;
        pos1.y = posy1; 
        pos2.x = c2d2.bounds.center.x - c2d2.bounds.extents.x;
        pos2.y = posy2;
    }

    // Update is called once per frame
    void Update()
    {
        if(both_pressed)
        {
            switch1.GetComponent<Switch_function>().pressed = true;
            switch2.GetComponent<Switch_function>().pressed = true;
        }
        if(switch1.GetComponent<Switch_function>().pressed && switch2.GetComponent<Switch_function>().pressed)
        {
            both_pressed = true;
            transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time / speed, 1f));
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        col.transform.parent = transform;
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        col.transform.parent = null;
    }
}
