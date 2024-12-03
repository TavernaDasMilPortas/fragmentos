using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemColetavel : MonoBehaviour, Iinteragivel
{
    [SerializeField] private string tipoInteracao = "Abrir Porta"; // Texto que descreve a intera��o

    [Header("Configura��es de Ponto de Prefab")]
    [SerializeField] private Transform[] pontosPrefab; // Pontos para o spawn do prefab de indica��o
    [SerializeField] private bool estaMaisProximo = false; // Indica se este objeto � o mais pr�ximo do jogador
    private bool estaInteragindo = false;
    // Implementa��o das propriedades da interface
    public bool EstaInteragindo
    {
        get => estaInteragindo;
        set
        {
            estaInteragindo = value;
        }
    }
    public bool EstaMaisProximo
    {
        get => estaMaisProximo;
        set
        {
            estaMaisProximo = value;
        }
    }

    public Transform[] PontosPrebab
    {
        get => pontosPrefab;
        set => pontosPrefab = value; // Caso necess�rio permitir redefinir os pontos externamente
    }

    public string TipoInteracao
    {
        get => tipoInteracao;
        set
        {
            tipoInteracao = value;
        }
    }
    [SerializeField] private ItemCore itemData; // Refer�ncia ao ScriptableObject do item

    public void Interagir()
    {
        // Certifique-se de que itemData n�o est� nulo
        if (itemData != null)
        {
            ColetarItem coletarItemScript = FindObjectOfType<ColetarItem>();
            if (coletarItemScript != null)
            {
                coletarItemScript.Coletar(itemData); // Passando o item correto
                Destroy(gameObject); // Remove o item do mapa
            }
            else
            {
                Debug.LogWarning("N�o foi poss�vel encontrar o script de coleta no jogador.");
            }
        }
        else
        {
            Debug.LogError("ItemCore est� nulo em ItemColetavel.");
        }
    }
}
