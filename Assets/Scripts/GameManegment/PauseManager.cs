using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;
    private List<MonoBehaviour> pausedScripts = new List<MonoBehaviour>();

    // Lista de tipos de scripts que n�o devem ser pausados
    [SerializeField] private List<MonoBehaviour> scriptsExcluidos = new List<MonoBehaviour>();

    public void PauseAll()
    {
        if (isPaused) return;

        isPaused = true;

        // Pausar todos os scripts em cena, exceto os da lista de exce��es
        MonoBehaviour[] allScripts = FindObjectsOfType<MonoBehaviour>();
        foreach (var script in allScripts)
        {
            // Verifica se o script n�o est� na lista de exce��es
            if (!scriptsExcluidos.Contains(script) && script.enabled)
            {
                pausedScripts.Add(script);
                script.enabled = false;
            }
        }

        Debug.Log("Jogo pausado, todos os scripts desativados.");
    }

    public void PauseAllExcept(GameObject[] exceptions)
    {
        if (isPaused) return;

        isPaused = true;

        // Obter os scripts a serem mantidos ativos
        HashSet<MonoBehaviour> scriptsToKeepActive = new HashSet<MonoBehaviour>();
        foreach (GameObject obj in exceptions)
        {
            MonoBehaviour[] exceptionScripts = obj.GetComponents<MonoBehaviour>();
            foreach (var script in exceptionScripts)
            {
                scriptsToKeepActive.Add(script);
            }
        }

        // Pausar todos os outros scripts, exceto os da lista de exce��es
        MonoBehaviour[] allScripts = FindObjectsOfType<MonoBehaviour>();
        foreach (var script in allScripts)
        {
            if (scriptsToKeepActive.Contains(script) || scriptsExcluidos.Contains(script)) continue;

            if (script.enabled)
            {
                pausedScripts.Add(script);
                script.enabled = false;
            }
        }

        Debug.Log("Jogo pausado, exceto para os scripts nos objetos especificados e os que est�o na lista de exclus�es.");
    }

    public void Resume()
    {
        if (!isPaused) return;

        // Reativar todos os scripts que foram pausados
        foreach (var script in pausedScripts)
        {
            if (script != null)
            {
                script.enabled = true;
            }
        }

        pausedScripts.Clear();
        isPaused = false;

        Debug.Log("Jogo retomado.");
    }

    public bool IsPaused()
    {
        return isPaused;
    }

    // Adicionar script � lista de exce��es
    public void AddScriptToExclusionList(MonoBehaviour script)
    {
        if (!scriptsExcluidos.Contains(script))
        {
            scriptsExcluidos.Add(script);
        }
    }

    // Remover script da lista de exce��es
    public void RemoveScriptFromExclusionList(MonoBehaviour script)
    {
        if (scriptsExcluidos.Contains(script))
        {
            scriptsExcluidos.Remove(script);
        }
    }
}