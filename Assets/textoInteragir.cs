using TMPro;
using UnityEngine;

public class TextoInteragir : MonoBehaviour
{
    [Header("Referências")]
    [SerializeField] private TextMeshPro textoTMP; // Referência ao TextMeshPro
    private Iinteragivel objetoInteragivel; // Referência ao objeto interagível

    private void Start()
    {
        // Busca o componente Iinteragivel do objeto pai
        objetoInteragivel = transform.parent.GetComponent<Iinteragivel>();

        // Se o objeto interagível foi encontrado, configura o texto inicial
        if (objetoInteragivel != null)
        {
            textoTMP.text = objetoInteragivel.TipoInteracao;
        }

        SetAlpha(0); // Torna o texto invisível no início
    }

    /// <summary>
    /// Torna o texto visível ajustando o alpha para 1.
    /// </summary>
    public void TornarVisivel()
    {
        SetAlpha(1);
    }

    /// <summary>
    /// Torna o texto invisível ajustando o alpha para 0.
    /// </summary>
    public void TornarInvisivel()
    {
        SetAlpha(0);
    }

    /// <summary>
    /// Ajusta o alpha do texto.
    /// </summary>
    /// <param name="alpha">Valor do alpha (0 a 1).</param>
    private void SetAlpha(float alpha)
    {
        if (textoTMP != null)
        {
            var corAtual = textoTMP.color;
            corAtual.a = alpha;
            textoTMP.color = corAtual;
        }
    }
}