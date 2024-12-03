using UnityEngine;
using TMPro;

public class BotaoInteracao : MonoBehaviour
{
    public SpriteRenderer parentSpriteRenderer; // Refer�ncia ao SpriteRenderer do pai
    private SpriteRenderer childSpriteRenderer; // Refer�ncia ao SpriteRenderer deste objeto
    public TextMeshPro textMesh; // Refer�ncia ao componente TextMeshPro

    void Start()
    {
        // Obt�m o SpriteRenderer deste objeto
        childSpriteRenderer = GetComponent<SpriteRenderer>();

        // Tenta encontrar o SpriteRenderer no pai imediato
        if (transform.parent != null)
        {
            parentSpriteRenderer = transform.parent.GetComponent<SpriteRenderer>();
        }

        // Verifica se os componentes foram encontrados
        if (parentSpriteRenderer == null)
        {
            Debug.LogWarning($"O objeto pai de {name} n�o possui um SpriteRenderer.");
        }

        if (childSpriteRenderer == null)
        {
            Debug.LogError($"O objeto {name} n�o possui um SpriteRenderer.");
            enabled = false; // Desativa o script se n�o houver SpriteRenderer
        }

        if (textMesh == null)
        {
            Debug.LogError($"O objeto {name} n�o possui um TextMeshPro atribu�do.");
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