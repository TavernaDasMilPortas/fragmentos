using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaminahnteAnimacao : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private OponenteCore oponente;

    [SerializeField]
    private Patrulhar patrulhar;

    // Update is called once per frame
    void LateUpdate()
    {
        AnimacaoMovimentacao();
    }
    void AnimacaoMovimentacao()
    { 

        Vector2 movimento;
        if (oponente.Alvo == null)
        {
            movimento = this.transform.position - patrulhar.waypoints[patrulhar.currentWaypointIndex].position;
            animator.SetBool("Andando", true);
            animator.SetBool("Correndo", false);
        }
        else
        {
            movimento = this.transform.position - oponente.Alvo.position;
            animator.SetBool("Andando", false);
            animator.SetBool("Correndo", true);

        }
        movimento = movimento.normalized;
        animator.SetFloat("Horizontal", movimento.x);
        animator.SetFloat("Vertical", movimento.y);
    }
}
