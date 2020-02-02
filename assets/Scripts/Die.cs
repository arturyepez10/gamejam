using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Die : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "death_floo") {
            SceneManager.LoadScene("Hub");
        }
    }
}