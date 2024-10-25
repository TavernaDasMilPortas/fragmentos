using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoDetalhes : MonoBehaviour
{
    public int valorDano;
    // Start is called before the first frame update
    void Start()
    {
        valorDano = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o objeto com o qual colidiu é o jogador
        if (collision.CompareTag("Momo"))
        {
            LifeControl vida = collision.gameObject.GetComponent<LifeControl>();
            if (vida.vidaMax != 0)
            {
                // Recupera a vida do jogador
                vida.SofrerDano(valorDano);
            }

            // Destroi o objeto atual
            Destroy(gameObject);
        }
    }
}
