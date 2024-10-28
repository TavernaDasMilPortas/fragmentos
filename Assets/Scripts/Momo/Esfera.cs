using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esfera : MonoBehaviour
{
    public Transform personagem;  
    public float distancia = 1.4f;
    private SpriteRenderer spriteRenderer; 
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
            // Mouse está acima do jogador, esfera vai para "trás"
            spriteRenderer.sortingOrder = -1;  // Define um valor menor para ficar atrás do jogador
        }
        else
        {
            // Mouse está abaixo do jogador, esfera vai para "frente"
            spriteRenderer.sortingOrder = 1;  // Define um valor maior para ficar na frente do jogador
        }
        float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angulo);
    }
}
