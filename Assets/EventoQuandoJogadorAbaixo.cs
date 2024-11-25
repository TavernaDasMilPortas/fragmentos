using UnityEngine;

public class EventoQuandoJogadorAbaixo : MonoBehaviour
{
    [Header("Configura��o")]
    [SerializeField] private Transform jogador; // Refer�ncia ao jogador configurada pelo Inspector
    [SerializeField] private GameObject C1;
    [SerializeField] private GameObject C2;
    [SerializeField] private GameObject C3;
    [SerializeField] private GameObject C4;
    [SerializeField] private SubBossBlink SB;

    private bool eventoAtivado = false; // Controla se o evento j� foi ativado

    private void Update()
    {
        // Verifica se o jogador est� abaixo deste objeto e o evento ainda n�o foi ativado
        if (!eventoAtivado && jogador != null && jogador.position.y < transform.position.y)
        {
            AtivarEvento();
            eventoAtivado = true; // Marca o evento como ativado para evitar execu��es repetidas
        }
    }

    private void AtivarEvento()
    {
        // Ativa os objetos e inicia a luta
        if (SB != null)
            SB.iniciarLuta = true;

        if (C1 != null)
            C1.SetActive(true);

        if (C2 != null)
            C2.SetActive(true);

        if (C3 != null)
            C3.SetActive(true);

        if (C4 != null)
            C4.SetActive(true);

        Debug.Log("Iniciando bossFight");
    }
}