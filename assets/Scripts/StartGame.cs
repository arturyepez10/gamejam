using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Text[] Letras;
    private string cadena;
    private float velocity;

    // Start is called before the first frame update
    void Start()
    {
        velocity=0.1f;
        StartCoroutine(ShowText(Letras));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
           // SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene) + 1);
        }
    }

    IEnumerator ShowText(Text[] texto)
    {
        //Por cada letra que tengamos en el arreglo show, vamos agregando una por una al cuadro de texto
        foreach (Text i in texto)
        {
            i.enabled=true;
            yield return new WaitForSeconds(velocity);

        }

        StartCoroutine(WavyText(texto));
    }

    IEnumerator WavyText(Text[] texto)
    {
        velocity = 0.07f;

        while (true)
        {

            //Por cada letra que tengamos en el arreglo texto, aumentara y reducira su tamano
            foreach (Text i in texto)
            {
                i.fontSize = i.fontSize + 10;
                yield return new WaitForSeconds(velocity);
                i.fontSize = i.fontSize - 20;
            }

            foreach (Text i in texto)
            {
                i.fontSize = i.fontSize +30;
                yield return new WaitForSeconds(velocity);
                i.fontSize = i.fontSize - 20;

            }
        }
    }
}
