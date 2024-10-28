using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perseguir : MonoBehaviour
{
    [SerializeField] public OponenteCore oponente;
    [SerializeField] private Parar parar;
    public void PerseguirAlvo()
    {
        Vector2 posicaoAlvo = oponente.Alvo.position;
        Vector2 posicaoAtual = this.transform.position;
        Vector2 direcao = posicaoAlvo - posicaoAtual;
        direcao = direcao.normalized;
        float distancia = Vector2.Distance(posicaoAtual, posicaoAlvo);
        if (distancia >= oponente.DistanciaMinima)
        {
            // Aplica bônus de velocidade se estiver ativo
            float velocidadeReal = oponente.Velocidade;
            oponente.Rigidbody.velocity = (velocidadeReal * direcao);
        }
        else
        {
            parar.PararMovimento();
        }
    }
}
