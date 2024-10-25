using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaDetalhes : MonoBehaviour
{
    
    public int valorRecuperacao;
    // Start is called before the first frame update
    void Start()
    {
        valorRecuperacao = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o objeto com o qual colidiu � o jogador
        if (collision.CompareTag("Momo"))
        {
            LifeControl vida = collision.gameObject.GetComponent<LifeControl>();
            if (vida.vidaMax!= 0)
            {
                // Recupera a vida do jogador
                vida.RecuperarVida(valorRecuperacao);
            }

            // Destroi o objeto atual
            Destroy(gameObject);
        }
    }
}