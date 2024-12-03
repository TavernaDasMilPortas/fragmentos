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
    [SerializeField] Interagir interagir;
    [SerializeField] ControleRelogio relogio;
    [SerializeField] AudioSource blink;
    public bool vInteragir = true;
    void Start()
    {
        this.Vida.vidaMax = 12;
        this.Vida.vidaAtual = this.Vida.vidaMax;
        this.Vida.vidaAnterior = this.Vida.vidaMax;
        this.VelocidadeMovimento = 7f;
        this.DanoDisparo = 2;
        Andando = false;
        swManaCost = shockwavePrefab.manaCost;
        this.FragmentoAtual.IniciarFragmento();
        relogio.IniciarRelogios();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vida.ConferirMudancaVida(Vida.vidaAtual, Vida.vidaAnterior) == true)
        {
            relogio.ModificarRelogio();
        }
        andar.Deslocar();
 
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                FragmentoAtual.AtivarHabilidade1();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {

                if (vInteragir == true && interagir.objetoMaisProximo != null)
                {
                    interagir.DispararInteracao(interagir.objetoMaisProximo);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                blink.Play();
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

        // Instantiate the shockwave at the player's position (or a specific point)
    }
}


