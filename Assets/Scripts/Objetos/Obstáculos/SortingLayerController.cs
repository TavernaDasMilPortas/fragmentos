using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SortingLayerController : MonoBehaviour
{
    [Header("Configura��es")]
    [Tooltip("Selecione a Sorting Layer para quando o objeto estiver acima do alvo.")]
    [SerializeField] private string sortingLayerAcima;

    [Tooltip("Selecione a Sorting Layer para quando o objeto estiver abaixo do alvo.")]
    [SerializeField] private string sortingLayerAbaixo;

    [Tooltip("Dist�ncia m�xima para considerar o alvo mais pr�ximo.")]
    [SerializeField] private float distanciaMaxima = 2f;

    [SerializeField] private SpriteRenderer spriteRenderer;

    [Tooltip("Refer�ncia ao transform do jogador.")]
    [SerializeField] private Transform jogador;

    public Transform alvoMaisProximo;

    void Update()
    {
        AtualizarSortingLayer();
    }

    private void AtualizarSortingLayer()
    {
        alvoMaisProximo = EncontrarAlvoMaisProximo();

        if (alvoMaisProximo != null)
        {
            // Compara a posi��o Y do objeto com o alvo mais pr�ximo
            if (transform.position.y > alvoMaisProximo.position.y)
            {
                spriteRenderer.sortingLayerName = sortingLayerAcima;
            }
            else
            {
                spriteRenderer.sortingLayerName = sortingLayerAbaixo;
            }
        }
    }

    private Transform EncontrarAlvoMaisProximo()
    {
        Transform alvoMaisProximo = null;
        float menorDistancia = float.MaxValue;

        // Verifica a dist�ncia at� o jogador
        if (jogador != null)
        {
            float distanciaJogador = Vector2.Distance(transform.position, jogador.position);
            if (distanciaJogador < menorDistancia && distanciaJogador <= distanciaMaxima)
            {
                alvoMaisProximo = jogador;
                menorDistancia = distanciaJogador;
            }
        }

        // Verifica a dist�ncia at� os oponentes
        Collider2D[] oponentes = Physics2D.OverlapCircleAll(transform.position, distanciaMaxima);
        foreach (var oponente in oponentes)
        {
            // Certifica-se de que o oponente est� no Layer esperado
            if (oponente.gameObject.CompareTag("Oponente"))
            {
                float distanciaOponente = Vector2.Distance(transform.position, oponente.transform.position);
                if (distanciaOponente < menorDistancia)
                {
                    alvoMaisProximo = oponente.transform;
                    menorDistancia = distanciaOponente;
                }
            }
        }

        return alvoMaisProximo;
    }

    private void OnDrawGizmosSelected()
    {
        // Mostra o alcance de detec��o no editor
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanciaMaxima);
    }
}