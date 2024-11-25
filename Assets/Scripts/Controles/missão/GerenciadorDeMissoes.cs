using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GerenciadorDeMissoes : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI textoPrincipalUI;
    [SerializeField] private TextMeshProUGUI textoAuxiliarUI;
    [SerializeField] private GameObject painelMissao;

    public List<Missao> missoesAtivas = new List<Missao>();

    private void Update()
    {
        // Alterna a visibilidade do painel de miss�es com a tecla "Q"
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ToggleUI();
        }

        // Atualiza a UI para mostrar a primeira miss�o ativa
        if (missoesAtivas.Count > 0)
        {
            AtualizarUI();
        }
        else
        {
            LimparUI(); // Se n�o houver miss�es, limpa a UI
        }

        VerificarMissaoCompleta();
    }

    // Alterna a visibilidade da UI de miss�es
    private void ToggleUI()
    {
        painelMissao.SetActive(!painelMissao.activeSelf);
    }

    // Adiciona uma miss�o ao gerenciador
    public void AdicionarMissao(Missao missao)
    {
        ToggleUI();
        if (missao != null && !missoesAtivas.Contains(missao))
        {
            missoesAtivas.Add(missao);
            AtualizarUI();
        }
    }

    // Atualiza a UI com a miss�o ativa
    private void AtualizarUI()
    {
        if (missoesAtivas.Count > 0)
        {
            Missao missaoAtiva = missoesAtivas[0]; // Exibe a primeira miss�o ativa
            textoPrincipalUI.text = missaoAtiva.textoPrincipal;
            textoAuxiliarUI.text = missaoAtiva.textoAuxiliar;

            // Certifique-se de que a miss�o tem o progresso atualizado
            missaoAtiva.AtualizarProgresso();
        }
    }

    // Limpa os textos da UI quando n�o houver miss�es ativas
    private void LimparUI()
    {
        textoPrincipalUI.text = "";
        textoAuxiliarUI.text = "";
    }

    // Verifica se a miss�o foi completada e remove da lista
    private void VerificarMissaoCompleta()
    {
        for (int i = missoesAtivas.Count - 1; i >= 0; i--)
        {
            Missao missao = missoesAtivas[i];

            // Verifica se a miss�o foi completada
            if (missao.valorAtual >= missao.valorTotal)
            {
                // Remove a miss�o da lista
                missoesAtivas.RemoveAt(i);
                Debug.Log("Miss�o Completa: " + missao.textoPrincipal);

                // Atualiza a UI
                AtualizarUI();
            }
        }
    }
}