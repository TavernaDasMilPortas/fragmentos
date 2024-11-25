
    // Start is called before the first frame update
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeVida : MonoBehaviour
{
    [SerializeField] private VerificarVidaOponentes verificarVidaOponentes; // Refer�ncia para o script VerificarVidaOponentes

    // Fun��o chamada para adicionar o Caminhante � lista de oponentes
    public void AdicionarOponenteNaLista(OponenteCore oponente)
    {
        if (verificarVidaOponentes != null)
        {
            verificarVidaOponentes.AdicionarOponente(oponente); // Adiciona o oponente na lista de oponentes
        }
    }
}