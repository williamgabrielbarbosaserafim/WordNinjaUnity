using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pontuacao : MonoBehaviour
{
    public GameObject minhaLamina;
    Lamina lamina;

    public int pontos = 0;
    public string teste;
    TextMesh tm;
    // Start is called before the first frame update
    void Start()
    {
        minhaLamina = GameObject.Find("Lamina");
        lamina = minhaLamina.GetComponent<Lamina>();
        tm = GetComponent<TextMesh>();
        tm.text = pontos.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        pontos = lamina.pontos;
        tm.text = pontos.ToString();
    }
}