using System.Collections;
using UnityEngine;

public class AtaqueMelle : MonoBehaviour, Iataque
{
    public float DistanciaMaxAtaque = 2.5f; // Dist�ncia m�xima para atacar
    [SerializeField] private Transform hitboxSpawnPoint; // Posi��o da hitbox
    [SerializeField] private float hitboxDuration = 0.7f; // Dura��o da hitbox
    [SerializeField] private float attackCooldown = 2.0f; // Tempo de recarga do ataque
    private bool isAttacking = false; // Para evitar m�ltiplos ataques ao mesmo tempo
    public bool canAttack = true; // Controle para evitar ataques consecutivos
    [SerializeField] private OponenteCore oponente;
    [SerializeField] private HitboxController hitbox;
    [SerializeField] Animator animadorGarras;
    [SerializeField] Animator animadorWalker;



    public void VerificarPossibilidadeAtaque(Transform alvo)
    {
        if (alvo == null) return;

        // Verifica a dist�ncia entre o atacante e o alvo
        float distancia = Vector2.Distance(this.transform.position, alvo.position);

        if (distancia <= DistanciaMaxAtaque && canAttack)
        {
            animadorWalker.SetBool("Atacando", true);
            hitbox.AtivarHitbox();
            animadorGarras.SetTrigger("Atacar");
        }
    }
    public void Atacar()
    {
        if (canAttack && !isAttacking)
        {
            StartCoroutine(RealizarAtaque());
        }
    }

    public IEnumerator RealizarAtaque()
    {
        isAttacking = true;
        canAttack = false;
        yield return new WaitForSeconds(0.3f);
        animadorWalker.SetBool("Atacando", false);
  // Bloqueia novos ataques
        yield return new WaitForSeconds(hitboxDuration);
        hitbox.DesativarHitbox(); // Desativa a hitbox ap�s a dura��o
       
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true; // Permite novos ataques ap�s o cooldown
        isAttacking = false;
    }
}

