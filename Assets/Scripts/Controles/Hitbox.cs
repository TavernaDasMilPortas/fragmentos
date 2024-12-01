using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public GameObject owner; // O dono da hitbox (inimigo ou jogador)
    public ValorDano dano; // Dano que a hitbox aplica
    [SerializeField] public HashSet<GameObject> alvosAtingidos = new HashSet<GameObject>(); // Alvos que j� receberam dano nesta ativa��o
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
                Debug.Log("[Hitbox] A colis�o ocorreu, mas a Hurtbox est� ausente.");
                return;
            }

            // Verifique se o dono da Hitbox e da Hurtbox pertencem a grupos diferentes (com base em root)
            bool ownerIsPlayer = owner.transform.root.CompareTag("Player");
            bool otherIsPlayer = hurtbox.owner.transform.root.CompareTag("Player");

            bool ownerIsOpponent = owner.transform.root.CompareTag("Oponente");
            bool otherIsOpponent = hurtbox.owner.transform.root.CompareTag("Oponente");

            // Verifica se s�o de grupos diferentes
            if ((ownerIsPlayer && otherIsPlayer) || (ownerIsOpponent && otherIsOpponent))
            {
                Debug.Log("[Hitbox] O dono da Hitbox e da Hurtbox s�o do mesmo grupo. Ignorando dano.");
                return;
            }

            // Se n�o for do mesmo grupo, verifica se o alvo j� foi atingido
            if (!alvosAtingidos.Contains(other.gameObject))
            {
                alvosAtingidos.Add(other.gameObject); // Marca o alvo como atingido
                Debug.Log($"[Hitbox] Aplicando {dano.valorDano} de dano ao alvo: {hurtbox.owner.name}");

                // Aplica o dano
                hurtbox.vida.ReceberDano(dano.valorDano);
            }
            else
            {
                Debug.Log("[Hitbox] Alvo j� foi atingido anteriormente.");
            }
        }
        else
        {
            Debug.Log("[Hitbox] Colis�o com um objeto que n�o � uma Hurtbox.");
        }

    }
    public void FinalizarAtaque()
    {
        alvosAtingidos.Clear();  // Limpa a lista de alvos ap�s o ataque
        Debug.Log("[Hitbox] Lista de alvos atingidos limpa.");
    }
}