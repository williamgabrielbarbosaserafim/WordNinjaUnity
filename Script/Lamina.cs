using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamina : MonoBehaviour
{
    public GameObject rastroPrefab;
    GameObject rastroAtual;

    Rigidbody2D rb2;
    Camera cam;
    CircleCollider2D bc2;

    bool cortando = false;
    public int pontos = 0;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Instanciado")
        {
            pontos++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       
        bc2 = GetComponent<CircleCollider2D>();
        rb2 = GetComponent<Rigidbody2D>();
        cam = Camera.main;

        bc2.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            comecarCorte();
            rastroAtual = Instantiate(rastroPrefab, transform);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            pararCorte();
        }
        if (cortando)
        {
            updateCorte();

        }
        else
        {
            updateCorte();
        }
    }
    void comecarCorte()
    {
        cortando = true;
        bc2.enabled = true; 
    }
    void pararCorte()
    {
        bc2.enabled = false;
        cortando = false;
        Destroy(rastroAtual, 0.1f);
    }

    void updateCorte()
    {
        rb2.transform.position = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y, 0) ;
    }
}
