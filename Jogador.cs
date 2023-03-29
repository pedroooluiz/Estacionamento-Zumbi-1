using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogador : MonoBehaviour
{

    public float speed;
    private Vector3 direcao;
    public LayerMask mascaraChao;
    public GameObject textoGameOver;
    public bool Vivo = true;
    private Rigidbody rigJogador;
    private Animator animJogador;

    void Start()
    {
        Time.timeScale = 1.0f;
        rigJogador = GetComponent<Rigidbody>();
        animJogador = GetComponent<Animator>();
    }

    //Movimentação personagem
    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX,0,eixoZ);

        Animacao();

    }

    void FixedUpdate()
    {
        MovMira();
    }


    //Troca de animação personagem.
    void Animacao()
    {
        if (direcao != Vector3.zero)
        {
            animJogador.SetBool("Movendo", true);
        }
        else
        {
            animJogador.SetBool("Movendo", false);
        }

        if (Vivo == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("Fase1");
            }
        }
    }

    // Movimentação da mira.
    void MovMira()
    {
        rigJogador.MovePosition(transform.position + direcao * speed * Time.deltaTime);
        //addForce setVelocit 

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        RaycastHit impacto;

        if (Physics.Raycast(raio, out impacto, 100, mascaraChao))
        {
            Vector3 posicaoMiraJogador = impacto.point - transform.position;

            posicaoMiraJogador.y = transform.position.y;

            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);

            rigJogador.MoveRotation(novaRotacao);
        }
    }
}
