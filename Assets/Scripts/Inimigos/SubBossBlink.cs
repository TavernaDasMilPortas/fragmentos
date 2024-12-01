using System.Collections;
using UnityEngine;

public class SubBossBlink : OponenteCore
{
    [SerializeField] private MovimentacaoLateral movimentacaoLateral;
    [SerializeField] private DisparoOponente disparar;
    [SerializeField] private ProcurarPonto procurarPonto;
    [SerializeField] private TiroCarregado tiroCarregado;

    [SerializeField] private int quantidadeMovimentos = 3;
    [SerializeField] private float intervaloEntreAcoes = 1f;
    [SerializeField] private float tempoEntreTeleportes = 1f;
    [SerializeField] private int maxTeleportes = 3;
    [SerializeField] private ValorDano dano;
    [SerializeField] Animator animador;  
    private int movimentosRealizados = 0;
    private bool realizandoMovimento = false;
    private bool realizandoDisparo = false;
    private bool realizandoTeleporte = false;
    private bool corrotinaEmExecucao = false;  // Vari�vel para controlar a execu��o de corrotinas
    private bool corrotinaFinalizada = true; // Flag para saber quando a corrotina foi finalizada
    public bool iniciarLuta = false;
    private void Start()
    {
        this.Vida.vidaMax = 20;
        this.Vida.vidaAtual = this.Vida.vidaMax;
        this.Vida.vidaAnterior = this.Vida.vidaMax;
        this.RaioVisao = 20f;
    }

    private void Update()
    {
        if (iniciarLuta)
        {
            if (corrotinaFinalizada && !corrotinaEmExecucao)
            {
                corrotinaFinalizada = false; // Resetando a flag
                StartCoroutine(ExecutarAcoesSubBoss()); // Reinicia a corrotina de a��es
            }
        }
        // Se a corrotina foi finalizada e n�o est� em execu��o, reinicia o ciclo

    }

    private IEnumerator ExecutarAcoesSubBoss()
    {
        if (corrotinaEmExecucao)
        {
            yield break; // Se j� houver uma corrotina em execu��o, sai sem fazer nada
        }

        corrotinaEmExecucao = true; // Marca a corrotina como em execu��o

        // Resetando estados
        movimentosRealizados = 0;
        realizandoMovimento = false;
        realizandoDisparo = false;
        realizandoTeleporte = false;

        while (movimentosRealizados < quantidadeMovimentos)
        {
            if (!realizandoMovimento)
            {
                realizandoMovimento = true;
                yield return StartCoroutine(movimentacaoLateral.MovimentarLateralmente());
                realizandoMovimento = false;

                // Limpa o destino do agente ap�s o movimento
                if (movimentacaoLateral.agente != null)
                {
                    movimentacaoLateral.agente.ResetPath();
                }
            }

            yield return new WaitForSeconds(intervaloEntreAcoes);

            if (!realizandoDisparo)
            {
                animador.SetBool("Atacando", true);
                yield return new WaitForSeconds(0.5f);
                disparar.Disparar(dano.valorDano, DisparoProjetil.TipoProjetil.Fisico);
                realizandoDisparo = true;
            }
            else
            {
                // Garante que o disparo n�o seja perdido se o estado de disparo n�o foi resetado corretamente
                animador.SetBool("Atacando", true);
                yield return new WaitForSeconds(0.5f);
                disparar.Disparar(dano.valorDano, DisparoProjetil.TipoProjetil.Fisico);
            }
            
            yield return new WaitForSeconds(intervaloEntreAcoes);
            animador.SetBool("Atacando", false);
            movimentosRealizados++;
        }

        // Inicia o teleporte apenas se n�o houver teleporte em andamento
        if (!realizandoTeleporte)
        {
            realizandoTeleporte = true;
            procurarPonto.IniciarTeleporte();
            while (procurarPonto.Teleportando)
            {
                yield return null; // Espera o teleporte terminar
            }
            realizandoTeleporte = false;
        }
        animador.SetBool("CarregandoAtaque", true);
        yield return new WaitForSeconds(2f);
        animador.SetBool("CarregandoAtaque", false);
        tiroCarregado.RealizarTiroCarregado();
        yield return new WaitForSeconds(4f);
        corrotinaEmExecucao = false; // Marca a corrotina como finalizada
        corrotinaFinalizada = true;

    }


    public void DispararPreciso() 
    {


    }
}