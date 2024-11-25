using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MovimentacaoLateral : MonoBehaviour
{
    public float distanciaMaxima = 5f; // Distância máxima para o movimento
    public float distanciaMinima = 4f; // Distância mínima para o movimento
    public NavMeshAgent agente;

    private void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        if (agente == null)
        {
            Debug.LogError("NavMeshAgent não encontrado no SubBoss.");
        }
        else
        {
            Debug.Log("Movimentação Lateral Iniciada");
        }
    }

    public IEnumerator MovimentarLateralmente()
    {
        Debug.Log("Iniciando movimento lateral...");
        Vector3 destino = Vector3.zero;
        bool destinoValido = false;

        // Continua tentando até encontrar um destino válido dentro do range
        while (!destinoValido)
        {
            // Gera uma direção aleatória
            Vector3 direcaoAleatoria = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
            destino = transform.position + direcaoAleatoria * Random.Range(distanciaMinima, distanciaMaxima);

            // Valida a distância gerada
            if (Vector3.Distance(transform.position, destino) >= distanciaMinima && Vector3.Distance(transform.position, destino) <= distanciaMaxima)
            {
                // Valida o destino no NavMesh
                NavMeshHit hit;
                if (NavMesh.SamplePosition(destino, out hit, distanciaMaxima, NavMesh.AllAreas))
                {
                    destino = hit.position;
                    destinoValido = true; // Marca o destino como válido
                }
                else
                {
                    Debug.LogWarning($"Destino inválido: {destino}. Tentando novamente...");
                }
            }
            else
            {
                Debug.LogWarning($"Destino gerado fora do intervalo válido: {destino}. Tentando novamente...");
            }
        }

        Debug.Log($"Movimento sorteado. Direção: {destino - transform.position}. Destino: {destino}");

        // Configura o destino no agente
        agente.SetDestination(destino);

        // Aguarda até o destino ser alcançado
        while (agente.pathPending || agente.remainingDistance > 0.1f)
        {
            yield return null; // Aguarda o próximo frame
        }

        Debug.Log("Destino alcançado. Movimento lateral concluído.");
    }
}