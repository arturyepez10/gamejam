using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{
    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= 0)
        {
            transform.position = new Vector3(0, -0.8699996f, -10);
        }
        if(transform.position.x <= player.transform.position.x){
            transform.position = (Vector3.right * (player.transform.position.x)) + (Vector3.up * (-0.8699996f)) + new Vector3(0, 0, -10);
        }
        else if(transform.position.x >= player.transform.position.x && transform.position.x > 0)
        {
            transform.position = (Vector3.right * (player.transform.position.x)) + (Vector3.up * (-0.8699996f)) + new Vector3(0, 0, -10);
        }
    }
}
