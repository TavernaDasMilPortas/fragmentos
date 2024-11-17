using System.Collections;
using UnityEngine;

public class AtaqueMelle : MonoBehaviour
{
    public float DistanciaMaxAtaque; // Distância máxima para atacar
    [SerializeField] private Transform hitboxSpawnPoint; // Posição da hitbox
    [SerializeField] private float hitboxDuration = 0.01f; // Duração da hitbox
    [SerializeField] private float attackCooldown = 2.0f; // Tempo de recarga do ataque
    public bool canAttack = true; // Controle para evitar ataques consecutivos
    [SerializeField] private ValorDano dano;
    [SerializeField] private OponenteCore oponente;
    [SerializeField] private Hitbox hitbox;

    void Start()
    {
        DistanciaMaxAtaque = 2.5f;
        hitbox.gameObject.SetActive(false); // Garante que a hitbox esteja desativada inicialmente
        hitbox.dano = dano.valorDano; // Define o dano da hitbox
    }

    public void VerificarPossibilidadeAtaque()
    {
        float distancia = Vector2.Distance(this.transform.position, oponente.Alvo.position);
        if (distancia <= oponente.DistanciaMinima || distancia <= DistanciaMaxAtaque && canAttack)
        {
            StartCoroutine(Atacar());
        }
    }

    public IEnumerator Atacar()
    {
        canAttack = false;
        hitbox.AtivarHitbox(); // Ativa a hitbox
        yield return new WaitForSeconds(hitboxDuration);
        hitbox.DesativarHitbox(); // Desativa a hitbox
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}