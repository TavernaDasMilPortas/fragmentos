using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caminhante : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private Transform alvo;
    [SerializeField] private float velocidadeMov = 2;
    [SerializeField] private float distânciaMinima= 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Caminhar();
    }

    void SeguirRota()
    {


    }

    void Caminhar()
    {
        Vector2 posicaoAlvo = this.alvo.position;
        Vector2 posicaoAtual = this.transform.position;

        float distancia = Vector2.Distance(posicaoAlvo, posicaoAtual);
        if (distancia >= distânciaMinima)
        {
            Vector2 direcao = posicaoAlvo - posicaoAtual;
            direcao = direcao.normalized;
            this.rigidbody.velocity = (this.velocidadeMov * direcao);
            Debug.Log(this.rigidbody.velocity);
        }
        else
        {
            this.rigidbody.velocity = Vector2.zero;
        }

    }
}
