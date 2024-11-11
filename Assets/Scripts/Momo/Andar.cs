using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Andar : MonoBehaviour
{
    [SerializeField] PlayerCore player;
    public void Deslocar()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 direcao = new Vector2(horizontal, vertical);
        direcao = direcao.normalized;
        if (Input.GetKey(KeyCode.W) == true || Input.GetKey(KeyCode.A) == true || Input.GetKey(KeyCode.S) == true || Input.GetKey(KeyCode.D) == true)
        {
            player.VelocidadeAtual = player.VelocidadeMovimento;
            player.Andando = true;
        }
        else
        {
            player.VelocidadeAtual = 0;
            player.Andando = false;  
        }
       player.Rigidbody.velocity = direcao * player.VelocidadeAtual;
    }
}
