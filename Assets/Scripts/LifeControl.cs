using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeControl : MonoBehaviour
{
    [SerializeField]
    public int vidaMax;
    public int vidaAtual;
    // Start is called before the first frame update
    void Start()
    {
        vidaAtual = vidaMax;
    }
    void Update (){

        Morrer();
    }
    // Update is called once per frame

    public void Morrer()
    {
        if(vidaAtual <= 0)
        {
            Destroy(gameObject);
        }
    }
}
