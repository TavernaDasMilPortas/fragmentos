using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomoTiroScript : MonoBehaviour, Iinteragivel

{
    [SerializeField] private string tipoInteracao = "Abrir Porta"; // Texto que descreve a interação

    [Header("Configurações de Ponto de Prefab")]
    [SerializeField] private Transform[] pontosPrefab; // Pontos para o spawn do prefab de indicação
    [SerializeField] private bool estaMaisProximo = false; // Indica se este objeto é o mais próximo do jogador
    private bool estaInteragindo = false;
    // Implementação das propriedades da interface
    public bool EstaInteragindo
    {
        get => estaInteragindo;
        set
        {
            estaInteragindo = value;
        }
    }
    // Implementação das propriedades da interface
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
        set => pontosPrefab = value; // Caso necessário permitir redefinir os pontos externamente
    }

    public string TipoInteracao
    {
        get => tipoInteracao;
        set
        {
            tipoInteracao = value;
        }
    }
    [SerializeField] Dialogue dialogo1;
    [SerializeField] public Dialogue dialogo2;
    [SerializeField] private FlashEffect flashEffect;
    [SerializeField] private PLayer player;
    [SerializeField] private GameObject circulo;
    [SerializeField] private DisparoProjetil disparar;
    [SerializeField] private SpriteRenderer npcSpriteRenderer;

    private bool interacao1Travada = false;
    private void Update()
    {
        if (dialogo2.isEnded)
        {
            Destroy(this.gameObject);
        }
    }
    public void Interagir()
    {
        if (!dialogo1.EstaInteragindo && !dialogo2.EstaInteragindo)
        {
            if (!dialogo1.isEnded)
            {
                dialogo1.EstaInteragindo = true;
            }
            if (dialogo1.isEnded)
            {
                interacao1Travada = true;
                FundirPersonagens();
                player.fragmentoAtual.VA = true;
                circulo.SetActive(true);
                disparar.enabled = true;
                DesaparecerNPC();
                dialogo2.EstaInteragindo = true;
            }

        }
    }
    // Método para disparar o evento de fusão
    public void FundirPersonagens()
    {
        // Cria o clarão
        flashEffect.TriggerFlash();

        // Após o clarão, desativa a sprite da NPC (ou destrói o objeto)
        StartCoroutine(DesaparecerNPC());
    }

    private IEnumerator DesaparecerNPC()
    {

            yield return new WaitForSeconds(flashEffect.flashDuration / 2); // Espera o clarão terminar
            npcSpriteRenderer.enabled = false;
            yield return new WaitForSeconds(flashEffect.flashDuration);
       
       // Exemplo de esconder a NPC
    }

}