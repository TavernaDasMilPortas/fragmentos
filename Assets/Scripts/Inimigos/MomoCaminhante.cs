using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MomoCaminhante : OponenteCore
{
    [SerializeField] private Agro agro;
    [SerializeField] private Patrulhar patrulhar;
    [SerializeField] private Perseguir perseguir;
    [SerializeField] private Procurar procurar;
    [SerializeField] private DisparoOponente disparar;
    [SerializeField] public ValorDano dano;
    // Start is called before the first frame update
    void Start()
    {
        this.Vida.vidaMax = 10;
        this.Vida.vidaAtual = this.Vida.vidaMax;
        this.Vida.vidaAnterior = this.Vida.vidaMax;
        this.Velocidade = 2.1f;
        this.DistanciaMinima = 5f;
        this.RaioVisao = 10f;
        this.TempoFoco = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        Alvo = procurar.ProcurarAlvo();
        if (Vida.ConferirMudancaVida(Vida.vidaAtual, Vida.vidaAnterior) == true)
        {
            agro.AtivarAgro();
        }
        if (Alvo == null)
        {
            patrulhar.PatrulharArea();
        }
        else
        {
            disparar.Disparar(dano.valorDano, DisparoProjetil.TipoProjetil.Fisico);
            
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, this.RaioVisao);
        if (this.Alvo != null)
        {
            Gizmos.DrawLine(this.transform.position, this.Alvo.position);
        }
    }


    public void Atacar()
    {


    }
}
