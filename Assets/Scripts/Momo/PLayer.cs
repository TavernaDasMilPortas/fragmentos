using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer : PlayerCore
{
    // Start is called before the first frame update

    public Shockwave shockwavePrefab;
    public int swManaCost;
    [SerializeField] Andar andar;
    [SerializeField] DisparoProjetil disparar;
    void Start()
    {
        this.Vida.vidaMax = 10;
        this.Vida.vidaAtual = this.Vida.vidaMax;
        this.VelocidadeMovimento = 2f;
        Andando = false;
        swManaCost = shockwavePrefab.manaCost;
        this.FragmentoAtual.IniciarFragmento();
    }

    // Update is called once per frame
    void Update()
    {
        andar.Deslocar();
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                FragmentoAtual.AtivarHabilidade1();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                //Interagir com ambiente
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                FragmentoAtual.AtivarHabilidade2();
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                FragmentoAtual.Disparar();
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                FragmentoAtual.AtivarHabilidade3();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SpawnShockwave();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1.4f);
    }

    void SpawnShockwave()
    {
        if (Mana.manaAtual - swManaCost >= 0)
        {
            Shockwave shockWave = Instantiate(shockwavePrefab, this.transform.position, Quaternion.identity);
            Mana.GastarMana(shockWave.manaCost);
        }
        // Instantiate the shockwave at the player's position (or a specific point)
    }
}


