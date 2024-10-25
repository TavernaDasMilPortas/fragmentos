using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projetil : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Destrói o projétil ao colidir com qualquer coisa
        Destroy(gameObject);
    }
}