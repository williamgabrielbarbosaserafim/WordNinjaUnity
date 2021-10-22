using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Envolucro : MonoBehaviour
{
    public GameObject palavra;
    Palavra sPalavra;

    Rigidbody2D rb2;
    Mesh mesh;

    int contadorLetras;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Lamina")
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       
        palavra = GameObject.FindGameObjectWithTag("Palavra");
       
        sPalavra = palavra.GetComponent<Palavra>();
        rb2 = GetComponent<Rigidbody2D>();
        mesh = GetComponent<Mesh>();
        contadorLetras = sPalavra.contText;
        transform.localScale = new Vector3(0.5f*contadorLetras, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        contadorLetras = sPalavra.contText;
        transform.position = sPalavra.transform.position;
        transform.rotation = sPalavra.transform.rotation;
        destruirObj();
    }
    void destruirObj()
    {
        if (palavra==null || transform.position.y < -18)
        {
            Destroy(gameObject);
        }
    }
}
