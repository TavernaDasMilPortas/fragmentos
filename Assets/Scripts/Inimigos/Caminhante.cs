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
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        this.Vida.vidaMax = 10;
        this.Vida.vidaAtual = this.Vida.vidaMax;
        this.Vida.vidaAnterior = this.Vida.vidaMax;
        this.Velocidade = 2f;
        this.DistanciaMinima = 1.2f;
        this.RaioVisao = 5f;
        this.TempoFoco = 3f;
 
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vida.ConferirMudancaVida(Vida.vidaAtual, Vida.vidaAnterior) == true)
        {
            agro.AtivarAgro();
            Debug.Log("Mudança de vida detectada. Ativando Agro.");
        }
        else
        {
            Debug.Log("Mudança de vida nao dectectada");
        }
        if (agro.tempoRestanteFoco <= 0)
        {
            Alvo = procurar.ProcurarAlvo();
        }
        if (Alvo == null)
        {
            patrulhar.PatrulharArea();
        }
        else
        {
            perseguir.PerseguirAlvo();
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
}
