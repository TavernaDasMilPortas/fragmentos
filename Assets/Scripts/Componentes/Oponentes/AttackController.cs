using System.Collections;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private HitboxController hitbox; // Referência à hitbox
    [SerializeField] private float hitboxDuration = 0.5f; // Tempo em que a hitbox está ativa para aplicar dano
    [SerializeField] private float attackCooldown = 2.0f; // Tempo de recarga do ataque
    [SerializeField] private float distanciaAtaque = 1.5f; // Distância mínima para o ataque
    private Transform alvo; // Referência ao alvo
    private bool canAttack = true; // Controle do cooldown de ataque
    private bool ataqueHabilitado = false; // Define se o ataque está ativo

    void Update()
    {
        if (alvo != null)
        {
            float distancia = Vector2.Distance(transform.position, alvo.position);
            if (distancia <= distanciaAtaque && canAttack)
            {
                IniciarAtaque(); // Inicia a animação de ataque
            }
        }
    }

    public void VerificarProximidade(Transform novoAlvo)
    {
        alvo = novoAlvo; // Atualiza o alvo
    }

    private void IniciarAtaque()
    {
        GetComponent<Animator>().SetTrigger("Atacar"); // Dispara a animação de ataque
        canAttack = false;
        ataqueHabilitado = true; // Permite à hitbox aplicar dano
        StartCoroutine(ResetarAtaque());
    }

    private IEnumerator ResetarAtaque()
    {
        yield return new WaitForSeconds(hitboxDuration); // Duração da hitbox "ativa"
        ataqueHabilitado = false; // Impede que a hitbox continue aplicando dano
        yield return new WaitForSeconds(attackCooldown - hitboxDuration); // Aguarda o cooldown restante
        canAttack = true; // Permite atacar novamente
    }

    public bool AtaqueHabilitado()
    {
        return ataqueHabilitado; // Retorna se o ataque está ativo
    }

    public void AtaqueFinalizado()
    {
        ataqueHabilitado = false; // Desativa a aplicação de dano pela hitbox
    }
}