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
        // Alterna a visibilidade do painel de missões com a tecla "Q"
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ToggleUI();
        }

        // Atualiza a UI para mostrar a primeira missão ativa
        if (missoesAtivas.Count > 0)
        {
            AtualizarUI();
        }
        else
        {
            LimparUI(); // Se não houver missões, limpa a UI
        }

        VerificarMissaoCompleta();
    }

    // Alterna a visibilidade da UI de missões
    private void ToggleUI()
    {
        painelMissao.SetActive(!painelMissao.activeSelf);
    }

    // Adiciona uma missão ao gerenciador
    public void AdicionarMissao(Missao missao)
    {
        ToggleUI();
        if (missao != null && !missoesAtivas.Contains(missao))
        {
            missoesAtivas.Add(missao);
            AtualizarUI();
        }
    }

    // Atualiza a UI com a missão ativa
    private void AtualizarUI()
    {
        if (missoesAtivas.Count > 0)
        {
            Missao missaoAtiva = missoesAtivas[0]; // Exibe a primeira missão ativa
            textoPrincipalUI.text = missaoAtiva.textoPrincipal;
            textoAuxiliarUI.text = missaoAtiva.textoAuxiliar;

            // Certifique-se de que a missão tem o progresso atualizado
            missaoAtiva.AtualizarProgresso();
        }
    }

    // Limpa os textos da UI quando não houver missões ativas
    private void LimparUI()
    {
        textoPrincipalUI.text = "";
        textoAuxiliarUI.text = "";
    }

    // Verifica se a missão foi completada e remove da lista
    private void VerificarMissaoCompleta()
    {
        for (int i = missoesAtivas.Count - 1; i >= 0; i--)
        {
            Missao missao = missoesAtivas[i];

            // Verifica se a missão foi completada
            if (missao.valorAtual >= missao.valorTotal)
            {
                // Remove a missão da lista
                missoesAtivas.RemoveAt(i);
                Debug.Log("Missão Completa: " + missao.textoPrincipal);

                // Atualiza a UI
                AtualizarUI();
            }
        }
    }
}