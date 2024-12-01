using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogar : MonoBehaviour
{
    // Nome da cena da Fase 1
    [SerializeField] private string nomeCenaFase1 = "Fase 1 - Final";

    // Método chamado ao clicar no botão para iniciar a Fase 1
    public void TrocarParaFase1()
    {
        // Verifica se o nome da cena foi configurado
        if (string.IsNullOrEmpty(nomeCenaFase1))
        {
            Debug.LogError("O nome da cena da Fase 1 não foi configurado!");
            return;
        }

        // Troca para a cena da Fase 1
        Debug.Log($"Carregando a cena: {nomeCenaFase1}");
        SceneManager.LoadScene(nomeCenaFase1);
    }
}