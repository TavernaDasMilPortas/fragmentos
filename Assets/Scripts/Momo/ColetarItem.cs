using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetarItem : MonoBehaviour
{
    [SerializeField] private Inventory inventario; // Refer�ncia ao sistema de invent�rio
    [SerializeField] private Interagir interagir;  // Script de intera��o do jogador
    private void Coletar(ItemCore itemCore)
    {
        InventorySlot slotVazio = EncontrarPrimeiroSlotVazio();
        if (slotVazio != null)
        {
            // Instancia um novo item para o invent�rio
            var novoItem = Instantiate(inventario.itemPrefab, inventario.draggablesTransform);
            novoItem.Initialize(itemCore, slotVazio);

            // Aloca o item no slot vazio
            slotVazio.SetItem(novoItem);

            // Remove o objeto coletado do mundo
            Destroy(itemCore);
        }
        else
        {
            Debug.Log("Invent�rio cheio!");
        }
    }

    private InventorySlot EncontrarPrimeiroSlotVazio()
    {
        foreach (var slot in inventario.slots)
        {
            if (slot.item == null)
            {
                return slot;
            }
        }
        return null; // Nenhum slot vazio encontrado
    }
}