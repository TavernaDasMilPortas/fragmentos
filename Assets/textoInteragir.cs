using TMPro;
using UnityEngine;

public class TextoInteragir : MonoBehaviour
{
    [Header("Refer�ncias")]
    [SerializeField] private TextMeshPro textoTMP; // Refer�ncia ao TextMeshPro
    private Iinteragivel objetoInteragivel; // Refer�ncia ao objeto interag�vel

    private void Start()
    {
        // Busca o componente Iinteragivel do objeto pai
        objetoInteragivel = transform.parent.GetComponent<Iinteragivel>();

        // Se o objeto interag�vel foi encontrado, configura o texto inicial
        if (objetoInteragivel != null)
        {
            textoTMP.text = objetoInteragivel.TipoInteracao;
        }

        SetAlpha(0); // Torna o texto invis�vel no in�cio
    }

    /// <summary>
    /// Torna o texto vis�vel ajustando o alpha para 1.
    /// </summary>
    public void TornarVisivel()
    {
        SetAlpha(1);
    }

    /// <summary>
    /// Torna o texto invis�vel ajustando o alpha para 0.
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