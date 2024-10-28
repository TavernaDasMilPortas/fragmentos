using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrulhar : MonoBehaviour
{
    [SerializeField] public OponenteCore oponente;
    public float reachDistance = 1f; // Dist�ncia para considerar um waypoint alcan�ado
    private int currentWaypointIndex = 0;
    [SerializeField] Transform[] waypoints;
    [SerializeField] private Parar parar;
    public void PatrulharArea()
    {
        if (waypoints.Length == 0) return;

        // Move o inimigo em dire��o ao ponto atual
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 direction = targetWaypoint.position - transform.position;

        // Move o inimigo
        oponente.Rigidbody.velocity = direction.normalized * oponente.Velocidade;

        // Verifica se o inimigo alcan�ou o ponto
        if (direction.magnitude < reachDistance)
        {
            parar.PararMovimento();
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length; // Volta ao primeiro quando chegar ao final
        }
    }
}
