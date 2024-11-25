using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcurarPonto : MonoBehaviour
{
    [SerializeField] private Transform[] pontosArena; // Posições dos cantos da arena
    [SerializeField] private GameObject areaDanoPrefab; // Prefab da área de dano gerada pelo teleporte
    [SerializeField] private OponenteCore core; // Referência ao OponenteCore (base do oponente)
    private Transform pontoMaisDistante;
    private List<Vector3> pontosDeTeleporte = new List<Vector3>(); // Lista para armazenar pontos de teleporte

    public bool Teleportando { get; private set; } = false; // Indica se o teleporte está em andamento

    public void IniciarTeleporte()
    {
        if (Teleportando) return; // Previne iniciar o teleporte se já estiver em andamento

        // Escolhe o ponto mais distante dos 4 pontos predeterminados
        pontoMaisDistante = EscolherPontoMaisDistante();
        Debug.Log($"Ponto mais distante escolhido: {pontoMaisDistante.position}");

        // Inicia o teleporte em 3 partes até esse ponto
        StartCoroutine(TeleportarEmTresEtapas(pontoMaisDistante));
    }

    private Transform EscolherPontoMaisDistante()
    {
        Transform pontoMaisDistante = pontosArena[0];
        float maiorDistancia = Vector3.Distance(transform.position, pontoMaisDistante.position);

        foreach (var ponto in pontosArena)
        {
            float distanciaAtual = Vector3.Distance(transform.position, ponto.position);
            if (distanciaAtual > maiorDistancia)
            {
                maiorDistancia = distanciaAtual;
                pontoMaisDistante = ponto;
            }
        }

        return pontoMaisDistante;
    }

    private IEnumerator TeleportarEmTresEtapas(Transform pontoDestino)
    {
        Teleportando = true; // Marca que o teleporte está em andamento

        Vector3 direcao = (pontoDestino.position - transform.position).normalized;
        float distanciaTotal = Vector3.Distance(transform.position, pontoDestino.position);
        float distanciaPorEtapa = distanciaTotal / 3;

        // Realiza os 3 teleportes
        for (int i = 1; i <= 3; i++)
        {
            Vector3 proximoDestino = transform.position + direcao * distanciaPorEtapa;
            transform.position = proximoDestino;

            GerarAreaDano();

            yield return new WaitForSeconds(1.5f); // Intervalo entre os teleportes
        }

        Teleportando = false; // Marca o final do teleporte
    }

    private void GerarAreaDano()
    {
        if (areaDanoPrefab != null)
        {
            
            GameObject area = Instantiate(areaDanoPrefab, transform.position, Quaternion.identity);
            AreaDano areaDano = area.GetComponent<AreaDano>();
            areaDano.Inicializar(this.transform.root.gameObject);
        }
        else
        {
            Debug.LogWarning("Prefab da área de dano não está definido.");
        }
    }
}