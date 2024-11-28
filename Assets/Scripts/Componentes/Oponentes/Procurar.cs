using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procurar : MonoBehaviour
{
    [SerializeField] public OponenteCore oponente;
    [SerializeField] private Agro agro;

    public void ProcurarAlvo()
    {
        // Primeiramente, fazemos um OverlapCircle para identificar os objetos dentro do raio de visão
        Collider2D[] colisores = Physics2D.OverlapCircleAll(transform.position, oponente.RaioVisao, oponente.Layermask);

        foreach (var colisor in colisores)
        {
            Debug.Log($"OverlapCircle encontrou: {colisor.name}");

            // Calcular a direção para o colisor
            Vector2 posicaoAtual = this.transform.position;
            Vector2 posicaoAlvo = colisor.transform.position;
            Vector2 direcao = posicaoAlvo - posicaoAtual;
            direcao = direcao.normalized;

            // Fazer um Raycast para verificar se o caminho até o alvo está livre de obstáculos
            RaycastHit2D hit = Physics2D.Raycast(posicaoAtual, direcao, oponente.RaioVisao, oponente.Layermask);

            if (hit.collider != null)
            {
                Debug.Log($"Raycast encontrou: {hit.transform.name}");

                // Se o Raycast encontrar um objeto com a tag "Player", o agro é ativado
                if (hit.transform.CompareTag("Player"))
                {
                    Debug.Log($"Alvo encontrado: {hit.transform.name}");
                    // Ativa o agro ao encontrar o jogador
                    agro.AtivarAgro();
                }

            }
        }
    }

    private bool IgnorarObjeto(Transform obj)
    {
        // Ignora o próprio objeto ou objetos sem tag relevante
        return obj == transform || !obj.CompareTag("Player");
    }
}