using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoProjetil : MonoBehaviour
{
    public GameObject prefabProjetil;  // O prefab do proj�til
    private Transform pontoDeDisparo;   // O ponto de origem de onde o proj�til parte
    public float velocidadeProjetil = 10.0f;  // Velocidade do proj�til
    public float tempoDeDestruicao = 3.0f;  // Tempo at� o proj�til ser destru�do automaticamente
    [SerializeField] public GameObject Atirador;
    private GameObject projetil;

    private void Start()
    {
        pontoDeDisparo = this.transform; // Inicializa o ponto de disparo
    }

    void Update()
    {
        // Verifica se o bot�o esquerdo do mouse foi pressionado
        if (Input.GetKeyDown(KeyCode.Mouse0))  // 0 � o bot�o esquerdo do mouse
        {
            // Dispara o proj�til
            Disparar();
        }
    }

    void Disparar()
    {
        // Instancia o proj�til na posi��o da esfera (pontoDeDisparo)
        projetil = Instantiate(prefabProjetil, pontoDeDisparo.position, pontoDeDisparo.rotation);

        // Obt�m o Rigidbody2D do proj�til
        Rigidbody2D rb = projetil.GetComponent<Rigidbody2D>();

        // Aplica uma velocidade na dire��o em que o ponto de disparo (esfera) est� apontando
        rb.velocity = pontoDeDisparo.right * velocidadeProjetil;

        // Destr�i o proj�til ap�s um tempo (tempoDeDestruicao)
        Destroy(projetil, tempoDeDestruicao);
    }


}
