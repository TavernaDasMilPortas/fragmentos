using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory inventory;
    public static InventoryItem carriedItem;
    [SerializeField] public InventorySlot[] slots;
    [SerializeField] public Transform draggablesTransform;
    [SerializeField] public InventoryItem itemPrefab;
    [SerializeField] public ItemCore[] itens;
    [SerializeField] PLayer player;

    void Awake()
    {
        inventory = this;
    }

    void Update()
    {
        if (carriedItem == null) return;

        carriedItem.transform.position = Input.mousePosition;
    }

    public void SetCarriedItem(InventoryItem item)
    {
        if (carriedItem != null)
        {
            item.activeSlot.SetItem(carriedItem);
        }

        carriedItem = item;
        carriedItem.canvasGroup.blocksRaycasts = false;
        item.transform.SetParent(draggablesTransform);
    }

    public InventorySlot EncontrarPrimeiroSlotVazio()
    {
        foreach (var slot in slots)
        {
            if (slot.item == null)
            {
                Debug.Log($"Slot vazio encontrado: {slot.name}");
                return slot;
            }
        }

        Debug.LogWarning("Nenhum slot vazio encontrado!");
        return null;
    }

    public InventorySlot EncontrarSlotComItem(ItemCore itemCore)
    {
        foreach (var slot in slots)
        {
            if (slot.item != null && slot.item.item == itemCore)
            {
                Debug.Log($"Item {itemCore.name} encontrado no slot {slot.name}.");
                return slot;
            }
        }

        return null;
    }

    public void AtualizarQuantidadeOuRemover(InventorySlot slot, int quantidade)
    {
        if (slot.item == null) return;

        slot.item.quantidade += quantidade;

        if (slot.item.quantidade <= 0)
        {
            Debug.Log($"Quantidade do item {slot.item.item.name} chegou a 0. Removendo do slot {slot.name}.");
            slot.RemoverItem();
        }
        else
        {
            Debug.Log($"Quantidade do item {slot.item.item.name} atualizada para {slot.item.quantidade}.");
        }
    }

    public InventorySlot EncontrarItemPorNome(ItemCore itemCore)
    {
        foreach (var slot in slots)
        {
            if (slot.item != null && slot.item.item == itemCore)
            {
                return slot;
            }
        }
        return null;
    }
}
