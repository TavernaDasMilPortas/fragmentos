using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Iinteragivel
{
    public Sprite[] spritesSelecionaveis { get; set; }
    public int indiceSprite { get; set; }
    public Sprite SpritePadrao { get; set; } // Adicionada a propriedade para armazenar o sprite padrão
    public void Interagir();
}