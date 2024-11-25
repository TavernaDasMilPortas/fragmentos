using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [Header("UI Components")]
    public GameObject dialoguePanel; // Painel de diálogo na UI
    public TextMeshProUGUI dialogueText; // Texto do diálogo
    public Image iconA; // Ícone do personagem A
    public Image iconB; // Ícone do personagem B
    public Image iconC; // Ícone do personagem A
    public Image iconD;
    [Header("Dialogue Data")]
    public DialogueLine[] dialogueLines; // Linhas de diálogo com metadados
    private int index = 0; // Índice da linha atual

    [Header("Typing Settings")]
    public float wordSpeed = 0.05f; // Velocidade de digitação
    private bool isDialogueActive = false; // Indica se o diálogo está ativo
    private bool isTyping = false; // Indica se a digitação está em andamento
    public bool isEnded = false; // Indica se o diálogo terminou
    private Coroutine typingCoroutine; // Referência para a Coroutine de digitação

    [Header("Interaction Settings")]
    public bool requiresInteraction = true; // Determina se o diálogo precisa de interação para começar

    void Start()
    {
        dialogueText.text = "";
        dialoguePanel.SetActive(false); // Garante que o painel comece desativado
        iconA.gameObject.SetActive(false); // Ícones começam desativados
        iconB.gameObject.SetActive(false);
        iconC.gameObject.SetActive(false);
        iconD.gameObject.SetActive(false);
    }

    /// <summary>
    /// Método chamado por um script externo para gerenciar a interação.
    /// </summary>
    public void Interact()
    {
        if (!isDialogueActive)
        {
            // Inicia o diálogo apenas se estiver configurado para interação
            if (requiresInteraction)
            {
                StartDialogue();
            }
        }
        else if (isTyping)
        {
            // Completa a linha atual instantaneamente se a digitação estiver em andamento
            CompleteCurrentLine();
        }
        else if (dialogueText.text == dialogueLines[index].text)
        {
            // Avança para a próxima linha se a digitação atual estiver completa
            NextLine();
        }
    }

    /// <summary>
    /// Método chamado por código para iniciar o diálogo diretamente, sem interação.
    /// </summary>
    public void StartDialogueByCode()
    {
        requiresInteraction = false; // Desativa a necessidade de interação
        StartDialogue();
    }

    /// <summary>
    /// Inicia o diálogo.
    /// </summary>
    private void StartDialogue()
    {
        index = 0; // Reseta o índice
        dialogueText.text = ""; // Limpa o texto
        dialoguePanel.SetActive(true); // Ativa o painel de diálogo
        isDialogueActive = true;
        isEnded = false; // Marca que o diálogo está ativo
        UpdateSpeakerVisual(dialogueLines[index]); // Mostra o ícone e sprite do primeiro speaker
        typingCoroutine = StartCoroutine(Typing());
    }

    /// <summary>
    /// Exibe a próxima linha do diálogo ou encerra o diálogo se for a última linha.
    /// </summary>
    private void NextLine()
    {
        if (index < dialogueLines.Length - 1)
        {
            index++; // Avança para a próxima linha
            dialogueText.text = ""; // Limpa o texto para a nova linha
            UpdateSpeakerVisual(dialogueLines[index]); // Atualiza o ícone e sprite do speaker
            typingCoroutine = StartCoroutine(Typing()); // Inicia a digitação da próxima linha

            // Após a primeira linha, muda para interação manual, se necessário
            if (!requiresInteraction && index == 1)
            {
                requiresInteraction = true;
            }
        }
        else
        {
            isEnded = true;
            EndDialogue(); // Encerra o diálogo se for a última linha
        }
    }

    /// <summary>
    /// Encerra o diálogo.
    /// </summary>
    private void EndDialogue()
    {
        dialogueText.text = ""; // Limpa o texto
        dialoguePanel.SetActive(false); // Desativa o painel de diálogo
        iconA.gameObject.SetActive(false); // Desativa os ícones
        iconB.gameObject.SetActive(false);
        iconC.gameObject.SetActive(false);
        iconD.gameObject.SetActive(false);
        isDialogueActive = false; // Marca que o diálogo não está ativo
    }

    /// <summary>
    /// Digita a linha de diálogo atual letra por letra.
    /// </summary>
    private IEnumerator Typing()
    {
        isTyping = true; // Indica que a digitação começou

        foreach (char letter in dialogueLines[index].text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }

        isTyping = false; // Indica que a digitação terminou
    }

    /// <summary>
    /// Completa instantaneamente a linha de diálogo atual.
    /// </summary>
    private void CompleteCurrentLine()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine); // Interrompe a digitação em andamento
        }

        dialogueText.text = dialogueLines[index].text; // Exibe toda a linha atual instantaneamente
        isTyping = false; // Marca que a digitação terminou
    }

    /// <summary>
    /// Atualiza o ícone e a sprite do personagem que está falando.
    /// </summary>
    private void UpdateSpeakerVisual(DialogueLine dialogueLine)
    {
        // Desativa ambos os ícones primeiro
        iconA.gameObject.SetActive(false);
        iconB.gameObject.SetActive(false);
        iconC.gameObject.SetActive(false);
        iconD.gameObject.SetActive(false);
        // Atualiza o ícone e a sprite com base no speaker atual
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
    public string text; // Texto da linha de diálogo
    public Speaker speaker; // Personagem que está falando
    public Sprite speakerSprite; // Sprite para a linha de diálogo
}

public enum Speaker
{
    A, // Representa o personagem A
    B,
    C,
    D// Representa o personagem B
}