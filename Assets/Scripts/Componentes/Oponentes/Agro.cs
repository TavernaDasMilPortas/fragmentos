using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agro : MonoBehaviour
{
    [SerializeField] public OponenteCore oponente;
    public float tempoRestanteFoco;

    void Update()
    {
        tempoRestanteFoco -= 0.1f * Time.deltaTime;
        // Se o agro está ativado, o inimigo continuará focado no jogador
        if (tempoRestanteFoco > 0)
        {
           
            if (oponente.Alvo == null)
            {
                // O jogador está visível, o inimigo está focado nele
                oponente.Alvo = GameObject.FindGameObjectWithTag("Player").transform;
            }
        }
        else
        {
            Desagrar(); // O agro termina quando o tempo expira
        }
    }

    public void AtivarAgro()
    {
        // Ativa o agro e define o tempo de foco
        tempoRestanteFoco = oponente.TempoFoco;
        Debug.Log("Agro ativado!");
    }

    public void Desagrar()
    {
        // Desativa o agro e remove o alvo
        tempoRestanteFoco = 0f;
        oponente.Alvo = null;
        Debug.Log("Agro desativado!");
    }
}