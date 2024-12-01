using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public GameObject owner; // O dono da hitbox (inimigo ou jogador)
    public ValorDano dano; // Dano que a hitbox aplica
    [SerializeField] public HashSet<GameObject> alvosAtingidos = new HashSet<GameObject>(); // Alvos que já receberam dano nesta ativação
    Collider2D other;
    void OnTriggerEnter2D(Collider2D other)
    {
        Atacar(other);
    }
    public void Atacar(Collider2D other)
    {
        if (other.CompareTag("Hurtbox"))
        {
            var hurtbox = other.GetComponent<Hurtbox>();
            if (hurtbox == null)
            {
                Debug.Log("[Hitbox] A colisão ocorreu, mas a Hurtbox está ausente.");
                return;
            }

            // Verifique se o dono da Hitbox e da Hurtbox pertencem a grupos diferentes (com base em root)
            bool ownerIsPlayer = owner.transform.root.CompareTag("Player");
            bool otherIsPlayer = hurtbox.owner.transform.root.CompareTag("Player");

            bool ownerIsOpponent = owner.transform.root.CompareTag("Oponente");
            bool otherIsOpponent = hurtbox.owner.transform.root.CompareTag("Oponente");

            // Verifica se são de grupos diferentes
            if ((ownerIsPlayer && otherIsPlayer) || (ownerIsOpponent && otherIsOpponent))
            {
                Debug.Log("[Hitbox] O dono da Hitbox e da Hurtbox são do mesmo grupo. Ignorando dano.");
                return;
            }

            // Se não for do mesmo grupo, verifica se o alvo já foi atingido
            if (!alvosAtingidos.Contains(other.gameObject))
            {
                alvosAtingidos.Add(other.gameObject); // Marca o alvo como atingido
                Debug.Log($"[Hitbox] Aplicando {dano.valorDano} de dano ao alvo: {hurtbox.owner.name}");

                // Aplica o dano
                hurtbox.vida.ReceberDano(dano.valorDano);
            }
            else
            {
                Debug.Log("[Hitbox] Alvo já foi atingido anteriormente.");
            }
        }
        else
        {
            Debug.Log("[Hitbox] Colisão com um objeto que não é uma Hurtbox.");
        }

    }
    public void FinalizarAtaque()
    {
        alvosAtingidos.Clear();  // Limpa a lista de alvos após o ataque
        Debug.Log("[Hitbox] Lista de alvos atingidos limpa.");
    }
}