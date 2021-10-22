using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pergaminho : MonoBehaviour
{
    GameObject papelPergaminho;
    Camera cam;
    bool aberto = false;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        papelPergaminho = GameObject.Find("PapelPergaminho");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(1) && cam.ScreenToWorldPoint(Input.mousePosition).y < -13)
        {
            abrirPergaminho();
        }

    }

    void abrirPergaminho()
    {
        if (aberto == false)
        {
            aberto = true;
            if (papelPergaminho.transform.position.y < -13f)
            {
                papelPergaminho.transform.position = papelPergaminho.transform.position + new Vector3(0, 0.1f, 0);
            }
        }
        else if (aberto == true)
        {
            aberto = false;
            if (papelPergaminho.transform.position.y >= -13)
            {
                papelPergaminho.transform.position = papelPergaminho.transform.position + new Vector3(0, -0.1f, 0);
            }
        }

    }
}
