using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class InventoryItem : MonoBehaviour, IPointerClickHandler
{
    Image itemIcon;
    public CanvasGroup canvasGroup {  get; private set; }
    public ItemCore item { get; set; }
    public InventorySlot activeSlot { get; set; }

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        itemIcon = GetComponent<Image>();
    }

    public void Initialize(ItemCore Vitem, InventorySlot parent)
    {
        activeSlot = parent;
        activeSlot.item = this;
        item = Vitem;
        itemIcon.sprite = item.sprite; 
        
    }
    public void OnPointerClick(PointerEventData eventData) 
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {

        }
    }
}
