using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeControl : MonoBehaviour
{
    [SerializeField]
    public int vidaMax = 10;
    public int vidaAtual;
    // Start is called before the first frame update
    void Start()
    {
        vidaAtual = vidaMax - 1;
    }

    // Update is called once per frame
    public void RecuperarVida(int recuperacao)
    {
        if (vidaAtual + recuperacao < vidaMax)
        {
            vidaAtual = vidaAtual + recuperacao;
        }
        else
        {
            vidaAtual = vidaMax;
        }
    }
    public void SofrerDano(int dano)
    {
        if (vidaAtual - dano > 0)
        {
            vidaAtual = vidaAtual - dano;
        }
    }
}
