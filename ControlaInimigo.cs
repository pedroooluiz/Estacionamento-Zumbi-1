using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{

    public GameObject jogador;
    public float speed;
    private Rigidbody rigInimigo;
    private Animator animInimigo;

    // Start is called before the first frame update
    void Start()
    {
        jogador = GameObject.FindWithTag("Jogador");
        int geraTipoZumbi = Random.Range(1, 28);
        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);
        rigInimigo = GetComponent<Rigidbody>();
        animInimigo = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 direcao = jogador.transform.position - transform.position;
        float distancia = Vector3.Distance(transform.position, jogador.transform.position);
        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        rigInimigo.MoveRotation(novaRotacao);

        if (distancia > 2.7)
        {
            rigInimigo.MovePosition(rigInimigo.position + direcao.normalized * speed * Time.deltaTime);
            animInimigo.SetBool("Atacando", false);

        }
        else
        {
            animInimigo.SetBool("Atacando", true);
        }
    }

    void AtacaJogador()
    {
        Time.timeScale = 0;
        jogador.GetComponent<Jogador>().textoGameOver.SetActive(true);
        jogador.GetComponent<Jogador>().Vivo = false;
    }
}
