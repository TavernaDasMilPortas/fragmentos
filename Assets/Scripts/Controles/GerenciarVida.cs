using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciarVida : MonoBehaviour
{
    [SerializeField]
    public int vidaMax;
    public int vidaAtual;
    public int vidaAnterior;
    // Start is called before the first frame update

    void Update()
    {

        Morrer();
    }
    public void Morrer()
    {
        if (vidaAtual <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ValorDano dano = collision.gameObject.GetComponent<ValorDano>();
        ValorCura cura = collision.gameObject.GetComponent<ValorCura>();
        if (dano!=null)
        {
            if(vidaAtual - dano.valorDano > 0)
            {
                vidaAtual -= dano.valorDano;
            }
            else
            {
                vidaAtual = 0;
            }

        }
        if(cura!=null)
        {
            if (vidaAtual + cura.valorCura < vidaMax)
            {
               vidaAtual += cura.valorCura;
            }
            else
            {
                vidaAtual = vidaMax;
            }

        }
    }
    public bool ConferirMudancaVida(int vAtual, int vAnterior)
    {
        if (vAtual != vAnterior)
        {
            vidaAnterior = vAtual;
            return true;
        }
        else
        {
            return false;
        }
    }
}
