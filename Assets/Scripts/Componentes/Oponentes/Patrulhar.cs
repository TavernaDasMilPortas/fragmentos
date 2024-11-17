using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrulhar : MonoBehaviour
{
    [SerializeField] public OponenteCore oponente;
    public float reachDistance = 1f; // Distância para considerar um waypoint alcançado
    public int currentWaypointIndex = 0;
    [SerializeField] public Transform[] waypoints;
    [SerializeField] private Parar parar;

    public void PatrulharArea()
    {
        if (waypoints.Length == 0) return;

        // Obtém o waypoint de destino atual
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        oponente.agent.SetDestination(targetWaypoint.position);
        oponente.agent.speed = oponente.Velocidade;
        // Verifica se o inimigo alcançou o ponto usando `remainingDistance`
        if (!oponente.agent.pathPending && oponente.agent.remainingDistance < reachDistance)
        {
            parar.PararMovimento(); // Chamando a função para parar o movimento se necessário
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length; // Avança para o próximo waypoint
        }
    }
}
