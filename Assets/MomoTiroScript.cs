using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomoTiroScript : MonoBehaviour, Iinteragivel

{
    [SerializeField] private Sprite[] _spritesSelecionaveis = null; // Exposto no Inspector
    [SerializeField] private int _indiceSprite = 0; // Exposto no Inspector
    [SerializeField] private Sprite _spritePadrao= null; // Armazena o sprite original do objeto

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
    [SerializeField] Dialogue dialogo1;
    [SerializeField] Dialogue dialogo2;
    [SerializeField] private FlashEffect flashEffect;
    [SerializeField] private PLayer player;
    [SerializeField] private GameObject circulo;
    [SerializeField] private DisparoProjetil disparar;
    [SerializeField] private SpriteRenderer npcSpriteRenderer;
    [SerializeField] private EventosFase1 eventos;
    private bool interacao1Travada = false;
    public void Interagir()
    {
        if (!interacao1Travada)
        {
            dialogo1.Interact();
        }
       
        if (dialogo1.isEnded && !interacao1Travada)
        {
            interacao1Travada = true;
            FundirPersonagens();
            player.fragmentoAtual.VA = true;
            circulo.SetActive(true);
            disparar.enabled = true;
            DesaparecerNPC();
 
        }
        if (interacao1Travada)
        {
            dialogo2.Interact();
        }
        if (dialogo2.isEnded) 
        {
            eventos.AtivarCaminhantes();
            Destroy(this.gameObject);
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