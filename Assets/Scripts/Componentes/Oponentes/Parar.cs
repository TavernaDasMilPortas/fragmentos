using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parar : MonoBehaviour
{
    [SerializeField] public OponenteCore oponente;
    public void PararMovimento()
    {
       oponente.Rigidbody.velocity = Vector2.zero;
    }
}
