using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrulhar : MonoBehaviour
{
    [SerializeField] public OponenteCore oponente;
    public float reachDistance = 1f; // Dist�ncia para considerar um waypoint alcan�ado
    public int currentWaypointIndex = 0;
    [SerializeField] public Transform[] waypoints;
    [SerializeField] private Parar parar;

    public void PatrulharArea()
    {
        if (waypoints.Length == 0) return;

        // Obt�m o waypoint de destino atual
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        oponente.agent.SetDestination(targetWaypoint.position);
        oponente.agent.speed = oponente.Velocidade;
        // Verifica se o inimigo alcan�ou o ponto usando `remainingDistance`
        if (!oponente.agent.pathPending && oponente.agent.remainingDistance < reachDistance)
        {
            parar.PararMovimento(); // Chamando a fun��o para parar o movimento se necess�rio
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length; // Avan�a para o pr�ximo waypoint
        }
    }
}
