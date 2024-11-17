using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public GameObject owner; // O dono da hitbox (inimigo ou jogador)
    public int dano; // Dano que a hitbox aplica
    private HashSet<GameObject> alvosAtingidos = new HashSet<GameObject>(); // Alvos que já receberam dano nesta ativação

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hurtbox"))
        {
            if (alvosAtingidos.Contains(other.gameObject)) return; // Evita aplicar dano repetido no mesmo alvo

            var hurtbox = other.GetComponent<Hurtbox>();
            if (hurtbox != null)
            {
                hurtbox.vida.ReceberDano(dano); // Aplica o dano
                alvosAtingidos.Add(other.gameObject); // Marca o alvo como atingido
            }
        }
    }

    public void AtivarHitbox()
    {
        alvosAtingidos.Clear(); // Reseta a lista de alvos atingidos ao ativar a hitbox
        gameObject.SetActive(true); // Ativa a hitbox
    }

    public void DesativarHitbox()
    {
        gameObject.SetActive(false); // Desativa a hitbox
    }
}