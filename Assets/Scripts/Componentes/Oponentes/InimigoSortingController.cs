using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class InimigoSortingController : MonoBehaviour
{
    [Header("Configura��es")]
    [Tooltip("Selecione a Sorting Layer para quando o inimigo estiver acima do jogador.")]
    [SerializeField] private string sortingLayerAcima;

    [Tooltip("Selecione a Sorting Layer para quando o inimigo estiver abaixo do jogador.")]
    [SerializeField] private string sortingLayerAbaixo;

    [Tooltip("Refer�ncia ao jogador.")]
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
        if (jogador == null) return; // N�o fa�a nada se o jogador n�o estiver definido

        // Compara a posi��o Y do inimigo com a posi��o Y do jogador
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
