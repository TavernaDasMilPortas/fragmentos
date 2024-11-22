using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControleRelogio : MonoBehaviour
{
    [SerializeField] Sprite[] sprites; // Sprites para os relógios
    [SerializeField] GerenciarVida Vida; // Referência ao gerenciador de vida
    [SerializeField] GameObject relogioPrefab; // Prefab do relógio que possui o componente Image
    [SerializeField] Transform pontoInicial; // Ponto inicial para os relógios
    private Vector2 distanciaEntreIcones = new Vector2(25f, 0); // Distância entre os relógios
    private int RelogioFrente; // Índice do relógio da frente
    public int vidaRelogioFrente; // Vida do relógio da frente
    public List<GameObject> relogios = new List<GameObject>(); // Lista de relógios instanciados
    [SerializeField] public TextMeshProUGUI textoVida; // Texto da UI que exibe a vida
    private int qtdRelogios; // Quantidade total de relógios a ser instanciada

    public void IniciarRelogios()
    {
        // Calcula a quantidade inicial de relógios
        qtdRelogios = CalcularQuantidadeRelogios(Vida.vidaAtual);
        RelogioFrente = qtdRelogios - 1;

        Debug.Log($"Iniciando relógios. Quantidade: {qtdRelogios}");

        // Instancia os relógios
        for (int i = 0; i < qtdRelogios; i++)
        {
            Vector2 posicao = (Vector2)pontoInicial.position + (i * distanciaEntreIcones);
            GameObject relogio = Instantiate(relogioPrefab, pontoInicial.parent);
            RectTransform rectTransform = relogio.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = posicao;
            rectTransform.localScale = Vector3.one;

            relogios.Add(relogio);
        }

        vidaRelogioFrente = CalcularVidaRelogioFrente(Vida.vidaAtual, qtdRelogios);
        AtualizarRelogios();
    }

    public void ModificarRelogio()
    {
        textoVida.text = Vida.vidaAtual.ToString(); // Atualiza o texto da vida do jogador
        Debug.Log($"Vida atual: {Vida.vidaAtual}");

        int novaQtdRelogios = CalcularQuantidadeRelogios(Vida.vidaAtual);
        if (novaQtdRelogios < qtdRelogios)
        {
            DesativarRelogios(qtdRelogios - novaQtdRelogios);
        }

        RelogioFrente = novaQtdRelogios - 1;
        vidaRelogioFrente = CalcularVidaRelogioFrente(Vida.vidaAtual, novaQtdRelogios);

        AtualizarRelogios();
    }

    private void AtualizarRelogios()
    {
        Debug.Log($"Atualizando relógios: qtdRelogios={qtdRelogios}, RelogioFrente={RelogioFrente}, VidaRelogioFrente={vidaRelogioFrente}");

        for (int i = 0; i < relogios.Count; i++)
        {
            GameObject relogio = relogios[i];
            if (i == RelogioFrente)
            {
                Debug.Log($"Atualizando sprite do relógio {i}, Vida do relógio: {vidaRelogioFrente}");
                relogio.GetComponent<Image>().sprite = sprites[vidaRelogioFrente - 1];
                relogio.GetComponent<CanvasRenderer>().SetAlpha(1);
            }
            else if (i < qtdRelogios)
            {
                relogio.GetComponent<CanvasRenderer>().SetAlpha(1);
            }
            else
            {
                relogio.GetComponent<CanvasRenderer>().SetAlpha(0);
            }
        }
    }

    private void DesativarRelogios(int quantidade)
    {
        for (int i = 0; i < quantidade; i++)
        {
            if (relogios.Count > 0)
            {
                int index = relogios.Count - 1;
                Debug.Log($"Desativando relógio {index}");
                relogios[index].GetComponent<CanvasRenderer>().SetAlpha(0);
                relogios.RemoveAt(index);
            }
        }
        qtdRelogios -= quantidade;
    }

    private int CalcularQuantidadeRelogios(int vida)
    {
        return Mathf.CeilToInt(vida / 12f);
    }

    private int CalcularVidaRelogioFrente(int vida, int qtdRelogios)
    {
        return vida - ((qtdRelogios - 1) * 12);
    }
}
