using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esfera : MonoBehaviour
{
    public Transform personagem;  
    public float distancia = 1.4f;
    private SpriteRenderer spriteRenderer;
    [SerializeField] Animator animator;
    [SerializeField] Transform mira;
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
        mira.position = novaPosicao;
        float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
        // Ajusta o ângulo para alinhar o arco paralelamente ao alvo
        angulo += 90f;
        // Atualiza a rotação do ponto de ataque
        mira.rotation = Quaternion.Euler(0f, 0f, angulo);
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
