using System.Collections.Generic;
using UnityEngine;

public class Interagir : MonoBehaviour
{
    [Header("Configura��es de Detec��o")]
    [SerializeField] private float raioInteracao = 5f; // Raio interno para detectar objetos interag�veis
    [SerializeField] private float raioExterno = 10f; // Raio externo para instanciar prefabs
    [SerializeField] private LayerMask layerInteragivel; // Camada dos objetos interag�veis
    [SerializeField] private GameObject prefabIndicador; // Prefab do indicador para os objetos interag�veis
    [SerializeField] TextoInteragir textointeragir;
    public Iinteragivel objetoMaisProximo;
    private GameObject prefabDoMaisProximo;
    private Animator animatorDoMaisProximo;
    private Dictionary<Iinteragivel, GameObject> prefabsInstanciados = new Dictionary<Iinteragivel, GameObject>();

    private void Update()
    {
        DetectarEAtualizarProximidade();
        AtualizarEstadoAnimator();
    }

    private void DetectarEAtualizarProximidade()
    {
        Collider2D[] objetosInteragiveis = Physics2D.OverlapCircleAll(transform.position, raioExterno, layerInteragivel);
        HashSet<Iinteragivel> objetosDetectados = new HashSet<Iinteragivel>();
        float menorDistancia = Mathf.Infinity;
        Iinteragivel candidatoMaisProximo = null;

        foreach (var obj in objetosInteragiveis)
        {
            var interagivel = obj.GetComponent<Iinteragivel>();
            if (interagivel != null)
            {
                objetosDetectados.Add(interagivel);

                // Instancia o prefab para objetos dentro do raio externo, se ainda n�o tiver sido instanciado
                if (!prefabsInstanciados.ContainsKey(interagivel))
                {
                    Transform pontoMaisProximo = EncontrarPontoMaisProximo(interagivel);
                    if (pontoMaisProximo != null)
                    {
                        GameObject prefab = Instantiate(prefabIndicador, pontoMaisProximo.position, Quaternion.identity);

                        prefab.transform.SetParent(pontoMaisProximo.root);

                        // Configura o script BotaoInteracao no prefab
                        var botaoInteracao = prefab.GetComponent<BotaoInteracao>();
                        if (botaoInteracao != null)
                        {
                            botaoInteracao.parentSpriteRenderer = pontoMaisProximo.GetComponent<SpriteRenderer>();
                        }

                        prefabsInstanciados[interagivel] = prefab;
                    }
                }

                // Determina o objeto mais pr�ximo dentro do raio interno
                float distancia = Vector2.Distance(transform.position, obj.transform.position);
                if (distancia < menorDistancia)
                {
                    menorDistancia = distancia;
                    candidatoMaisProximo = interagivel;
                }
            }
        }

        // Remove objetos que sa�ram do raio externo
        var objetosForaDoRaio = new List<Iinteragivel>();
        foreach (var interagivel in prefabsInstanciados.Keys)
        {
            if (!objetosDetectados.Contains(interagivel))
            {
                objetosForaDoRaio.Add(interagivel);
            }
        }
        foreach (var interagivel in objetosForaDoRaio)
        {
            Destroy(prefabsInstanciados[interagivel]);
            prefabsInstanciados.Remove(interagivel);
        }

        // Atualiza o objeto mais pr�ximo
        if (candidatoMaisProximo != objetoMaisProximo)
        {
            // Chama AoSairDoRaio no objeto anterior
            if (objetoMaisProximo != null)
            {
                objetoMaisProximo.EstaMaisProximo = false;
            }

            // Atualiza para o novo objeto mais pr�ximo
            objetoMaisProximo = candidatoMaisProximo;

            // Chama AoEntrarNoRaio no novo objeto
            if (objetoMaisProximo != null)
            {
                objetoMaisProximo.EstaMaisProximo = true;
            }
        }
    }
    private void AtualizarEstadoAnimator()
    {
        if (objetoMaisProximo != null)
        {
            // Garante que o prefab do objeto mais pr�ximo seja atualizado
            if (prefabsInstanciados.TryGetValue(objetoMaisProximo, out var prefab))
            {
                if (prefabDoMaisProximo != prefab)
                {
                    prefabDoMaisProximo = prefab;
                    animatorDoMaisProximo = prefab.GetComponent<Animator>();
                }

                // Verifica se o objeto est� no raio menor
                float distancia = Vector2.Distance(transform.position, ((MonoBehaviour)objetoMaisProximo).transform.position);
                bool estaNoRaioMenor = distancia <= raioInteracao;

                if (animatorDoMaisProximo != null)
                {
                    animatorDoMaisProximo.SetBool("MaisProximo", estaNoRaioMenor);
                }
            }
        }

        // Reseta o estado do prefab anterior se nenhum objeto for o mais pr�ximo
        foreach (var kvp in prefabsInstanciados)
        {
            if (kvp.Key != objetoMaisProximo)
            {
                var animator = kvp.Value.GetComponent<Animator>();
                if (animator != null)
                {
                    animator.SetBool("MaisProximo", false);
                }
            }
        }
    }

    private Transform EncontrarPontoMaisProximo(Iinteragivel interagivel)
    {
        Transform pontoMaisProximo = null;
        float menorDistancia = Mathf.Infinity;

        foreach (var ponto in interagivel.PontosPrebab)
        {
            float distancia = Vector2.Distance(transform.position, ponto.position);
            if (distancia < menorDistancia)
            {
                menorDistancia = distancia;
                pontoMaisProximo = ponto;
            }
        }

        return pontoMaisProximo;
    }

    /// <summary>
    /// Dispara a intera��o com o objeto mais pr�ximo.
    /// </summary>
    public void DispararInteracao(Iinteragivel objetoProximo)
    {
        if (objetoMaisProximo != null )
        {
            objetoMaisProximo.Interagir();
        }
        else
        {
            Debug.LogWarning("Nenhum objeto interag�vel pr�ximo para interagir.");
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Visualiza os raios de intera��o no editor
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, raioInteracao);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, raioExterno);
    }
}
