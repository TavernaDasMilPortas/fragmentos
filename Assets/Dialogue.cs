using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [Header("UI Components")]
    public GameObject dialoguePanel; // Painel de di�logo na UI
    public TextMeshProUGUI dialogueText; // Texto do di�logo
    public Image iconA; // �cone do personagem A
    public Image iconB; // �cone do personagem B
    public Image iconC; // �cone do personagem A
    public Image iconD;
    [Header("Dialogue Data")]
    public DialogueLine[] dialogueLines; // Linhas de di�logo com metadados
    private int index = 0; // �ndice da linha atual

    [Header("Typing Settings")]
    public float wordSpeed = 0.05f; // Velocidade de digita��o
    private bool isDialogueActive = false; // Indica se o di�logo est� ativo
    private bool isTyping = false; // Indica se a digita��o est� em andamento
    public bool isEnded = false; // Indica se o di�logo terminou
    private Coroutine typingCoroutine; // Refer�ncia para a Coroutine de digita��o

    [Header("Interaction Settings")]
    public bool requiresInteraction = true; // Determina se o di�logo precisa de intera��o para come�ar

    void Start()
    {
        dialogueText.text = "";
        dialoguePanel.SetActive(false); // Garante que o painel comece desativado
        iconA.gameObject.SetActive(false); // �cones come�am desativados
        iconB.gameObject.SetActive(false);
        iconC.gameObject.SetActive(false);
        iconD.gameObject.SetActive(false);
    }

    /// <summary>
    /// M�todo chamado por um script externo para gerenciar a intera��o.
    /// </summary>
    public void Interact()
    {
        if (!isDialogueActive)
        {
            // Inicia o di�logo apenas se estiver configurado para intera��o
            if (requiresInteraction)
            {
                StartDialogue();
            }
        }
        else if (isTyping)
        {
            // Completa a linha atual instantaneamente se a digita��o estiver em andamento
            CompleteCurrentLine();
        }
        else if (dialogueText.text == dialogueLines[index].text)
        {
            // Avan�a para a pr�xima linha se a digita��o atual estiver completa
            NextLine();
        }
    }

    /// <summary>
    /// M�todo chamado por c�digo para iniciar o di�logo diretamente, sem intera��o.
    /// </summary>
    public void StartDialogueByCode()
    {
        requiresInteraction = false; // Desativa a necessidade de intera��o
        StartDialogue();
    }

    /// <summary>
    /// Inicia o di�logo.
    /// </summary>
    private void StartDialogue()
    {
        index = 0; // Reseta o �ndice
        dialogueText.text = ""; // Limpa o texto
        dialoguePanel.SetActive(true); // Ativa o painel de di�logo
        isDialogueActive = true;
        isEnded = false; // Marca que o di�logo est� ativo
        UpdateSpeakerVisual(dialogueLines[index]); // Mostra o �cone e sprite do primeiro speaker
        typingCoroutine = StartCoroutine(Typing());
    }

    /// <summary>
    /// Exibe a pr�xima linha do di�logo ou encerra o di�logo se for a �ltima linha.
    /// </summary>
    private void NextLine()
    {
        if (index < dialogueLines.Length - 1)
        {
            index++; // Avan�a para a pr�xima linha
            dialogueText.text = ""; // Limpa o texto para a nova linha
            UpdateSpeakerVisual(dialogueLines[index]); // Atualiza o �cone e sprite do speaker
            typingCoroutine = StartCoroutine(Typing()); // Inicia a digita��o da pr�xima linha

            // Ap�s a primeira linha, muda para intera��o manual, se necess�rio
            if (!requiresInteraction && index == 1)
            {
                requiresInteraction = true;
            }
        }
        else
        {
            isEnded = true;
            EndDialogue(); // Encerra o di�logo se for a �ltima linha
        }
    }

    /// <summary>
    /// Encerra o di�logo.
    /// </summary>
    private void EndDialogue()
    {
        dialogueText.text = ""; // Limpa o texto
        dialoguePanel.SetActive(false); // Desativa o painel de di�logo
        iconA.gameObject.SetActive(false); // Desativa os �cones
        iconB.gameObject.SetActive(false);
        iconC.gameObject.SetActive(false);
        iconD.gameObject.SetActive(false);
        isDialogueActive = false; // Marca que o di�logo n�o est� ativo
    }

    /// <summary>
    /// Digita a linha de di�logo atual letra por letra.
    /// </summary>
    private IEnumerator Typing()
    {
        isTyping = true; // Indica que a digita��o come�ou

        foreach (char letter in dialogueLines[index].text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }

        isTyping = false; // Indica que a digita��o terminou
    }

    /// <summary>
    /// Completa instantaneamente a linha de di�logo atual.
    /// </summary>
    private void CompleteCurrentLine()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine); // Interrompe a digita��o em andamento
        }

        dialogueText.text = dialogueLines[index].text; // Exibe toda a linha atual instantaneamente
        isTyping = false; // Marca que a digita��o terminou
    }

    /// <summary>
    /// Atualiza o �cone e a sprite do personagem que est� falando.
    /// </summary>
    private void UpdateSpeakerVisual(DialogueLine dialogueLine)
    {
        // Desativa ambos os �cones primeiro
        iconA.gameObject.SetActive(false);
        iconB.gameObject.SetActive(false);
        iconC.gameObject.SetActive(false);
        iconD.gameObject.SetActive(false);
        // Atualiza o �cone e a sprite com base no speaker atual
        if (dialogueLine.speaker == Speaker.A)
        {
            iconA.gameObject.SetActive(true);
            iconA.sprite = dialogueLine.speakerSprite;
        }
        else if (dialogueLine.speaker == Speaker.B)
        {
            iconB.gameObject.SetActive(true);
            iconB.sprite = dialogueLine.speakerSprite;
        }
        else if (dialogueLine.speaker == Speaker.C)
        {
            iconC.gameObject.SetActive(true);
            iconC.sprite = dialogueLine.speakerSprite;
        }
        else if (dialogueLine.speaker == Speaker.D)
        {
            iconD.gameObject.SetActive(true);
            iconD.sprite = dialogueLine.speakerSprite;
        }
    }
}

[System.Serializable]
public class DialogueLine
{
    public string text; // Texto da linha de di�logo
    public Speaker speaker; // Personagem que est� falando
    public Sprite speakerSprite; // Sprite para a linha de di�logo
}

public enum Speaker
{
    A, // Representa o personagem A
    B,
    C,
    D// Representa o personagem B
}