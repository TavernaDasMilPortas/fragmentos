using UnityEngine;

public class DisparoOponente : MonoBehaviour
{
    [SerializeField] private GameObject prefabProjetil; // Prefab do projétil
    [SerializeField] private Transform pontoDeDisparo;  // Ponto de origem do disparo
    [SerializeField] private float velocidadeProjetil = 10f; // Velocidade do projétil
    [SerializeField] private float intervaloEntreDisparos = 2f; // Intervalo entre disparos
    [SerializeField] private float tempoDeDestruicao = 3f; // Tempo para destruir o projétil
    [SerializeField] private OponenteCore Core;
    [SerializeField] private Collider2D Hurtbox; // Referência ao jogador
    private float proximoDisparo; // Tempo para o próximo disparo
    private bool podeDisparar = true;
    [SerializeField] Animator animator; 

    private void Update()
    {
        if (Core.Alvo == null) return; // Não faz nada se o jogador não foi encontrado

        // Verifica se é hora de disparar
        if (Time.time >= proximoDisparo)
        {
            podeDisparar = true;
            proximoDisparo = Time.time + intervaloEntreDisparos;
        }
    }

    public void Disparar(int dano, DisparoProjetil.TipoProjetil tipo)
    {
        if (podeDisparar)
        {
            if (animator!= null)
            {
                animator.SetBool("Atacar",true);
            }
            podeDisparar = false;
            GameObject projetil = Instantiate(prefabProjetil, pontoDeDisparo.position, pontoDeDisparo.rotation, null);
            Projetil scriptProjetil = projetil.GetComponent<Projetil>();
            if (scriptProjetil != null)
            {
                Vector2 direcao = (Core.Alvo.position - pontoDeDisparo.position).normalized;
                Rigidbody2D rb = projetil.GetComponent<Rigidbody2D>();
                scriptProjetil.Inicializar(dano, tipo.ToString(), Hurtbox, this.transform.root);

                if (rb != null)
                {
                    rb.velocity = direcao * velocidadeProjetil;
                }

                Destroy(projetil, tempoDeDestruicao);
            }
            else
            {
                Debug.LogError("Script Projetil não encontrado no prefab!");
            }

        }
        // Instancia o projétil

    }
}