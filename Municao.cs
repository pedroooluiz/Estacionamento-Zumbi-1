using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Municao : MonoBehaviour
{
    [SerializeField]
    float speed;
    private Rigidbody rigMunicao;

    // Start is called before the first frame update
    void Start()
    {
        rigMunicao = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigMunicao.MovePosition(rigMunicao.position + transform.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider objetoDeColisao)
    {
        if(objetoDeColisao.tag == "Inimigo")
        {
            Destroy(objetoDeColisao.gameObject);
        }

        Destroy(gameObject);
    }
}
