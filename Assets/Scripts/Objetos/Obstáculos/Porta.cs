using UnityEngine;

public class Porta : MonoBehaviour, Iinteragivel
{
    [SerializeField] private Collider2D colisor; // O colisor da porta (box ou qualquer outro tipo)
    [SerializeField] private SpriteRenderer spriteRenderer; // Para alternar entre sprites de porta aberta/fechada
    [SerializeField] private Sprite spriteFechada; // Sprite quando a porta está fechada
    [SerializeField] private Sprite spriteAberta; // Sprite quando a porta está aberta
    private bool estaAberta = false; // Indica o estado atual da porta

    private void Start()
    {
        AtualizarEstado(); // Define o estado inicial da porta
    }

    public void Interagir()
    {
        estaAberta = !estaAberta; // Alterna o estado da porta
        AtualizarEstado(); // Atualiza visualmente e funcionalmente
    }

    private void AtualizarEstado()
    {
        if (estaAberta)
        {
            colisor.isTrigger = true; // Desativa o colisor, permitindo passagem
            spriteRenderer.sprite = spriteAberta; // Altera para o sprite da porta aberta
        }
        else
        {
            colisor.isTrigger = false; // Ativa o colisor, bloqueando passagem
            spriteRenderer.sprite = spriteFechada; // Altera para o sprite da porta fechada
        }
    }
}
