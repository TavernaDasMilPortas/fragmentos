using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agro : MonoBehaviour
{
    [SerializeField] public OponenteCore oponente;
    public float tempoRestanteFoco;

    void LateUpdate()
    {

        // Se o agro est� ativado, o inimigo continuar� focado no jogador
        if (tempoRestanteFoco > 0)
        {
            tempoRestanteFoco -= Time.deltaTime;
            if (oponente.Alvo == null)
            {
                // O jogador est� vis�vel, o inimigo est� focado nele
                oponente.Alvo = GameObject.FindGameObjectWithTag("Player").transform;
            }
        }
        else if(tempoRestanteFoco <= 0)
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