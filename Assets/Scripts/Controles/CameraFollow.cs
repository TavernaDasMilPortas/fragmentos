using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 100f;
    public float yOffset = 1f;
    public Transform jogador;

    void LateUpdate()
    {
        Vector3 novaPosicao = new Vector3(jogador.position.x, jogador.position.y, transform.position.z);
        novaPosicao.x = Mathf.Round(novaPosicao.x * 100f) / 100f;
        novaPosicao.y = Mathf.Round(novaPosicao.y * 100f) / 100f;
        transform.position = novaPosicao;
    }
}

