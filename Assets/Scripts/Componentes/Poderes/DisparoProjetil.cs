using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoProjetil : MonoBehaviour
{
    public GameObject prefabProjetil;  // O prefab do projétil
    private Transform pontoDeDisparo;   // O ponto de origem de onde o projétil parte
    public float velocidadeProjetil = 10.0f;  // Velocidade do projétil
    public float tempoDeDestruicao = 3.0f;  // Tempo até o projétil ser destruído automaticamente
    [SerializeField] public GameObject Atirador;
    private GameObject projetil;
    [SerializeField] PlayerCore player;
    public string tipo;

    private void Start()
    {
        pontoDeDisparo = this.transform; // Inicializa o ponto de disparo
    }

    public void Disparar(int dano, string tipo)
    {
        projetil = Instantiate(prefabProjetil, pontoDeDisparo.position, pontoDeDisparo.rotation);
        Projetil proj = projetil.GetComponent<Projetil>();
        proj.Inicializar(dano, tipo);
        Physics2D.IgnoreCollision(projetil.GetComponent<Collider2D>(), Atirador.GetComponent<Collider2D>());
        Rigidbody2D rb = projetil.GetComponent<Rigidbody2D>();
        rb.velocity = (pontoDeDisparo.position - Atirador.transform.position).normalized * velocidadeProjetil;
        Destroy(projetil, tempoDeDestruicao);
    }


}