using UnityEngine;

public class Porta : MonoBehaviour, Iinteragivel
{

    [SerializeField] private Sprite[] _spritesSelecionaveis; // Exposto no Inspector
    [SerializeField] private int _indiceSprite = 0; // Exposto no Inspector
    [SerializeField] private Sprite _spritePadrao; // Armazena o sprite original do objeto

    public Sprite[] spritesSelecionaveis
    {
        get => _spritesSelecionaveis;
        set => _spritesSelecionaveis = value;
    }

    public int indiceSprite
    {
        get => _indiceSprite;
        set => _indiceSprite = value;
    }

    public Sprite SpritePadrao
    {
        get => _spritePadrao;
        set => _spritePadrao = value;
    }
    [SerializeField] private Collider2D colisor; // O colisor da porta (box ou qualquer outro tipo)
    [SerializeField] private SpriteRenderer spriteRenderer; // Para alternar entre sprites de porta aberta/fechada
    [SerializeField] private Sprite spriteFechada; // Sprite quando a porta está fechada
    [SerializeField] private Sprite spriteAberta; // Sprite quando a porta está aberta
    [SerializeField] private ItemCore itemData;
    [SerializeField] private Inventory inventario;
    [SerializeField] private VerificarVidaOponentes verificar;
    [SerializeField] private AudioSource portaNormal;
    [SerializeField] private AudioSource portaTrancada;
    private bool estaAberta = false; // Indica o estado atual da porta

    public void Interagir()
    {
        if (itemData == null)
        {
            if (verificar.todosMortos)
            {
                AtualizarEstado();
                portaNormal.Play();
            }
 
        }
        else
        {
            InventorySlot chave = inventario.EncontrarItemPorNome(itemData);
            if (chave == null)
            {
                Debug.Log("A chave ainda não foi coletada");
                portaTrancada.Play();
            }
            else
            {
                AtualizarEstado();
            }
        }
    }

    private void AtualizarEstado()
    {
        estaAberta = !estaAberta;
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
