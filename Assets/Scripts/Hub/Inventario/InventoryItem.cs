using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class InventoryItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image itemIcon;
    [SerializeField] public CanvasGroup canvasGroup;
    public ItemCore item;
    public InventorySlot activeSlot;
    public int quantidade;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        itemIcon = GetComponent<Image>();

        if (itemIcon == null)
        {
            Debug.LogError("Nenhum componente Image encontrado no objeto.");
        }
    }

    public void Initialize(ItemCore Vitem, InventorySlot parent, int qtd = 1)
    {
        if (Vitem == null || Vitem.sprite == null || itemIcon == null)
        {
            Debug.LogError("Erro ao inicializar InventoryItem: informações incompletas.");
            return;
        }

        activeSlot = parent;
        item = Vitem;
        quantidade = qtd;
        itemIcon.sprite = item.sprite;
        UpdateDisplay();
    }

    public void AddQuantidade(int qtd)
    {
        quantidade += qtd;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        // Aqui você pode atualizar a interface, como mostrar a quantidade no slot.
        // Exemplo: se você tiver um Text associado ao slot, atualize-o com a quantidade.
        Debug.Log($"Quantidade do item {item.name} atualizada para: {quantidade}");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Logica para clique no item, se necessário.
        }
    }
}
