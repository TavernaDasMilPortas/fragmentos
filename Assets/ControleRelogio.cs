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
    [SerializeField] RectTransform pontoInicial; // Ponto inicial para os relógios
    private Vector2 distanciaEntreIcones = new Vector2(25f, 0); // Distância entre os relógios
    private int RelogioFrente; // Índice do relógio da frente
    public int vidaRelogioFrente; // Vida do relógio da frente
    public List<GameObject> relogios = new List<GameObject>(); // Lista de relógios instanciados
    [SerializeField] public TextMeshProUGUI textoVida; // Texto da UI que exibe a vida   
    private int qtdRelogios; // Quantidade total de relógios a ser instanciada

    public void IniciarRelogios()
    {
        qtdRelogios = CalcularQuantidadeRelogios(Vida.vidaAtual);
        RelogioFrente = qtdRelogios - 1;

        // Instancia os relógios
        RectTransform pontoInicialRect = pontoInicial.GetComponent<RectTransform>();

        for (int i = 0; i < qtdRelogios; i++)
        {
            // Calcula a posição relativa
            Vector2 posicao = pontoInicialRect.anchoredPosition + (i * distanciaEntreIcones);

            // Instancia o relógio como filho do ponto inicial
            GameObject relogio = Instantiate(relogioPrefab, pontoInicial.parent);
            RectTransform rectTransform = relogio.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = posicao;
            rectTransform.localScale = Vector3.one;

            relogios.Add(relogio);
        }

        vidaRelogioFrente = CalcularVidaRelogioFrente(Vida.vidaAtual, qtdRelogios);
        AtualizarRelogios();
        AtualizarPosicaoTextoVida();
    }

    public void ModificarRelogio()
    {
        // Atualize o texto de vida
        textoVida.text = Vida.vidaAtual.ToString();

        // Verifique a quantidade de relógios necessária
        int novaQtdRelogios = CalcularQuantidadeRelogios(Vida.vidaAtual);
        if (novaQtdRelogios < qtdRelogios)
        {
            DesativarRelogios(qtdRelogios - novaQtdRelogios);
        }

        // Atualize os índices e valores do relógio da frente
        RelogioFrente = novaQtdRelogios - 1;
        vidaRelogioFrente = CalcularVidaRelogioFrente(Vida.vidaAtual, novaQtdRelogios);

        // Atualize a UI
        AtualizarRelogios();
        AtualizarPosicaoTextoVida(); // Reposicione o texto da vida
    }

    private void AtualizarPosicaoTextoVida()
    {
        if (RelogioFrente >= 0 && RelogioFrente < relogios.Count)
        {
            RectTransform relogioFrenteRect = relogios[RelogioFrente].GetComponent<RectTransform>();
            RectTransform textoVidaRect = textoVida.GetComponent<RectTransform>();

            // Defina uma distância específica do texto em relação ao relógio
            Vector2 distanciaTexto = new Vector2(100f, -20f);
            textoVidaRect.anchoredPosition = pontoInicial.anchoredPosition + ((qtdRelogios + 1) * distanciaEntreIcones) + distanciaTexto;
        }
    }

    private void AtualizarRelogios()
    {
        textoVida.text = Vida.vidaAtual.ToString();

        for (int i = 0; i < relogios.Count; i++)
        {
            GameObject relogio = relogios[i];
            if (i == RelogioFrente)
            {
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
