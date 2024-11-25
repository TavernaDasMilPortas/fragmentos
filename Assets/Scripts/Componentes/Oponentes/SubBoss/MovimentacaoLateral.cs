using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MovimentacaoLateral : MonoBehaviour
{
    public float distanciaMaxima = 5f; // Dist�ncia m�xima para o movimento
    public float distanciaMinima = 4f; // Dist�ncia m�nima para o movimento
    public NavMeshAgent agente;

    private void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        if (agente == null)
        {
            Debug.LogError("NavMeshAgent n�o encontrado no SubBoss.");
        }
        else
        {
            Debug.Log("Movimenta��o Lateral Iniciada");
        }
    }

    public IEnumerator MovimentarLateralmente()
    {
        Debug.Log("Iniciando movimento lateral...");
        Vector3 destino = Vector3.zero;
        bool destinoValido = false;

        // Continua tentando at� encontrar um destino v�lido dentro do range
        while (!destinoValido)
        {
            // Gera uma dire��o aleat�ria
            Vector3 direcaoAleatoria = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
            destino = transform.position + direcaoAleatoria * Random.Range(distanciaMinima, distanciaMaxima);

            // Valida a dist�ncia gerada
            if (Vector3.Distance(transform.position, destino) >= distanciaMinima && Vector3.Distance(transform.position, destino) <= distanciaMaxima)
            {
                // Valida o destino no NavMesh
                NavMeshHit hit;
                if (NavMesh.SamplePosition(destino, out hit, distanciaMaxima, NavMesh.AllAreas))
                {
                    destino = hit.position;
                    destinoValido = true; // Marca o destino como v�lido
                }
                else
                {
                    Debug.LogWarning($"Destino inv�lido: {destino}. Tentando novamente...");
                }
            }
            else
            {
                Debug.LogWarning($"Destino gerado fora do intervalo v�lido: {destino}. Tentando novamente...");
            }
        }

        Debug.Log($"Movimento sorteado. Dire��o: {destino - transform.position}. Destino: {destino}");

        // Configura o destino no agente
        agente.SetDestination(destino);

        // Aguarda at� o destino ser alcan�ado
        while (agente.pathPending || agente.remainingDistance > 0.1f)
        {
            yield return null; // Aguarda o pr�ximo frame
        }

        Debug.Log("Destino alcan�ado. Movimento lateral conclu�do.");
    }
}