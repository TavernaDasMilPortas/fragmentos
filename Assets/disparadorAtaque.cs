using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparadorAtaque : MonoBehaviour
{
    [SerializeField] private GameObject alvo;  // Objeto do qual vamos obter o componente
    [SerializeField] private string nomeComponente;  // Nome do componente que será buscado no alvo
    private Iataque ataqueInterface;  // Interface para chamar o método Atacar

    void Start()
    {
        if (alvo != null && !string.IsNullOrEmpty(nomeComponente))
        {
            // Obtemos o tipo do componente com base no nome
            var tipoComponente = alvo.GetComponent(System.Type.GetType(nomeComponente));

            if (tipoComponente != null)
            {
                ataqueInterface = tipoComponente as Iataque;

                if (ataqueInterface == null)
                {
                    Debug.LogError($"O componente '{nomeComponente}' no objeto '{alvo.name}' não implementa a interface Iataque.");
                }
            }
            else
            {
                Debug.LogError($"Componente '{nomeComponente}' não encontrado no objeto '{alvo.name}'.");
            }
        }
        else
        {
            Debug.LogError("O alvo ou o nome do componente não estão definidos corretamente.");
        }
    }

    public void ExecutarAtaque()
    {
        // Chama o método Atacar no script que implementa Iataque
        if (ataqueInterface != null)
        {
            ataqueInterface.Atacar();
        }
    }

}
