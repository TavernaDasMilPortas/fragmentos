using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caminhante : MonoBehaviour
{
    
    public float speed = 2f; // Velocidade do inimigo
    public float reachDistance = 0.2f; // Distância para considerar um waypoint alcançado
    private int currentWaypointIndex = 0;
    private float distanciaMinima = 1.2f;
    [SerializeField] Transform[] waypoints; // Array de pontos de caminho
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float raioVisao = 2f;
    private Transform alvo = null;

    void Update()
    {
        ProcurarJogador();
        if (this.alvo !=null)
        {
            Perseguir();
        }
        if (this.alvo ==null) { 
            Patrulhar();
        }
        // Verifica se há pontos de caminho  
    }
    public void ProcurarJogador()
    {
        Collider2D colisor = Physics2D.OverlapCircle(this.transform.position, this.raioVisao);
        if (colisor != null)
        {
            this.alvo = colisor.transform;
        }
        else
        {
            this.alvo = null;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, this.raioVisao);
    }
    void Perseguir()
    {
        Vector2 posicaoAlvo = alvo.position;
        Vector2 posicaoAtual = this.transform.position;
        Vector2 direcao = posicaoAlvo - posicaoAtual;
        direcao = direcao.normalized;
        float distancia = Vector2.Distance(posicaoAtual, posicaoAlvo);
        if (distancia >= distanciaMinima)
        {
            this.rigidbody.velocity = (this.speed * direcao);
        }
        else
        {
            PararMovimento();
        }
        

    }
    void Patrulhar()
    {
        if (waypoints.Length == 0) return;

        // Move o inimigo em direção ao ponto atual
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 direction = targetWaypoint.position - transform.position;

        // Move o inimigo
        transform.position += direction.normalized * speed * Time.deltaTime;

        // Verifica se o inimigo alcançou o ponto
        if (direction.magnitude < reachDistance)
        {
            // Atualiza o índice do waypoint
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length; // Volta ao primeiro quando chegar ao final
        }

    }
    void PararMovimento()
    {
        this.rigidbody.velocity = Vector2.zero;
    }
}
