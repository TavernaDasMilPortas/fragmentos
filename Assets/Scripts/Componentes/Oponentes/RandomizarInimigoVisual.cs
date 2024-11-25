using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VisualConfig
{
    public RuntimeAnimatorController animatorController; // Controle do Animator
    public Sprite sprite; // Sprite para o inimigo
}

public class RandomizarInimigoVisual : MonoBehaviour
{
    [Header("Configura��o de visuais")]
    [SerializeField] private VisualConfig[] visualConfigs; // Array de configura��es de visuais

    [Header("Componentes do inimigo")]
    [SerializeField] private SpriteRenderer spriteRenderer; // SpriteRenderer do inimigo
    [SerializeField] private Animator animator; // Animator do inimigo

    void Awake()
    {
        if (visualConfigs.Length == 0)
        {
            Debug.LogError("O array de VisualConfigs est� vazio! Configure as op��es no Inspector.");
            return;
        }

        RandomizarVisual();
    }

    /// <summary>
    /// Randomiza o visual do inimigo com base na configura��o fornecida.
    /// </summary>
    private void RandomizarVisual()
    {
        // Escolhe um �ndice aleat�rio
        int randomIndex = Random.Range(0, visualConfigs.Length);

        // Aplica o AnimatorController correspondente
        if (animator != null && visualConfigs[randomIndex].animatorController != null)
        {
            animator.runtimeAnimatorController = visualConfigs[randomIndex].animatorController;
        }
        else
        {
            Debug.LogWarning("Animator ou AnimatorController n�o configurados corretamente.");
        }

        // Aplica o Sprite correspondente
        if (spriteRenderer != null && visualConfigs[randomIndex].sprite != null)
        {
            spriteRenderer.sprite = visualConfigs[randomIndex].sprite;
        }
        else
        {
            Debug.LogWarning("SpriteRenderer ou Sprite n�o configurados corretamente.");
        }
    }
}
