using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoProjetil : MonoBehaviour
{
    public enum TipoProjetil
    {
        Fisico,
        Magico,
        Temporal,
        Explosivo,
                  
    }

    public GameObject prefabProjetil;  // O prefab do projétil
    [SerializeField] Transform pontoDeDisparo;   // O ponto de origem de onde o projétil parte
    public float velocidadeProjetil = 10.0f;  // Velocidade do projétil
    public float tempoDeDestruicao = 3.0f;  // Tempo até o projétil ser destruído automaticamente
    [SerializeField] public GameObject Atirador;
    private GameObject projetil;
    [SerializeField] Collider2D playerHurtbox;
    [SerializeField] ValorDano dano;
    public TipoProjetil tipo;  // Tipo do projétil, definido pelo enum
    [SerializeField] public Animator animator;
    [SerializeField] AudioSource attack;
    public void Disparar(int dano, TipoProjetil tipo)
    {
        attack.Play();
        animator.SetTrigger("Atacar");
        projetil = Instantiate(prefabProjetil, pontoDeDisparo.position, pontoDeDisparo.rotation);
        Projetil scriptProjetil = projetil.GetComponent<Projetil>();

        // Converte o enum para string para enviar ao método de inicialização
        string tipoString = tipo.ToString();
        scriptProjetil.Inicializar(this.dano.valorDano, tipoString, playerHurtbox, this.transform.root);

        Physics2D.IgnoreCollision(projetil.GetComponent<Collider2D>(), Atirador.GetComponent<Collider2D>());
        Rigidbody2D rb = projetil.GetComponent<Rigidbody2D>();

        // Define a velocidade e direção do projétil
        rb.velocity = (pontoDeDisparo.position - Atirador.transform.position).normalized * velocidadeProjetil;

        // Destroi o projétil após o tempo definido
        Destroy(projetil, tempoDeDestruicao);
    }
}

