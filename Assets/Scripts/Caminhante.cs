
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caminhante : MonoBehaviour
{
    public float speed = 2f; // Velocidade base do inimigo
    public float reachDistance = 1f; // Distância para considerar um waypoint alcançado
    private int currentWaypointIndex = 0;
    private float distanciaMinima = 1.2f;
    [SerializeField] Transform[] waypoints; // Array de pontos de caminho
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float raioVisao = 5f;
    [SerializeField] private LayerMask layermask;

    public Transform alvo; // O alvo atual (jogador)
    private float tempoFoco = 3f; // Tempo em segundos para manter o foco no jogador
    private float tempoRestanteFoco; // Tempo restante para o foco

    [SerializeField] LifeControl vida;
    public int vidaAnterior;

    private void Start()
    {
        vidaAnterior = vida.vidaAtual;
    }

    void Update()
    {
        if (vida.vidaAtual != vidaAnterior)
        {
        vidaAnterior = vida.vidaAtual;
        ReceberDano(GameObject.FindGameObjectWithTag("Player").transform);
        }// Atualiza o tempo de foco
        if (tempoRestanteFoco > 0)
        {
            tempoRestanteFoco -= Time.deltaTime;
        }
        else
        {
            // Se o tempo expirar, procure o jogador novamente
            alvo = null;
            ProcurarJogador();
        }

        if (alvo == null)
        {
            Patrulhar();
        }
        else
        {
            Perseguir();
        }
    }

    public void ProcurarJogador()
    {
        Collider2D colisor = Physics2D.OverlapCircle(this.transform.position, this.raioVisao, this.layermask);
        if (colisor != null)
        {
            Vector2 posicaoAtual = this.transform.position;
            Vector2 posicaoAlvo = colisor.transform.position;
            Vector2 direcao = posicaoAlvo - posicaoAtual;
            direcao = direcao.normalized;
            RaycastHit2D hit = Physics2D.Raycast(posicaoAtual, direcao, this.raioVisao);
            if (hit.transform != null && hit.transform.CompareTag("Player"))
            {
                this.alvo = hit.transform;
                tempoRestanteFoco = tempoFoco; // Reinicia o tempo de foco
            }
        }
    }

    public void ReceberDano(Transform jogador)
    {
        // Método chamado quando o caminhante recebe dano
        this.alvo = jogador; // Define o alvo como o jogador instantaneamente
        tempoRestanteFoco = tempoFoco; // Reinicia o tempo de foco ao receber dano

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, this.raioVisao);
        if (this.alvo != null)
        {
            Gizmos.DrawLine(this.transform.position, this.alvo.position);
        }
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
            // Aplica bônus de velocidade se estiver ativo
            float velocidadeReal = speed;
            this.rigidbody.velocity = (velocidadeReal * direcao);
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
        this.rigidbody.velocity = direction.normalized * this.speed;

        // Verifica se o inimigo alcançou o ponto
        if (direction.magnitude < reachDistance)
        {
            PararMovimento();
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length; // Volta ao primeiro quando chegar ao final
        }
    }

    void PararMovimento()
    {
        this.rigidbody.velocity = Vector2.zero;
    }
}
