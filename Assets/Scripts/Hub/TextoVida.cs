using TMPro;
using UnityEngine;

public class TextoNaTela : MonoBehaviour
{
    public TextMeshProUGUI textoTMP;
    public GerenciarVida vida;
    void Start()
    {
        textoTMP.text = vida.vidaAtual.ToString();
    }
    void Update()
    {
        textoTMP.text = vida.vidaAtual.ToString();
    }


}