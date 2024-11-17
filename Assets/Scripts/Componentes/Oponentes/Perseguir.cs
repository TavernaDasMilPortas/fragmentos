using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perseguir : MonoBehaviour
{
    [SerializeField] public OponenteCore oponente;
    [SerializeField] private Parar parar;

    public Vector2 direcaoAtual { get; private set; } // Direção exposta para o HitboxSpawnPoint

    public void PerseguirAlvo()
    {
        if (oponente.Alvo == null) return; // Verifica se há um alvo definido

        // Define o destino do agente como a posição do alvo
        oponente.agent.SetDestination(oponente.Alvo.position);

        // Calcula a direção do movimento
        Vector3 direcao = (oponente.Alvo.position - transform.position).normalized;
        direcaoAtual = new Vector2(direcao.x, direcao.y); // Armazena a direção atual

        // Verifica a distância do agente até o alvo
        if (oponente.agent.remainingDistance >= oponente.DistanciaMinima)
        {
            // Define a velocidade do agente para que ele persiga o alvo
            oponente.agent.speed = oponente.Velocidade;
        }
        else
        {
            // Para o movimento quando está próximo o suficiente
            parar.PararMovimento();
        }
    }
}