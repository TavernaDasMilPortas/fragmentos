using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agro : MonoBehaviour
{
    [SerializeField] public OponenteCore oponente;
    public float tempoRestanteFoco;
    void Update()
    {
        if (tempoRestanteFoco > 0)
        {
            tempoRestanteFoco -= Time.deltaTime;
            oponente.Alvo = GameObject.FindGameObjectWithTag("Player").transform;

        }
        else
        {
            Desagrar();
        }
    }
    public void AtivarAgro()
    {
        tempoRestanteFoco = oponente.TempoFoco;
    }

    public void Desagrar()
    {
        tempoRestanteFoco = 0f;
        oponente.Alvo = null;
    }
}
