using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sakura : MonoBehaviour
{
    Rigidbody2D rb2;
    public GameObject trampolimPrefab;
    GameObject trampolimAtual;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Lamina")
        {
            Debug.Log("Destruiu");
            Destroy(gameObject);
            trampolimAtual = Instantiate(trampolimPrefab, new Vector3(-11.3f, 9.8f, 0), Quaternion.identity);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        sakuraFall();
        destruirObjeto();

    }
    public void sakuraFall()
    {
        if(transform.position.y %2 == 0)
        {
            rb2.gravityScale = 0;
            if(rb2.gravityScale <= 1)
            {
                rb2.gravityScale = rb2.gravityScale + 0.05f;
            }
        }
    }
    void destruirObjeto()
    {
        if(transform.position.y <= -18)
        {
            Destroy(gameObject);
        }
    }
}
