using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Missao : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] protected TextMeshProUGUI textoPrincipalUI;
    [SerializeField] protected TextMeshProUGUI textoAuxiliarUI;

    [Header("Texto da Miss�o")]
    [SerializeField] public string textoPrincipal;  // Ex: "Derrote todos os inimigos"
    [SerializeField] public string textoAuxiliar;  // Ex: "0/5 inimigos derrotados"

    public int valorAtual = 0;   // Valor de progresso (atual)
    public int valorTotal = 0;   // Valor total (necess�rio para completar a miss�o)

    public abstract void AtualizarProgresso(); // M�todo para atualizar o progresso da miss�o

    // M�todo para configurar a miss�o com seus valores
    public virtual void ConfigurarMissao(int valorTotal)
    {
        this.valorTotal = valorTotal;
        valorAtual = 0;

        // Atualizar UI com texto da miss�o
        AtualizarTextoUI();
    }

    // Fun��o chamada para atualizar a UI
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
