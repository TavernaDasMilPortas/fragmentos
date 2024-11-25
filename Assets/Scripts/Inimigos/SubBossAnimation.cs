using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubBossAnimation : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private OponenteCore oponente;


    // Update is called once per frame
    void LateUpdate()
    {
        AnimacaoMovimentacao();
    }
    void AnimacaoMovimentacao()
    {

        Vector2 movimento;

        movimento = this.transform.position - oponente.Alvo.position;
        movimento = movimento.normalized;
        animator.SetFloat("Horizontal", movimento.x);
        animator.SetFloat("Vertical", movimento.y);
    }
}
