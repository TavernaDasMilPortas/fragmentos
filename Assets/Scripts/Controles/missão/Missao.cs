using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Missao : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] protected TextMeshProUGUI textoPrincipalUI;
    [SerializeField] protected TextMeshProUGUI textoAuxiliarUI;

    [Header("Texto da Missão")]
    [SerializeField] public string textoPrincipal;  // Ex: "Derrote todos os inimigos"
    [SerializeField] public string textoAuxiliar;  // Ex: "0/5 inimigos derrotados"

    public int valorAtual = 0;   // Valor de progresso (atual)
    public int valorTotal = 0;   // Valor total (necessário para completar a missão)

    public abstract void AtualizarProgresso(); // Método para atualizar o progresso da missão

    // Método para configurar a missão com seus valores
    public virtual void ConfigurarMissao(int valorTotal)
    {
        this.valorTotal = valorTotal;
        valorAtual = 0;

        // Atualizar UI com texto da missão
        AtualizarTextoUI();
    }

    // Função chamada para atualizar a UI
    protected void AtualizarTextoUI()
    {
        if (textoPrincipalUI != null)
        {
            textoPrincipalUI.text = textoPrincipal;
        }

        if (textoAuxiliarUI != null)
        {
            textoAuxiliarUI.text = valorAtual + "/" + valorTotal;
        }
    }
}
