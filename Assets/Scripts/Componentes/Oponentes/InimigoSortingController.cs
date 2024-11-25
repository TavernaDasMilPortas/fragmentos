using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class InimigoSortingController : MonoBehaviour
{
    [Header("Configurações")]
    [Tooltip("Selecione a Sorting Layer para quando o inimigo estiver acima do jogador.")]
    [SerializeField] private string sortingLayerAcima;

    [Tooltip("Selecione a Sorting Layer para quando o inimigo estiver abaixo do jogador.")]
    [SerializeField] private string sortingLayerAbaixo;

    [Tooltip("Referência ao jogador.")]
    [SerializeField] private Transform jogador;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
       jogador = GameObject.Find("Momo").transform;

    }

    void Update()
    {
        AtualizarSortingLayer();
    }

    private void AtualizarSortingLayer()
    {
        if (jogador == null) return; // Não faça nada se o jogador não estiver definido

        // Compara a posição Y do inimigo com a posição Y do jogador
        if (transform.position.y > jogador.position.y)
        {
            spriteRenderer.sortingLayerName = sortingLayerAcima;
        }
        else
        {
            spriteRenderer.sortingLayerName = sortingLayerAbaixo;
        }
    }
}
