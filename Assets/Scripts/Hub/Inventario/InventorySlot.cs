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

        }
        SetItem(Inventory.carriedItem);
    }

    public void SetItem(InventoryItem Vitem)
    {
        Inventory.carriedItem = null;
        item.activeSlot.item = null;
        item = Vitem;
        item.transform.SetParent(this.transform);
        item.canvasGroup.blocksRaycasts = true;

    }

}
