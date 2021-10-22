using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lancador : MonoBehaviour
{
    public GameObject textoPrefab;
    GameObject textoAtual;
    public GameObject envolucroPrefab;
    GameObject envolucroAtual;

    float deucerto;
    float tempo;
    float aleatorio;
    float tempoGerado;
   
    // Start is called before the first frame update
    void Start()
    {
        //envolucroAtual = GameObject.Find("Envolucro");
        Vector3 vector3;
        vector3 = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((Mathf.Sin(Time.time))*10 , -17.5f, 0);
        aleatorio = Random.Range(2.2f, 2.5f);

        if (Time.time == 0 || (Time.time - tempoGerado) > aleatorio)
        {
            textoAtual = Instantiate(textoPrefab, transform.position, Quaternion.identity);
            envolucroAtual = Instantiate(envolucroPrefab, transform.position, Quaternion.identity);
            tempoGerado = Time.time;
        }
  
    }
    void lancarTxt(float x)
    {
        if(transform.position.x %1 == 0 || transform.position.x % -1 == 0)
        {
            deucerto += 1;
            textoAtual = Instantiate(textoPrefab, transform.position, Quaternion.identity);
            envolucroAtual = Instantiate(envolucroPrefab, transform.position, Quaternion.identity);
        }
    }
}
