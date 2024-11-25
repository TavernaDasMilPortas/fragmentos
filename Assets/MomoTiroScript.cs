using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomoTiroScript : MonoBehaviour, Iinteragivel
{
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
    // M�todo para disparar o evento de fus�o
    public void FundirPersonagens()
    {
        // Cria o clar�o
        flashEffect.TriggerFlash();

        // Ap�s o clar�o, desativa a sprite da NPC (ou destr�i o objeto)
        StartCoroutine(DesaparecerNPC());
    }

    private IEnumerator DesaparecerNPC()
    {

            yield return new WaitForSeconds(flashEffect.flashDuration / 2); // Espera o clar�o terminar
            npcSpriteRenderer.enabled = false;
            yield return new WaitForSeconds(flashEffect.flashDuration);
       
       // Exemplo de esconder a NPC
    }

}