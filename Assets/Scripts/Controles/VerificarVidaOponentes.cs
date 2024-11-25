using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificarVidaOponentes : MonoBehaviour
{
    // Lista de oponentes a serem verificados
    [SerializeField] public List<OponenteCore> oponentes; // Lista de oponentes
    [SerializeField] public bool todosMortos = false; // Variável que será alterada quando todos os oponentes morrerem

    // Função para adicionar um oponente à lista
    public void AdicionarOponente(OponenteCore oponente)
    {
        if (!oponente) return;
        if (!oponentes.Contains(oponente)) // Evita duplicados na lista
        {
            oponentes.Add(oponente);
        }
    }

    // Função que será chamada para verificar a vida dos oponentes
    void Update()
    {
        // Verifica se todos os oponentes estão mortos
        VerificarOponentes();
    }

    private void VerificarOponentes()
    {
        bool todosMortosTemp = true;

        // Percorre todos os oponentes para verificar sua vida
        foreach (var oponente in oponentes)
        {
            // Se algum oponente ainda estiver vivo, a variável todosMortosTemp será falsa
            if (oponente.Vida.vidaAtual > 0)
            {
                todosMortosTemp = false;
                break; // Se encontrar um oponente vivo, interrompe a verificação
            }
        }

        // Se todos os oponentes estiverem mortos, atualiza a variável
        if (todosMortosTemp != todosMortos)
        {
            todosMortos = todosMortosTemp;
            if (todosMortos)
            {
                // Faça algo quando todos os oponentes morrerem
                Debug.Log("Todos os oponentes estão mortos!");
                // Aqui você pode colocar a lógica que altera alguma variável ou aciona algum evento
            }
        }
    }

    // Método que retorna a quantidade de oponentes derrotados (com vida atual <= 0)
    public int GetQuantidadeOponentesDerrotados()
    {
        int quantidadeDerrotados = 0;

        // Percorre todos os oponentes e conta os que estão derrotados
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