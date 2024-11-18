using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetarItem : MonoBehaviour
{
    [SerializeField] private Inventory inventario;

    public void Coletar(ItemCore itemCore)
    {
        var slotComItemIgual = inventario.EncontrarSlotComItem(itemCore);
        if (slotComItemIgual != null)
        {
            inventario.AtualizarQuantidadeOuRemover(slotComItemIgual, 1);
            return;
        }

        var slotVazio = inventario.EncontrarPrimeiroSlotVazio();
        if (slotVazio != null)
        {
            var novoItem = Instantiate(inventario.itemPrefab, inventario.draggablesTransform);
            if (novoItem != null)
            {
                novoItem.Initialize(itemCore, slotVazio, 1);
                slotVazio.SetItem(novoItem);
                Debug.Log($"Novo item {itemCore.name} adicionado ao slot {slotVazio.name}.");
            }
            else
            {
                Debug.LogError("Erro ao instanciar novo item.");
            }
        }
        else
        {
            Debug.LogWarning("Nenhum slot vazio encontrado.");
        }
    }
}