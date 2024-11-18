using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    public InventoryItem item { get; set; }
    public slotTag tag;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Lógica de uso do item
        }
    }

    public void SetItem(InventoryItem Vitem)
    {
        if (item != null)
        {
            Debug.LogWarning($"Tentando adicionar um item no slot {this.name}, mas já há um item presente.");
            return;
        }

        item = Vitem;
        item.transform.SetParent(this.transform);
        item.canvasGroup.blocksRaycasts = true;
        Debug.Log($"Item {Vitem.item.name} adicionado ao slot {this.name}.");
    }

    public void RemoverItem()
    {
        if (item != null)
        {
            Destroy(item.gameObject); // Remove o GameObject do item
            item = null; // Limpa o slot
            Debug.Log($"Item removido do slot {this.name}.");
        }
    }
}