using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public GameObject owner; // O dono da hitbox (inimigo ou jogador)
    public ValorDano dano; // Dano que a hitbox aplica
    public HashSet<GameObject> alvosAtingidos = new HashSet<GameObject>(); // Alvos que já receberam dano nesta ativação

    void OnTriggerEnter2D(Collider2D other)
    {
        // Exibe o nome do objeto colidido
        Debug.Log("Objeto colidido: " + other.gameObject.name);

        // Verifica se o objeto colidido tem a tag "Hurtbox"
        if (other.CompareTag("Hurtbox"))
        {
            // Obtém o objeto raiz do outro (colidido) para comparar a tag com "Player" ou "Oponente"
            GameObject raiz = other.gameObject.transform.root.gameObject;

            // Verifica se o dono (owner) da hitbox é o player ou inimigo
            bool isPlayer = owner.transform.root.CompareTag("Player");
            bool isEnemy = owner.transform.root.CompareTag("Oponente");

            // Se for o player, só detecta a hurtbox dos inimigos
            if (isPlayer && raiz.CompareTag("Oponente"))
            {
                // Verifica se o owner não é o mesmo objeto que a hurtbox
                if (owner != null && owner != other.gameObject)
                {
                    Debug.Log("Owner (Player) não é igual ao objeto colidido.");
                    if (!alvosAtingidos.Contains(other.gameObject))
                    {
                        // Busca a Hurtbox dentro da hierarquia de "other"
                        var hurtbox = other.GetComponentInChildren<Hurtbox>();
                        if (hurtbox != null)
                        {
                            Debug.Log("Hurtbox do inimigo encontrada, aplicando "+ dano.valorDano + " dano.");
                            hurtbox.vida.ReceberDano(dano.valorDano);
                            alvosAtingidos.Add(other.gameObject);
                        }
                        else
                        {
                            Debug.LogWarning("Hurtbox não encontrada no objeto colidido.");
                        }
                    }
                }
            }
            // Se for um inimigo, só detecta a hurtbox do player
            else if (isEnemy && raiz.CompareTag("Player"))
            {
                // Verifica se o owner não é o mesmo objeto que a hurtbox
                if (owner != null && owner != other.gameObject)
                {
                    Debug.Log("Owner (Inimigo) não é igual ao objeto colidido.");
                    if (!alvosAtingidos.Contains(other.gameObject))
                    {
                        // Busca a Hurtbox dentro da hierarquia de "other"
                        var hurtbox = other.GetComponentInChildren<Hurtbox>();
                        if (hurtbox != null)
                        {
                            Debug.Log("Hurtbox do player encontrada, aplicando " + dano.valorDano + " dano.");
                            hurtbox.vida.ReceberDano(dano.valorDano);
                            alvosAtingidos.Add(other.gameObject);
                        }
                        else
                        {
                            Debug.LogWarning("Hurtbox não encontrada no objeto colidido.");
                        }
                    }
                }
            }
        }
        else
        {
            Debug.LogWarning("O objeto colidido não tem a tag 'Hurtbox'.");
        }
    }
}
