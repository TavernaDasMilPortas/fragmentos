using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissaoDerrotarInimigos : Missao
{
    [Header("Referências")]
    [SerializeField] private VerificarVidaOponentes verificarVidaOponentes;

    // Configuração inicial da missão
    public override void ConfigurarMissao(int valorTotal)
    {
        base.ConfigurarMissao(valorTotal);
        textoPrincipal = "Derrote todos os inimigos";
    }

    private void Update()
    {
        // Atualiza o progresso sempre que a condição de todos os inimigos mortos for atendida
        AtualizarProgresso();
    }

    // Método responsável por atualizar o progresso da missão
    public override void AtualizarProgresso()
    {
        // Aqui você atualiza o valorAtual com base no progresso da missão.
        // Exemplo: Se for uma missão de derrotar inimigos
        valorAtual = verificarVidaOponentes.GetQuantidadeOponentesDerrotados();
        valorTotal = verificarVidaOponentes.oponentes.Count;
        // Atualize a UI após modificar o valorAtual
        AtualizarTextoUI();
    }
}
