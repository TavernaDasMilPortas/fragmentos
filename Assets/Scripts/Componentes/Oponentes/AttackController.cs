using System.Collections;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private HitboxController hitbox; // Refer�ncia � hitbox
    [SerializeField] private float hitboxDuration = 0.5f; // Tempo em que a hitbox est� ativa para aplicar dano
    [SerializeField] private float attackCooldown = 2.0f; // Tempo de recarga do ataque
    [SerializeField] private float distanciaAtaque = 1.5f; // Dist�ncia m�nima para o ataque
    private Transform alvo; // Refer�ncia ao alvo
    private bool canAttack = true; // Controle do cooldown de ataque
    private bool ataqueHabilitado = false; // Define se o ataque est� ativo

    void Update()
    {
        if (alvo != null)
        {
            float distancia = Vector2.Distance(transform.position, alvo.position);
            if (distancia <= distanciaAtaque && canAttack)
            {
                IniciarAtaque(); // Inicia a anima��o de ataque
            }
        }
    }

    public void VerificarProximidade(Transform novoAlvo)
    {
        alvo = novoAlvo; // Atualiza o alvo
    }

    private void IniciarAtaque()
    {
        GetComponent<Animator>().SetTrigger("Atacar"); // Dispara a anima��o de ataque
        canAttack = false;
        ataqueHabilitado = true; // Permite � hitbox aplicar dano
        StartCoroutine(ResetarAtaque());
    }

    private IEnumerator ResetarAtaque()
    {
        yield return new WaitForSeconds(hitboxDuration); // Dura��o da hitbox "ativa"
        ataqueHabilitado = false; // Impede que a hitbox continue aplicando dano
        yield return new WaitForSeconds(attackCooldown - hitboxDuration); // Aguarda o cooldown restante
        canAttack = true; // Permite atacar novamente
    }

    public bool AtaqueHabilitado()
    {
        return ataqueHabilitado; // Retorna se o ataque est� ativo
    }

    public void AtaqueFinalizado()
    {
        ataqueHabilitado = false; // Desativa a aplica��o de dano pela hitbox
    }
}