using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum slotTag { None, Fragmento, Carta, Consumivel}

[CreateAssetMenu(menuName = "Item")]
public class ItemCore : ScriptableObject, Iinteragivel
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
    // Implementa��o das propriedades da interface
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
    public Sprite sprite;
    public slotTag slotTag;
    public string Descricao;
    public int quantidade = 1;
    public void Interagir() { }
}
