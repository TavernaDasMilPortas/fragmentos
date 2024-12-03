using UnityEngine;
using TMPro;

public class BotaoInteracao : MonoBehaviour
{
    public SpriteRenderer parentSpriteRenderer; // Referência ao SpriteRenderer do pai
    private SpriteRenderer childSpriteRenderer; // Referência ao SpriteRenderer deste objeto
    public TextMeshPro textMesh; // Referência ao componente TextMeshPro

    void Start()
    {
        // Obtém o SpriteRenderer deste objeto
        childSpriteRenderer = GetComponent<SpriteRenderer>();

        // Tenta encontrar o SpriteRenderer no pai imediato
        if (transform.parent != null)
        {
            parentSpriteRenderer = transform.parent.GetComponent<SpriteRenderer>();
        }

        // Verifica se os componentes foram encontrados
        if (parentSpriteRenderer == null)
        {
            Debug.LogWarning($"O objeto pai de {name} não possui um SpriteRenderer.");
        }

        if (childSpriteRenderer == null)
        {
            Debug.LogError($"O objeto {name} não possui um SpriteRenderer.");
            enabled = false; // Desativa o script se não houver SpriteRenderer
        }

        if (textMesh == null)
        {
            Debug.LogError($"O objeto {name} não possui um TextMeshPro atribuído.");
        }
    }

    void Update()
    {
        if (parentSpriteRenderer != null && childSpriteRenderer != null)
        {
            // Sincroniza o estado ativo/desativo do SpriteRenderer do pai com o do filho
            childSpriteRenderer.enabled = parentSpriteRenderer.enabled;

            // Ajusta a visibilidade e o alpha do TextMeshPro com base no estado do SpriteRenderer do pai
            if (textMesh != null)
            {
                textMesh.gameObject.SetActive(parentSpriteRenderer.enabled);
            }
        }
    }
}