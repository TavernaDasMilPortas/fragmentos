using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissaoDerrotarInimigos : Missao
{
    [Header("Refer�ncias")]
    [SerializeField] private VerificarVidaOponentes verificarVidaOponentes;

    // Configura��o inicial da miss�o
    public override void ConfigurarMissao(int valorTotal)
    {
        base.ConfigurarMissao(valorTotal);
        textoPrincipal = "Derrote todos os inimigos";
    }

    private void Update()
    {
        // Atualiza o progresso sempre que a condi��o de todos os inimigos mortos for atendida
        AtualizarProgresso();
    }

    // M�todo respons�vel por atualizar o progresso da miss�o
    public override void AtualizarProgresso()
    {
        // Aqui voc� atualiza o valorAtual com base no progresso da miss�o.
        // Exemplo: Se for uma miss�o de derrotar inimigos
        valorAtual = verificarVidaOponentes.GetQuantidadeOponentesDerrotados();
        valorTotal = verificarVidaOponentes.oponentes.Count;
        // Atualize a UI ap�s modificar o valorAtual
        AtualizarTextoUI();
    }
}
