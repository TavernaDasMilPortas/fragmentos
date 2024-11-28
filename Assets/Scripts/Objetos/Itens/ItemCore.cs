using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum slotTag { None, Fragmento, Carta, Consumivel}

[CreateAssetMenu(menuName = "Item")]
public class ItemCore : ScriptableObject, Iinteragivel
{
    [SerializeField] private Sprite[] _spritesSelecionaveis; // Exposto no Inspector
    [SerializeField] private int _indiceSprite = 0; // Exposto no Inspector
    [SerializeField]  private Sprite _spritePadrao; // Armazena o sprite original do objeto

    public Sprite[] spritesSelecionaveis
    {
        get => _spritesSelecionaveis;
        set => _spritesSelecionaveis = value;
    }

    public int indiceSprite
    {
        get => _indiceSprite;
        set => _indiceSprite = value;
    }

    public Sprite SpritePadrao
    {
        get => _spritePadrao;
        set => _spritePadrao = value;
    }
    public Sprite sprite;
    public slotTag slotTag;
    public string Descricao;
    public int quantidade = 1;
    public void Interagir() { }
}
