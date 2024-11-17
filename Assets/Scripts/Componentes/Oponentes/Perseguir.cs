using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perseguir : MonoBehaviour
{
    [SerializeField] public OponenteCore oponente;
    [SerializeField] private Parar parar;

    public Vector2 direcaoAtual { get; private set; } // Dire��o exposta para o HitboxSpawnPoint

    public void PerseguirAlvo()
    {
        if (oponente.Alvo == null) return; // Verifica se h� um alvo definido

        // Define o destino do agente como a posi��o do alvo
        oponente.agent.SetDestination(oponente.Alvo.position);

        // Calcula a dire��o do movimento
        Vector3 direcao = (oponente.Alvo.position - transform.position).normalized;
        direcaoAtual = new Vector2(direcao.x, direcao.y); // Armazena a dire��o atual

        // Verifica a dist�ncia do agente at� o alvo
        if (oponente.agent.remainingDistance >= oponente.DistanciaMinima)
        {
            // Define a velocidade do agente para que ele persiga o alvo
            oponente.agent.speed = oponente.Velocidade;
        }
        else
        {
            // Para o movimento quando est� pr�ximo o suficiente
            parar.PararMovimento();
        }
    }
}