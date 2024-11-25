using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOponente : MonoBehaviour
{
    [SerializeField] private GameObject caminhantePrefab; // Prefab do Caminhante
    [SerializeField] private GerenciadorDeVida gerenciadorDeVida; // Refer�ncia para o GerenciadorDeVida
    [System.Serializable]
    public class CaminhanteConfig
    {
        public Transform spawnPoint; // Posi��o inicial do Caminhante
        public Transform[] waypoints; // Waypoints espec�ficos para este Caminhante
    }

    [SerializeField] private CaminhanteConfig[] caminhantesConfig; // Configura��o dos Caminhantes

    public void InstanciarCaminhantes()
    {
        if (caminhantePrefab == null || caminhantesConfig.Length == 0)
        {
            Debug.LogError("Configure o Caminhante Prefab e Caminhantes Config corretamente!");
            return;
        }

        for (int i = 0; i < caminhantesConfig.Length; i++)
        {
            CaminhanteConfig config = caminhantesConfig[i];
            if (config.spawnPoint == null || config.waypoints.Length == 0)
            {
                Debug.LogError($"Configura��o do Caminhante {i + 1} est� incompleta!");
                continue;
            }

            // Instancia o Caminhante na posi��o do spawnPoint
            GameObject novoCaminhante = Instantiate(caminhantePrefab, config.spawnPoint.position, Quaternion.identity);

            // Atribui os waypoints ao script de patrulha do Caminhante
            Patrulhar patrulharScript = novoCaminhante.GetComponent<Patrulhar>();
            if (patrulharScript != null)
            {
                patrulharScript.waypoints = config.waypoints; // Configura os waypoints espec�ficos
                Debug.Log($"Caminhante {i + 1} configurado com {config.waypoints.Length} waypoints.");
            }
            else
            {
                Debug.LogError($"O Caminhante {i + 1} n�o possui o script Patrulhar!");
            }

            // Adiciona o Caminhante � lista de oponentes do GerenciadorDeVida
            if (gerenciadorDeVida != null)
            {
                OponenteCore oponenteCore = novoCaminhante.GetComponent<OponenteCore>();
                if (oponenteCore != null)
                {
                    gerenciadorDeVida.AdicionarOponenteNaLista(oponenteCore);
                }
                else
                {
                    Debug.LogError("O Caminhante n�o possui um OponenteCore ou o GerenciadorDeVida n�o est� configurado!");
                }
            }

        }
    }
}