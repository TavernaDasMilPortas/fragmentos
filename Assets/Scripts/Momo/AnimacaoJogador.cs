using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacaoJogador : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private PLayer player;


    // Update is called once per frame
    void LateUpdate()
    {
        AnimacaoMovimentacao();
    }
    void AnimacaoMovimentacao()
    {

        //Vector2 movimento = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),0f);
        Vector2 movimento = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position;
        movimento = movimento.normalized;
        animator.SetFloat("Horizontal", movimento.x);
        animator.SetFloat("Vertical", movimento.y);
        animator.SetBool("Andando", player.Andando);

 
    }
}
