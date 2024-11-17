using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetarItem : MonoBehaviour
{
    [SerializeField] private Inventory inventario; // Referência ao sistema de inventário
    [SerializeField] private Interagir interagir;  // Script de interação do jogador
    private void Coletar(ItemCore itemCore)
    {
        InventorySlot slotVazio = EncontrarPrimeiroSlotVazio();
        if (slotVazio != null)
        {
            // Instancia um novo item para o inventário
            var novoItem = Instantiate(inventario.itemPrefab, inventario.draggablesTransform);
            novoItem.Initialize(itemCore, slotVazio);

            // Aloca o item no slot vazio
            slotVazio.SetItem(novoItem);

            // Remove o objeto coletado do mundo
            Destroy(itemCore);
        }
        else
        {
            Debug.Log("Inventário cheio!");
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