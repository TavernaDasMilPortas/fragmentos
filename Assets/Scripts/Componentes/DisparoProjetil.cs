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

    private void Start()
    {
        pontoDeDisparo = this.transform; // Inicializa o ponto de disparo
    }

    void Update()
    {
        // Verifica se o botão esquerdo do mouse foi pressionado
        if (Input.GetKeyDown(KeyCode.Mouse0))  // 0 é o botão esquerdo do mouse
        {
            // Dispara o projétil
            Disparar();
        }
    }

    void Disparar()
    {
        // Instancia o projétil na posição da esfera (pontoDeDisparo)
        projetil = Instantiate(prefabProjetil, pontoDeDisparo.position, pontoDeDisparo.rotation);

        // Obtém o Rigidbody2D do projétil
        Rigidbody2D rb = projetil.GetComponent<Rigidbody2D>();

        // Aplica uma velocidade na direção em que o ponto de disparo (esfera) está apontando
        rb.velocity = pontoDeDisparo.right * velocidadeProjetil;

        // Destrói o projétil após um tempo (tempoDeDestruicao)
        Destroy(projetil, tempoDeDestruicao);
    }


}
