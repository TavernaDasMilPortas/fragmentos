using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    [SerializeField] private float velocidadeMovimento;
    [SerializeField] private float velocidadeAtual;
    public Transform transform;
    public ManaControl mana;
    public GerenciarVida vida;
    public Fragmento[] fragmentos;
    public Fragmento fragmentoAtual;
    private bool andando;
    private int danoDisparo;
    void Awake()
    {
        fragmentoAtual = fragmentos[0];
    }

    public Rigidbody2D Rigidbody
    {
        get { return rigidbody; }
        set { rigidbody = value; }
    }
    public float VelocidadeAtual
    {
        get { return velocidadeAtual; }
        set { velocidadeAtual = value; }
    }
    public float VelocidadeMovimento
    {
        get { return velocidadeMovimento; }
        set { velocidadeMovimento = value; }
    }
    public Transform Transform
    {
        get { return transform; }
        set { transform = value; }
    }
    public ManaControl Mana
    {
        get { return mana; }
        set { mana = value; }
    }
    public GerenciarVida Vida
    {
        get { return vida; }
        set { vida = value; }
    }
    public bool Andando
    {
        get { return andando; }
        set { andando = value; }
    }
    public int DanoDisparo
    {
        get { return danoDisparo; }
        set { danoDisparo = value; }
    }
    public Fragmento FragmentoAtual
    {
        get { return fragmentoAtual; }
        set { fragmentoAtual = value; }
    }

    public Fragmento[] Fragmentos
    {
        get { return fragmentos; }
        set { fragmentos = value; }
    }
}
