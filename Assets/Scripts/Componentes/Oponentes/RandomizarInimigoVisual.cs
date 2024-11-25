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
    [Header("Configuração de visuais")]
    [SerializeField] private VisualConfig[] visualConfigs; // Array de configurações de visuais

    [Header("Componentes do inimigo")]
    [SerializeField] private SpriteRenderer spriteRenderer; // SpriteRenderer do inimigo
    [SerializeField] private Animator animator; // Animator do inimigo

    void Awake()
    {
        if (visualConfigs.Length == 0)
        {
            Debug.LogError("O array de VisualConfigs está vazio! Configure as opções no Inspector.");
            return;
        }

        RandomizarVisual();
    }

    /// <summary>
    /// Randomiza o visual do inimigo com base na configuração fornecida.
    /// </summary>
    private void RandomizarVisual()
    {
        // Escolhe um índice aleatório
        int randomIndex = Random.Range(0, visualConfigs.Length);

        // Aplica o AnimatorController correspondente
        if (animator != null && visualConfigs[randomIndex].animatorController != null)
        {
            animator.runtimeAnimatorController = visualConfigs[randomIndex].animatorController;
        }
        else
        {
            Debug.LogWarning("Animator ou AnimatorController não configurados corretamente.");
        }

        // Aplica o Sprite correspondente
        if (spriteRenderer != null && visualConfigs[randomIndex].sprite != null)
        {
            spriteRenderer.sprite = visualConfigs[randomIndex].sprite;
        }
        else
        {
            Debug.LogWarning("SpriteRenderer ou Sprite não configurados corretamente.");
        }
    }
}
