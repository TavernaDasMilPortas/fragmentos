using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificarVidaOponentes : MonoBehaviour
{
    // Lista de oponentes a serem verificados
    [SerializeField] public List<OponenteCore> oponentes; // Lista de oponentes
    [SerializeField] public bool todosMortos = false; // Vari�vel que ser� alterada quando todos os oponentes morrerem

    // Fun��o para adicionar um oponente � lista
    public void AdicionarOponente(OponenteCore oponente)
    {
        if (!oponente) return;
        if (!oponentes.Contains(oponente)) // Evita duplicados na lista
        {
            oponentes.Add(oponente);
        }
    }

    // Fun��o que ser� chamada para verificar a vida dos oponentes
    void Update()
    {
        // Verifica se todos os oponentes est�o mortos
        VerificarOponentes();
    }

    private void VerificarOponentes()
    {
        bool todosMortosTemp = true;

        // Percorre todos os oponentes para verificar sua vida
        foreach (var oponente in oponentes)
        {
            // Se algum oponente ainda estiver vivo, a vari�vel todosMortosTemp ser� falsa
            if (oponente.Vida.vidaAtual > 0)
            {
                todosMortosTemp = false;
                break; // Se encontrar um oponente vivo, interrompe a verifica��o
            }
        }

        // Se todos os oponentes estiverem mortos, atualiza a vari�vel
        if (todosMortosTemp != todosMortos)
        {
            todosMortos = todosMortosTemp;
            if (todosMortos)
            {
                // Fa�a algo quando todos os oponentes morrerem
                Debug.Log("Todos os oponentes est�o mortos!");
                // Aqui voc� pode colocar a l�gica que altera alguma vari�vel ou aciona algum evento
            }
        }
    }

    // M�todo que retorna a quantidade de oponentes derrotados (com vida atual <= 0)
    public int GetQuantidadeOponentesDerrotados()
    {
        int quantidadeDerrotados = 0;

        // Percorre todos os oponentes e conta os que est�o derrotados
        foreach (var oponente in oponentes)
        {
            if (oponente.Vida.vidaAtual <= 0) // Oponente derrotado
            {
                quantidadeDerrotados++;
            }
        }

        return quantidadeDerrotados;
    }
}