using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOponente : MonoBehaviour
{
    [SerializeField] private GameObject caminhantePrefab; // Prefab do Caminhante
    [SerializeField] private GerenciadorDeVida gerenciadorDeVida; // Referência para o GerenciadorDeVida
    [System.Serializable]
    public class CaminhanteConfig
    {
        public Transform spawnPoint; // Posição inicial do Caminhante
        public Transform[] waypoints; // Waypoints específicos para este Caminhante
    }

    [SerializeField] private CaminhanteConfig[] caminhantesConfig; // Configuração dos Caminhantes

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
                Debug.LogError($"Configuração do Caminhante {i + 1} está incompleta!");
                continue;
            }

            // Instancia o Caminhante na posição do spawnPoint
            GameObject novoCaminhante = Instantiate(caminhantePrefab, config.spawnPoint.position, Quaternion.identity);

            // Atribui os waypoints ao script de patrulha do Caminhante
            Patrulhar patrulharScript = novoCaminhante.GetComponent<Patrulhar>();
            if (patrulharScript != null)
            {
                patrulharScript.waypoints = config.waypoints; // Configura os waypoints específicos
                Debug.Log($"Caminhante {i + 1} configurado com {config.waypoints.Length} waypoints.");
            }
            else
            {
                Debug.LogError($"O Caminhante {i + 1} não possui o script Patrulhar!");
            }

            // Adiciona o Caminhante à lista de oponentes do GerenciadorDeVida
            if (gerenciadorDeVida != null)
            {
                OponenteCore oponenteCore = novoCaminhante.GetComponent<OponenteCore>();
                if (oponenteCore != null)
                {
                    gerenciadorDeVida.AdicionarOponenteNaLista(oponenteCore);
                }
                else
                {
                    Debug.LogError("O Caminhante não possui um OponenteCore ou o GerenciadorDeVida não está configurado!");
                }
            }

        }
    }
}