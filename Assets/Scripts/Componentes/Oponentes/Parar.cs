using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parar : MonoBehaviour
{
    [SerializeField] public OponenteCore oponente;
    public void PararMovimento()
    {
       oponente.agent.velocity = Vector2.zero;
    }
}
