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
        if (carriedItem == null)
        {
            return;
        }
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

}
