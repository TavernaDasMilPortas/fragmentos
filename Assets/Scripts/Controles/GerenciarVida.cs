using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            if (CompareTag("Player"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                Destroy(gameObject);
            }

        }
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.CompareTag("Oponente"))
        {
            ValorDano dano = collision.gameObject.GetComponent<ValorDano>();
            if (dano != null)
            {
                if (vidaAtual - dano.valorDano > 0)
                {
                    vidaAtual -= dano.valorDano;
                }
                else
                {
                    vidaAtual = 0;
                }

            }

        }
        ValorCura cura = collision.gameObject.GetComponent<ValorCura>();
        if (cura!=null)
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

    public void JogadorSofreDano(ValorDano dano)
    {
        Debug.Log("Vida atual:" + this.vidaAtual + "dano a ser sofrido" + dano.valorDano);
        if (this.vidaAtual - dano.valorDano > 0)
        {
            this.vidaAtual -= dano.valorDano;
            Debug.Log("vida pós tomar dano" + this.vidaAtual);
        }
        else
        {
            this.vidaAtual = 0;
        }
    }
}
