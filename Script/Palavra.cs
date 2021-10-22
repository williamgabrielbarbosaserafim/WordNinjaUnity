using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palavra : MonoBehaviour
{
    float girox;
    float giroz;
    TextMesh tm;
    public EntradaTexto entradaTexto;
    GameObject gameover;
    float randomizacao;
    public int contText;
    bool subir;
    float velocidade;
    float distancia;
    public int numDaPalavra;
    string palavraRecebida;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Lamina")
        {
            Debug.Log("Destruiu");
            Destroy(gameObject);
            for (int i = 0; i <= entradaTexto.palavrasErradas.Length-1; i++) {
                if (tm.text == entradaTexto.palavrasErradas[i])
                {
                    Debug.Log("Game Over");
                    Time.timeScale = 0;
                    gameover = GameObject.Find("GameOver");
                    gameover.transform.position = gameover.transform.position + new Vector3(0, 0, -1);
                    
                }
            }
            
        }
        if (col.gameObject.CompareTag("Trampolim") && subir == false)
        {
            subir = true;
            Debug.Log("Trampulou");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        subir = true;
        palavraRecebida = entradaTexto.palavrasCertas[1];
        numDaPalavra = Mathf.RoundToInt(Random.Range(0, 9));
        tm = GetComponent<TextMesh>();
        tm.anchor = TextAnchor.MiddleCenter;
        randomizacao = Random.Range(0.01f, -0.01f);
        if (transform.position.x > 0)
        {
            randomizacao += transform.position.x * -0.01f / 5f;
        }
        else if (transform.position.x < 0)
        {
            randomizacao += transform.position.x * -0.01f / 2f;
        }
        girox = Random.Range(0.05f, 0.1f);
        giroz = Random.Range(0.1f, 0.5f);

        if (numDaPalavra % 2 == 0)
        {
            tm.text = entradaTexto.palavrasCertas[numDaPalavra];
            contText = tm.text.Length;
        }
        else if(numDaPalavra % 2 != 0)
        {
            tm.text = entradaTexto.palavrasErradas[numDaPalavra];
            contText = tm.text.Length;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > -9.8)
        {
            tag = "Instanciado";
        }
        transform.Rotate(girox, 0, giroz);
        parabola();
        
        transform.position += new Vector3(randomizacao, 0, 0);
        destruirObj();

    }

    void destruirObj()
    {
        if (transform.position.y < -18)
        {
            Destroy(gameObject);
        }
    }

    void parabola()
    {
        distancia = 7.7f - transform.position.y;
        if (transform.position.y >= 7.7f)
        {
            subir = false;
        }
        if(subir)
        {
            velocidade = 2 * distancia + 1;
            transform.position = transform.position + new Vector3(0, velocidade, 0) * Time.deltaTime;
        }
        else if(subir == false)
        {
            velocidade = -2 * distancia - 2;
            transform.position = transform.position + new Vector3(0, velocidade, 0) * Time.deltaTime;
        }
    }
}
