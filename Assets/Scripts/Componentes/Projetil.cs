using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Projetil : MonoBehaviour
{
    public ValorDano dano;
    public string tipo = null;
    private OponenteCore oponente;
    // Método personalizado para inicializar o objeto após instanciado
    public void Inicializar(int dano, string tipo)
    {
        this.dano.valorDano = dano;
        this.tipo = tipo;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (tipo != null)
        {
            if (collision.gameObject.CompareTag("Oponente"))
            {
                // Tenta obter o componente Oponente do objeto
                oponente = collision.gameObject.GetComponent<OponenteCore>();
                if (oponente != null)
                {
                    switch (tipo)
                    {
                        case "Temporal":
                            EfeitoTemporal();
                            break;
                        default:
                            break;
                    }

                }
            }
        }
        Destroy(gameObject);
    }

    void EfeitoTemporal()
    {
        oponente.Velocidade -= 0.01f;
    }
}