using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Caminhante : OponenteCore
{
    [SerializeField] private Agro agro;
    [SerializeField] private Patrulhar patrulhar;
    [SerializeField] private Perseguir perseguir;
    [SerializeField] private Procurar procurar;
    [SerializeField] private AtaqueMelle atacar;
    public int danoAtaqueMelle;
    // Start is called before the first frame update
    void Start()
    {
        this.Vida.vidaMax = 5;
        this.Vida.vidaAtual = this.Vida.vidaMax;
        this.Vida.vidaAnterior = this.Vida.vidaMax;
        this.Velocidade = 2.1f;
        this.DistanciaMinima = 1.5f;
        this.RaioVisao = 3f;
        this.TempoFoco = 3f;
        danoAtaqueMelle = 2;

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
            perseguir.PerseguirAlvo();
            atacar.VerificarPossibilidadeAtaque(Alvo);
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
