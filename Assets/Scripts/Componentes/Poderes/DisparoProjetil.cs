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

    public GameObject prefabProjetil;  // O prefab do proj�til
    [SerializeField] Transform pontoDeDisparo;   // O ponto de origem de onde o proj�til parte
    public float velocidadeProjetil = 10.0f;  // Velocidade do proj�til
    public float tempoDeDestruicao = 3.0f;  // Tempo at� o proj�til ser destru�do automaticamente
    [SerializeField] public GameObject Atirador;
    private GameObject projetil;
    [SerializeField] Collider2D playerHurtbox;
    [SerializeField] ValorDano dano;
    public TipoProjetil tipo;  // Tipo do proj�til, definido pelo enum
    [SerializeField] public Animator animator;
    [SerializeField] AudioSource attack;
    public void Disparar(int dano, TipoProjetil tipo)
    {
        attack.Play();
        animator.SetTrigger("Atacar");
        projetil = Instantiate(prefabProjetil, pontoDeDisparo.position, pontoDeDisparo.rotation);
        Projetil scriptProjetil = projetil.GetComponent<Projetil>();

        // Converte o enum para string para enviar ao m�todo de inicializa��o
        string tipoString = tipo.ToString();
        scriptProjetil.Inicializar(this.dano.valorDano, tipoString, playerHurtbox, this.transform.root);

        Physics2D.IgnoreCollision(projetil.GetComponent<Collider2D>(), Atirador.GetComponent<Collider2D>());
        Rigidbody2D rb = projetil.GetComponent<Rigidbody2D>();

        // Define a velocidade e dire��o do proj�til
        rb.velocity = (pontoDeDisparo.position - Atirador.transform.position).normalized * velocidadeProjetil;

        // Destroi o proj�til ap�s o tempo definido
        Destroy(projetil, tempoDeDestruicao);
    }
}

