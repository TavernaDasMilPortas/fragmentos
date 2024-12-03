using UnityEngine;

public class Porta : MonoBehaviour, Iinteragivel
{
    [SerializeField] private string tipoInteracao = "Abrir Porta"; // Texto que descreve a intera��o

    [Header("Configura��es de Ponto de Prefab")]
    [SerializeField] private Transform[] pontosPrefab; // Pontos para o spawn do prefab de indica��o
    [SerializeField] private bool estaMaisProximo = false; // Indica se este objeto � o mais pr�ximo do jogador
    private bool estaInteragindo = false;
    // Implementa��o das propriedades da interface
    public bool EstaInteragindo
    {
        get => estaInteragindo;
        set
        {
            estaInteragindo = value;
        }
    }
    // Implementa��o das propriedades da interface
    public bool EstaMaisProximo
    {
        get => estaMaisProximo;
        set
        {
            estaMaisProximo = value;
        }
    }

    public Transform[] PontosPrebab
    {
        get => pontosPrefab;
        set => pontosPrefab = value; // Caso necess�rio permitir redefinir os pontos externamente
    }

    public string TipoInteracao
    {
        get => tipoInteracao;
        set
        {
            tipoInteracao = value;
        }
    }

    [SerializeField] private Collider2D colisor; // O colisor da porta (box ou qualquer outro tipo)
    [SerializeField] private SpriteRenderer spriteRenderer; // Para alternar entre sprites de porta aberta/fechada
    [SerializeField] private Sprite spriteFechada; // Sprite quando a porta est� fechada
    [SerializeField] private Sprite spriteAberta; // Sprite quando a porta est� aberta
    [SerializeField] private ItemCore itemData;
    [SerializeField] private Inventory inventario;
    [SerializeField] private VerificarVidaOponentes verificar;
    [SerializeField] private AudioSource portaNormal;
    [SerializeField] private AudioSource portaTrancada;

    private bool estaAberta = false; // Indica o estado atual da porta
    private bool personagemDentro = false; // Para verificar se o personagem est� dentro da porta

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
                Debug.Log("A chave ainda n�o foi coletada");
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
        if (!personagemDentro)
        {
            estaAberta = !estaAberta;
            if (estaAberta)
            {
                colisor.isTrigger = true; // Desativa o colisor, permitindo passagem
                spriteRenderer.sprite = spriteAberta; // Altera para o sprite da porta aberta
                AtualizarAlpha(1); // Garante que a porta esteja vis�vel
            }
            else
            {
                colisor.isTrigger = false; // Ativa o colisor, bloqueando passagem
                spriteRenderer.sprite = spriteFechada; // Altera para o sprite da porta fechada
                AtualizarAlpha(1); // Torna a porta vis�vel novamente quando fechada
            }
        }

    }

    private void AtualizarAlpha(float alpha)
    {
        Color cor = spriteRenderer.color;
        cor.a = alpha;
        spriteRenderer.color = cor;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && estaAberta)
        {
            personagemDentro = true;
            AtualizarAlpha(0.8f); // Torna a porta invis�vel quando o personagem passa por ela
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && estaAberta)
        {
            personagemDentro = true;
            AtualizarAlpha(0.8f); // Torna a porta invis�vel quando o personagem passa por ela
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && estaAberta)
        {
            personagemDentro = false;
            AtualizarAlpha(1); // Restaura a visibilidade da porta quando o personagem sai
        }
    }
 
}