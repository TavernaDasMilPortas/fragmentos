using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciarVida : MonoBehaviour
{
    [SerializeField] private LifeControl vida;
    private Transform causadorDano;
    // Start is called before the first frame update
    void Start()
    {
        this.causadorDano = null;    
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ValorDano dano = collision.gameObject.GetComponent<ValorDano>();
        ValorCura cura = collision.gameObject.GetComponent<ValorCura>();
        if (dano!=null)
        {
            if(vida.vidaAtual - dano.valorDano > 0)
            {
                vida.vidaAtual -= dano.valorDano;
            }
            else
            {
                vida.vidaAtual = 0;
            }

        }
        if(cura!=null)
        {
            if (vida.vidaAtual + cura.valorCura < vida.vidaMax)
            {
                vida.vidaAtual += cura.valorCura;
            }
            else
            {
                vida.vidaAtual = vida.vidaMax;
            }

        }
    }
}
