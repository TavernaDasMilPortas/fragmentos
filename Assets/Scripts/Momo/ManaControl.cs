using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaControl : MonoBehaviour
{
    [SerializeField]
    private int manaMax = 10;
    public int manaAtual;
    private float timer = 0f; // Temporizador
    public float intervalo = 1f; 
    public int recuperacao = 1;
    // Start is called before the first frame update
    void Start()
    {
        manaAtual = manaMax;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= intervalo)
        {
            RecuperarMana();
            timer = 0f;
        }
    }

    void RecuperarMana()
    {
        if (manaAtual < manaMax)
        {
            manaAtual += recuperacao;
        }
    }

    public void GastarMana(int custoMana)
    {
        if (manaAtual - custoMana >= 0)
        {
            manaAtual = manaAtual - custoMana;
        }
    }

}
