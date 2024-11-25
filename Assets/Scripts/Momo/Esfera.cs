using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esfera : MonoBehaviour
{
    public Transform personagem;  
    public float distancia = 1.4f;
    private SpriteRenderer spriteRenderer;
    [SerializeField] Animator animator;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Vector2 posicaoMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direcao = (posicaoMouse - (Vector2)personagem.position).normalized;
        Vector2 novaPosicao = (Vector2)personagem.position + direcao * distancia;
        transform.position = novaPosicao;
        if (posicaoMouse.y > personagem.position.y)
        {

            if (animator != null)
            {
              animator.SetBool("Costas", true);
            }
            spriteRenderer.sortingOrder = -1;

        }
        else
        {
            if (animator != null)
            {
                animator.SetBool("Costas", false);
            }
            spriteRenderer.sortingOrder = 1;  

        }


    }
}
