using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrulhar : MonoBehaviour
{
    [SerializeField] public OponenteCore oponente;
    public float reachDistance = 1f; // Distância para considerar um waypoint alcançado
    private int currentWaypointIndex = 0;
    [SerializeField] Transform[] waypoints;
    [SerializeField] private Parar parar;
    public void PatrulharArea()
    {
        if (waypoints.Length == 0) return;

        // Move o inimigo em direção ao ponto atual
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 direction = targetWaypoint.position - transform.position;

        // Move o inimigo
        oponente.Rigidbody.velocity = direction.normalized * oponente.Velocidade;

        // Verifica se o inimigo alcançou o ponto
        if (direction.magnitude < reachDistance)
        {
            parar.PararMovimento();
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length; // Volta ao primeiro quando chegar ao final
        }
    }
}
