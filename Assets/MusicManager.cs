using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicaAmbiente;
    [SerializeField] private AudioSource musicaCombate;

    [Header("Configuração de Transição")]
    [SerializeField] private float tempoParaVoltarAmbiente = 3f; // Tempo após sair do combate para voltar à música de ambiente
    [SerializeField] private float fadeDuration = 3f; // Duração do fade-in e fade-out

    [Header("Configuração de Detecção")]
    [SerializeField] private Transform centroDeteccao; // Transform para centralizar o OverlapCircle
    [SerializeField] private float raioDeteccao = 5f; // Raio do OverlapCircle
    [SerializeField] private LayerMask camadaOponentes; // Layer para filtrar os oponentes

    private bool emCombate = false; // Flag para indicar se o jogador está em combate
    private Coroutine transicaoParaAmbiente;
    private float tempoSemDetectarOponente = 0f; // Tempo desde a última detecção de oponente

    private void Start()
    {
        // Configura os volumes iniciais
        musicaAmbiente.volume = 0.3f;
        musicaCombate.volume = 0f;
        musicaAmbiente.Play();
        musicaCombate.Play(); // Toca ambas, mas o volume inicial da música de combate é zero
    }

    private void Update()
    {
        // Verifica se há oponentes no OverlapCircle
        Collider2D[] oponentesDetectados = Physics2D.OverlapCircleAll(centroDeteccao.position, raioDeteccao, camadaOponentes);

        if (oponentesDetectados.Length > 0)
        {
            EntrarEmCombate();
            tempoSemDetectarOponente = 0f; // Reseta o contador de tempo sem detectar oponentes
        }
        else if (emCombate)
        {
            tempoSemDetectarOponente += Time.deltaTime;

            // Sai do combate se o tempo sem detectar oponentes exceder o limite configurado
            if (tempoSemDetectarOponente >= tempoParaVoltarAmbiente)
            {
                SairDeCombate();
            }
        }
    }

    public void EntrarEmCombate()
    {
        if (!emCombate)
        {
            emCombate = true;
            if (transicaoParaAmbiente != null)
            {
                StopCoroutine(transicaoParaAmbiente);
            }
            StartCoroutine(FadeMusicas(musicaAmbiente, musicaCombate));
        }
    }

    public void SairDeCombate()
    {
        if (emCombate)
        {
            emCombate = false;
            if (transicaoParaAmbiente != null)
            {
                StopCoroutine(transicaoParaAmbiente);
            }
            transicaoParaAmbiente = StartCoroutine(FadeMusicas(musicaCombate, musicaAmbiente));
        }
    }

    private IEnumerator FadeMusicas(AudioSource sair, AudioSource entrar)
    {
        float tempo = 0f;

        // Garantir que ambas as músicas estejam tocando
        if (!entrar.isPlaying) entrar.Play();

        float volumeInicialSair = sair.volume;
        float volumeInicialEntrar = entrar.volume;

        while (tempo < fadeDuration)
        {
            tempo += Time.deltaTime;
            float proporcao = tempo / fadeDuration;

            sair.volume = Mathf.Lerp(volumeInicialSair, 0f, proporcao);
            entrar.volume = Mathf.Lerp(volumeInicialEntrar, 0.3f, proporcao);

            yield return null;
        }

        // Garantir que os volumes finais sejam definidos corretamente
        sair.volume = 0f;
        entrar.volume = 0.3f;

        // Opcional: Parar a música que está saindo para poupar recursos
        if (sair.volume == 0f) sair.Stop();
    }

    private void OnDrawGizmosSelected()
    {
        // Visualiza o OverlapCircle no Editor
        if (centroDeteccao != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(centroDeteccao.position, raioDeteccao);
        }
    }
}
