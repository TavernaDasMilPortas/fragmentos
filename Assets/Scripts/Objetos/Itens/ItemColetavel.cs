using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemColetavel : MonoBehaviour, Iinteragivel
{
    [SerializeField] private Sprite[] _spritesSelecionaveis; // Exposto no Inspector
    [SerializeField] private int _indiceSprite = 0; // Exposto no Inspector
    [SerializeField] private Sprite _spritePadrao; // Armazena o sprite original do objeto

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
    [SerializeField] private ItemCore itemData; // Referência ao ScriptableObject do item

    public void Interagir()
    {
        // Certifique-se de que itemData não está nulo
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
                Debug.LogWarning("Não foi possível encontrar o script de coleta no jogador.");
            }
        }
        else
        {
            Debug.LogError("ItemCore está nulo em ItemColetavel.");
        }
    }
}
