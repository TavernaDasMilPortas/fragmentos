using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueMelle : MonoBehaviour
{
    public float range;
    public float DistanciaMaxAtaque;
    [SerializeField] private ValorDano dano;
    [SerializeField] private OponenteCore oponente;
    [SerializeField] public Transform pontoAtaque; 
    public float countDownTime;
    public float countDown;

    private void Start()
    {
        countDownTime = 1.5f;
        countDown = 0;
        DistanciaMaxAtaque = 1.5f;
        range = 2f;
    }
    public void VerificarPossibilidadeAtaque()

    {
        float distância = Vector2.Distance(this.transform.position, oponente.Alvo.position);
        if (distância <= DistanciaMaxAtaque || distância == oponente.DistanciaMinima)
        { 
        countDown -= Time.deltaTime;
        Renderer renderer = gameObject.GetComponent<Renderer>();
        renderer.material.color = Color.red;
        if (countDown <= 0)
        {
            

            this.countDown = this.countDownTime;
            Atacar();

            }


        }
    }
    public void Atacar()
    {
        Collider2D colisorJogador =  Physics2D.OverlapCircle(this.pontoAtaque.position, this.range, oponente.Layermask);
        if (colisorJogador != null)
        {

            if (colisorJogador.CompareTag("Player"))
            {
                GerenciarVida vida = colisorJogador.GetComponent<GerenciarVida>();
                vida.JogadorSofreDano(dano);
                
            }
        }

      
    }

    public void OnDrawGizmos()
    {

            Gizmos.DrawWireSphere(this.pontoAtaque.position, this.range);

    }
}
