using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Perseguir : MonoBehaviour
{
    [SerializeField] public OponenteCore oponente;
    [SerializeField] private Parar parar;

    public void PerseguirAlvo()
    {
        if (oponente.Alvo == null) return; // Verifica se há um alvo definido

        // Define o destino do agente como a posição do alvo
        oponente.agent.SetDestination(oponente.Alvo.position);

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
