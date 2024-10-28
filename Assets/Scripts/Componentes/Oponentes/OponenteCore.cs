using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OponenteCore : MonoBehaviour
{
    
    private float velocidade;
    private float distanciaMinima;
    private float tempoFoco;
    [SerializeField] private GerenciarVida vida;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float raioVisao;
    [SerializeField] private LayerMask layermask;
    [SerializeField] private Transform alvo;

    // Getter e Setter para vida
    public GerenciarVida Vida
    {
        get { return vida; }
        set { vida  = value; }
    }

    // Getter e Setter para velocidade
    public float Velocidade
    {
        get { return velocidade; }
        set { velocidade = value; }
    }

    // Getter e Setter para distanciaMinima
    public float DistanciaMinima
    {
        get { return distanciaMinima; }
        set { distanciaMinima = value; }
    }

    // Getter e Setter para rigidbody
    public Rigidbody2D Rigidbody
    {
        get { return rigidbody; }
        set { rigidbody = value; }
    }

    // Getter e Setter para raioVisao
    public float RaioVisao
    {
        get { return raioVisao; }
        set { raioVisao = value; }
    }

    // Getter e Setter para layermask
    public LayerMask Layermask
    {
        get { return layermask; }
        set { layermask = value; }
    }
    public Transform Alvo
    {
        get { return alvo; }
        set { alvo = value; }
    }

    public float TempoFoco
    {
        get { return tempoFoco; }
        set { tempoFoco = value; }
    }
}