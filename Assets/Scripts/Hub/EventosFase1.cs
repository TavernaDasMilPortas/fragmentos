using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventosFase1 : MonoBehaviour
{
    [SerializeField] SpawnOponente spawnCaminhante;
    [SerializeField] SpawnOponente spawnInicial;
    [SerializeField] GerenciadorDeMissoes gerenciadorDeMissoes;
    [SerializeField] Missao missao1;
    public void AtivarCaminhantes()
    {

        spawnCaminhante.InstanciarCaminhantes();
        gerenciadorDeMissoes.missoesAtivas.Add(missao1);
    }

   void Start()
    {

  
    }

}
