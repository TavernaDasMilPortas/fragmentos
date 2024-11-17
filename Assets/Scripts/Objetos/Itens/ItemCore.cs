using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum slotTag { None, Fragmento, Carta, Consumivel}

[CreateAssetMenu(menuName = "Item")]
public class ItemCore : ScriptableObject, Iinteragivel
{
    public Sprite sprite;
    public slotTag slotTag;
    public string Descricao;
    public void Interagir() { }
}
