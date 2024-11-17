using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procurar : MonoBehaviour
{
    [SerializeField] public OponenteCore oponente;
    public Transform ProcurarAlvo()
    {
        Collider2D[] colisores = Physics2D.OverlapCircleAll(transform.position, oponente.RaioVisao, oponente.Layermask);
        foreach (var colisor in colisores)
        {

                    Vector2 posicaoAtual = this.transform.position;
                    Vector2 posicaoAlvo = colisor.transform.position;
                    Vector2 direcao = posicaoAlvo - posicaoAtual;
                    direcao = direcao.normalized;
                    RaycastHit2D hit = Physics2D.Raycast(posicaoAtual, direcao, oponente.RaioVisao);
                    
                    if (hit.transform != null && hit.transform.root.CompareTag("Player"))
                    {   
                            return hit.transform.root;   
                    }
                    else
                    {
                        return null;
                    }
             
        }
        return null;
        
    }
}
